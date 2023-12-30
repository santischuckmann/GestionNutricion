using CedServicios.Infraestructura.Extensiones;
using GestionNutricion.Core.Entitys;
using GestionNutricion.Infrastructure.DTOs.DietaryPlan;
using GestionNutricion.Infrastructure.DTOs.MainCourse;
using GestionNutricion.Infrastructure.DTOs.Snack;
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

            List<DataRow>? distinctRowsPerDietaryPlan = table.Select().GetDistinctValues("DietaryPlanId");

            if (distinctRowsPerDietaryPlan == null)
                return dietaryPlanDtos;

            foreach (DataRow mainRow in distinctRowsPerDietaryPlan)
            {
                
                int dietaryPlanId = Convert.ToInt32(mainRow["DietaryPlanId"]);

                DietaryPlanDto dietaryPlanDto = new();
                dietaryPlanDto.DietaryPlanId = Convert.ToInt32(dietaryPlanId);
                dietaryPlanDto.Breakfast = table.Rows[0]["Breakfast"].ToString();
                dietaryPlanDto.Name = table.Rows[0]["Name"].ToString();
                dietaryPlanDto.Surname = table.Rows[0]["Surname"].ToString();

                DataRow[] rowsPerDietaryPlan = table.Select($"DietaryPlanId = '{dietaryPlanId}'");

                var distinctMainCourseRows = rowsPerDietaryPlan.GetDistinctValues("MainCourseId");

                if (distinctMainCourseRows != null)
                {
                    dietaryPlanDto.MainCourses = new();
                    foreach (DataRow row in distinctMainCourseRows)
                    {
                        MainCourseDto mainCourseDto = new();
                        mainCourseDto.Food = row["Food"].ToString();
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
                        planSnackDto.Food = row["Food"].ToString();
                        planSnackDto.IdSnackTime = Convert.ToInt32(row["IdSnackTime"]);

                        dietaryPlanDto.PlanSnacks.Add(planSnackDto);
                    }
                }

                dietaryPlanDtos.Add(dietaryPlanDto);
            }

            return dietaryPlanDtos;
        }
    }
}
