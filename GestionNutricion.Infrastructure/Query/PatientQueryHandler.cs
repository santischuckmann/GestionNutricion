using GestionNutricion.Infrastructure.DTOs;
using GestionNutricion.Infrastructure.DTOs.DietaryPlan;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace GestionNutricion.Infrastructure.Query
{
    public class PatientQueryHandler: QueryHandler
    {
        public PatientQueryHandler(string connectionString) : base(connectionString)
        {

        }

        public List<PatientDto> GetAllPatients(int userId)
        {
            StringBuilder queryString = new StringBuilder();
            queryString.AppendLine("select p.PatientId, p.Name, p.Surname, p.FirstAppointmentDate, p.LastAppointmentDate, p.IsActive, ");
            queryString.AppendLine("COUNT(d.DietaryPlanId) as DietaryPlanCount from Patient p, DietaryPlan d ");
            queryString.AppendLine("where p.UserId = @UserId and d.PatientId = p.PatientId ");
            queryString.AppendLine("group by p.PatientId, p.Name, p.Surname, p.FirstAppointmentDate, p.LastAppointmentDate, p.IsActive ");
            queryString.AppendLine("order by p.PatientId");

            SqlCommand sqlCmd = new SqlCommand(queryString.ToString());
            sqlCmd.Parameters.AddWithValue("@UserId", userId);
            DataTable table = (DataTable)Execute(sqlCmd, TipoRetorno.TB, Transaccion.NoAcepta);

            List<PatientDto> patientPlanDtos = new();

            foreach (DataRow dr in table.Rows)
            {
                PatientDto patientDto = new();
                patientDto.PatientId = Convert.ToInt32(dr["PatientId"]);
                patientDto.Name = dr["Name"].ToString();
                patientDto.Surname = dr["Surname"].ToString();
                patientDto.FirstAppointmentDate = Convert.ToDateTime(dr["FirstAppointmentDate"]);
                patientDto.LastAppointmentDate = Convert.ToDateTime(dr["LastAppointmentDate"]);
                patientDto.DietaryPlanCount = Convert.ToInt32(dr["DietaryPlanCount"]);
                patientDto.IsActive = Convert.ToBoolean(dr["IsActive"]);

                patientPlanDtos.Add(patientDto);
            }

            return patientPlanDtos;
        }
    }
}
