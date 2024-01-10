using GestionNutricion.Infrastructure.DTOs.DietaryPlan;
using GestionNutricion.Infrastructure.DTOs.MainCourse;
using GestionNutricion.Infrastructure.DTOs.PlanSnack;
using GestionNutricion.Infrastructure.Extensions;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace GestionNutricion.Infrastructure.Query
{
    public class DietaryPlanQueryHandler : QueryHandler
    {
        public DietaryPlanQueryHandler(string connectionString) : base(connectionString)
        {

        }

        public DietaryPlanDto GetDietaryPlanById(int id)
        {
            string queryString = $"{GetSelectForDietaryPlanDto()} where dp.DietaryPlanId = @DietaryPlanId";

            SqlCommand sqlCmd = new SqlCommand(queryString);
            sqlCmd.Parameters.AddWithValue("@DietaryPlanId", id);
            DataTable table = (DataTable)Execute(sqlCmd, TipoRetorno.TB, Transaccion.NoAcepta);

            return MapDietaryPlan(table, id);
        }

        public List<DietaryPlanDto> GetAllDietaryPlans(int userId)
        {
            string queryString = $"{GetSelectForDietaryPlanDto()} where UserId = @UserId order by dp.DietaryPlanId desc";

            SqlCommand sqlCmd = new SqlCommand(queryString.ToString());
            sqlCmd.Parameters.AddWithValue("@UserId", userId);
            DataTable table = (DataTable)Execute(sqlCmd, TipoRetorno.TB, Transaccion.NoAcepta);

            return GetDietaryPlanDtos(table);
        }

        public static List<DietaryPlanDto> GetDietaryPlanDtos(DataTable table)
        {
            List<DietaryPlanDto> dietaryPlanDtos = new();

            List<DataRow>? distinctRowsPerDietaryPlan = table.Select().GetDistinctValues("DietaryPlanId");

            if (distinctRowsPerDietaryPlan == null)
                return dietaryPlanDtos;

            foreach (DataRow mainRow in distinctRowsPerDietaryPlan)
            {
                int dietaryPlanId = Convert.ToInt32(mainRow["DietaryPlanId"]);
                DietaryPlanDto dietaryPlanDto = MapDietaryPlan(table, dietaryPlanId);
                dietaryPlanDtos.Add(dietaryPlanDto);
            }

            return dietaryPlanDtos;
        }

        private static string GetSelectForDietaryPlanDto()
        {
            StringBuilder queryString = new StringBuilder();
            queryString.AppendLine("select dp.DietaryPlanId, dp.Breakfast, dp.Observations, ");
            queryString.AppendLine("mc.MainCourseId, mc.Food as MainCourseFood, mc.Dessert, mc.IdMainCourseType,");
            queryString.AppendLine("ps.PlanSnackId, ps.Food as PlanSnackFood, ps.IdSnackTime, ");
            queryString.AppendLine("Patient.Name, Patient.Surname ");
            queryString.AppendLine("from DietaryPlan dp ");
            queryString.AppendLine("join MainCourse mc on mc.DietaryPlanId = dp.DietaryPlanId ");
            queryString.AppendLine("join PlanSnack ps on ps.DietaryPlanId = dp.DietaryPlanId ");
            queryString.AppendLine("join Patient on Patient.PatientId = dp.PatientId ");

            return queryString.ToString();
        }


        private static DietaryPlanDto MapDietaryPlan(DataTable table, int dietaryPlanId)
        {
            DataRow[] rowsPerDietaryPlan = table.Select($"DietaryPlanId = '{dietaryPlanId}'");

            DietaryPlanDto dietaryPlanDto = new();
            dietaryPlanDto.DietaryPlanId = Convert.ToInt32(dietaryPlanId);
            dietaryPlanDto.Breakfast = rowsPerDietaryPlan[0]["Breakfast"].ToString();
            dietaryPlanDto.Name = rowsPerDietaryPlan[0]["Name"].ToString();
            dietaryPlanDto.Surname = rowsPerDietaryPlan[0]["Surname"].ToString();
            dietaryPlanDto.Observations = rowsPerDietaryPlan[0]["Observations"].ToString();

            var distinctMainCourseRows = rowsPerDietaryPlan.GetDistinctValues("MainCourseId");

            if (distinctMainCourseRows != null)
            {
                dietaryPlanDto.MainCourses = new();
                foreach (DataRow row in distinctMainCourseRows)
                {
                    MainCourseDto mainCourseDto = new();
                    mainCourseDto.Food = row["MainCourseFood"].ToString();
                    mainCourseDto.Dessert = row["Dessert"].ToString();
                    mainCourseDto.IdMainCourseType = Convert.ToInt32(row["IdMainCourseType"]);

                    dietaryPlanDto.MainCourses.Add(mainCourseDto);
                }

            }
            var distinctPlanSnackRows = rowsPerDietaryPlan.GetDistinctValues("PlanSnackId");

            if (distinctPlanSnackRows != null)
            {
                dietaryPlanDto.PlanSnacks = new();
                foreach (DataRow row in distinctPlanSnackRows)
                {
                    PlanSnackDto planSnackDto = new();
                    planSnackDto.Food = row["PlanSnackFood"].ToString();
                    planSnackDto.IdSnackTime = Convert.ToInt32(row["IdSnackTime"]);

                    dietaryPlanDto.PlanSnacks.Add(planSnackDto);
                }
            }

            return dietaryPlanDto;
        }
    }
}
