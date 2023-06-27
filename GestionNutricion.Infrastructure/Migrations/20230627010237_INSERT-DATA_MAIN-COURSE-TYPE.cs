using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionNutricion.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class INSERTDATA_MAINCOURSETYPE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"
                    SET IDENTITY_INSERT [dbo].[MainCourseType] ON;
                    
                    INSERT INTO [dbo].[MainCourseType]([Id],[Description]) Values 
                        (1,'Lunch'),
                        (2,'Dinner');

                    SET IDENTITY_INSERT [dbo].[MainCourseType] OFF";

            migrationBuilder.Sql(sql);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
