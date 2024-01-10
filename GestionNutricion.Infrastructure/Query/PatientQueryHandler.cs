using GestionNutricion.Infrastructure.DTOs.DietaryPlan;
using GestionNutricion.Infrastructure.DTOs.Patient;
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
                patientDto.IsActive = Convert.ToBoolean(dr["IsActive"]);
                patientDto.DietaryPlanCount = Convert.ToInt32(dr["DietaryPlanCount"]);

                patientPlanDtos.Add(patientDto);
            }

            return patientPlanDtos;
        }

        public DetailedPatientDto? GetPatient(int patientId, int userId)
        {
            StringBuilder queryString = new StringBuilder();
            queryString.AppendLine("select p.*, ");
            queryString.AppendLine("dp.DietaryPlanId, dp.Breakfast, dp.Observations, ");
            queryString.AppendLine("mc.MainCourseId, mc.Food as MainCourseFood, mc.Dessert, mc.IdMainCourseType,");
            queryString.AppendLine("ps.PlanSnackId, ps.Food as PlanSnackFood, ps.IdSnackTime ");
            queryString.AppendLine("from Patient p ");
            queryString.AppendLine("join DietaryPlan dp on dp.PatientId = p.PatientId ");
            queryString.AppendLine("join MainCourse mc on mc.DietaryPlanId = dp.DietaryPlanId ");
            queryString.AppendLine("join PlanSnack ps on ps.DietaryPlanId = dp.DietaryPlanId ");
            queryString.AppendLine("where p.UserId = @UserId and p.PatientId = @PatientId ");
            queryString.AppendLine("order by p.LastAppointmentDate desc");

            SqlCommand sqlCmd = new SqlCommand(queryString.ToString());
            sqlCmd.Parameters.AddWithValue("@UserId", userId);
            sqlCmd.Parameters.AddWithValue("@PatientId", patientId);
            DataTable table = (DataTable)Execute(sqlCmd, TipoRetorno.TB, Transaccion.NoAcepta);

            DetailedPatientDto patientDto = new();

            if (table.Rows.Count == 0)
                return null;

            DataRow row = table.Rows[0];
            patientDto.PatientId = Convert.ToInt32(row["PatientId"]);
            patientDto.Name = row["Name"].ToString();
            patientDto.Surname = row["Surname"].ToString();
            patientDto.FirstAppointmentDate = Convert.ToDateTime(row["FirstAppointmentDate"]);
            patientDto.LastAppointmentDate = Convert.ToDateTime(row["LastAppointmentDate"]);
            patientDto.IsActive = Convert.ToBoolean(row["IsActive"]);

            patientDto.DietaryPlans = DietaryPlanQueryHandler.GetDietaryPlanDtos(table);

            return patientDto;
        }
    }
}
