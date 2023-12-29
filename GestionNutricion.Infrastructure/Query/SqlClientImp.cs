﻿using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace GestionNutricion.Infrastructure.Query
{
    public class QueryHandler
    {
        public QueryHandler(string connectionString)
        { 
            _connectionString = connectionString; 
        }
        private string _connectionString;
        public enum TipoRetorno { None, CantReg, DS, TB };
        public enum Transaccion { Acepta, NoAcepta, Usa };
        protected object Execute(SqlCommand SqlCmd, TipoRetorno TipoRetorno, Transaccion Transaccion)
        {
            bool usaTransaccion = Transaccion != Transaccion.NoAcepta;
            try
            {
                SqlCmd.Connection = new SqlConnection(_connectionString);
                SqlCmd.Connection.Open();
                SqlCmd.CommandTimeout = 600;
                if (usaTransaccion) SqlCmd.Transaction = SqlCmd.Connection.BeginTransaction();
                DataSet ds = new DataSet();
                int cantReg = 0;
                switch (TipoRetorno)
                {
                    case (TipoRetorno.None):
                    case (TipoRetorno.CantReg):
                        cantReg = SqlCmd.ExecuteNonQuery();
                        break;
                    case (TipoRetorno.DS):
                    case (TipoRetorno.TB):
                        SqlDataAdapter sqlAdapter = new SqlDataAdapter(SqlCmd); sqlAdapter.Fill(ds);
                        break;
                }
                if (usaTransaccion) SqlCmd.Transaction.Commit();
                SqlCmd.Connection.Close();
                switch (TipoRetorno)
                {
                    case TipoRetorno.None:
                        return new System.Object();
                    case TipoRetorno.CantReg:
                        return cantReg;
                    case TipoRetorno.DS:
                        return ds;
                    default: //TipoRetorno.TB:
                        if (ds.Tables.Count == 0)
                            return new DataTable();
                        else
                            return ds.Tables[0];
                }
            }
            catch (System.Data.SqlClient.SqlException ex1)
            {
                if (((System.Data.SqlClient.SqlException)(ex1)).Procedure == "ConnectionOpen (Connect()).")
                {
                    throw new Microsoft.ApplicationBlocks.ExceptionManagement.db.ConexionException(ex1);
                }
                else
                {
                    if (usaTransaccion)
                    {
                        try
                        {
                            SqlCmd.Transaction.Rollback();
                            throw new Microsoft.ApplicationBlocks.ExceptionManagement.db.EjecucionConRollbackException(ex1);
                        }
                        catch (Microsoft.ApplicationBlocks.ExceptionManagement.db.EjecucionConRollbackException)
                        {
                            throw new Microsoft.ApplicationBlocks.ExceptionManagement.db.EjecucionConRollbackException(ex1);
                        }
                        catch
                        {
                            throw new Microsoft.ApplicationBlocks.ExceptionManagement.db.RollbackException(ex1);
                        }
                    }
                    else
                    {
                        throw new Microsoft.ApplicationBlocks.ExceptionManagement.db.EjecucionException(ex1);
                    }
                }
            }
        }
        protected string SqlScript(SqlCommand SqlCmd)
        {
            StringBuilder a = new StringBuilder();
            for (int i = 0; i < SqlCmd.Parameters.Count; i++)
            {
                a.AppendLine("declare " + SqlCmd.Parameters[i].ParameterName + $" as {SqlCmd.Parameters[i].DbType}; ");
                a.AppendLine("set " + SqlCmd.Parameters[i].ParameterName + "='" + SqlCmd.Parameters[i].Value.ToString() + "' ");
            }
            a.AppendLine(SqlCmd.CommandText);
            return a.ToString();
        }
    }
}
