using GestionNutricion.Infrastructure.DTOs.DietaryPlan;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace GestionNutricion.Infrastructure.Query
{
    public class DietaryPlanQueryHandler: QueryHandler
    {
        public DietaryPlanQueryHandler(string connectionString): base(connectionString)
        {

        }

        public List<DietaryPlanDto> GetAllDietaryPlans(int userId)
        {
            StringBuilder queryString = new StringBuilder();
            queryString.AppendLine("select * from DietaryPlan ");
            queryString.AppendLine("join MainCourse on MainCourse.DietaryPlanId = DietaryPlan.DietaryPlanId ");
            queryString.AppendLine("join PlanSnack on PlanSnack.DietaryPlanId = DietaryPlan.DietaryPlanId ");
            queryString.AppendLine("join Patient on Patient.PatientId = DietaryPlan.PatientId ");
            queryString.AppendLine("where UserId = @UserId ");

            SqlCommand sqlCmd = new SqlCommand(queryString.ToString());
            sqlCmd.Parameters.AddWithValue("@UserId", userId);
            DataTable table = (DataTable)Execute(sqlCmd, TipoRetorno.TB, Transaccion.NoAcepta);

            List<DietaryPlanDto> dietaryPlanDtos = new();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DietaryPlanDto dietaryPlanDto = new();
                dietaryPlanDto.MainCourses = new();
                dietaryPlanDto.PlanSnacks = new();


                dietaryPlanDto.Breakfast = table.Rows[0]["Breakfast"].ToString();
                dietaryPlanDto.Name = table.Rows[0]["Name"].ToString();
                dietaryPlanDto.Surname = table.Rows[0]["Surname"].ToString();

                dietaryPlanDtos.Add(dietaryPlanDto);
            }

            return dietaryPlanDtos;
        }
    }
}
