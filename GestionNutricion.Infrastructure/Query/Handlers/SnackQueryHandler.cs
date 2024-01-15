using GestionNutricion.Infrastructure.DTOs.Snack;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionNutricion.Infrastructure.Query.Handlers
{
    public class SnackQueryHandler : QueryHandler
    {
        public SnackQueryHandler(string connectionString) : base(connectionString)
        {
        }

        public List<string> GetSnacks(int snackTimeId)
        {
            StringBuilder queryString = new StringBuilder();
            queryString.AppendLine("select Food from Snack where IdSnackTime = @SnackTimeId order by Food");

            SqlCommand sqlCmd = new SqlCommand(queryString.ToString());
            sqlCmd.Parameters.AddWithValue("@SnackTimeId", snackTimeId);
            DataTable table = (DataTable)Execute(sqlCmd, TipoRetorno.TB, Transaccion.NoAcepta);

            List<string> snacks = new();
            foreach (DataRow row in table.Rows)
            {
                snacks.Add(row["Food"].ToString());
            }

            return snacks;
        }
    }
}
