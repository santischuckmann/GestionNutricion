using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionNutricion.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addsnacks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"

                 INSERT INTO [dbo].[Snack]([Food],[IntakeHour]) Values ('Fruta', '10:00:00'), 
                                                                       ('Barra de cereal', '15:00:00'),
                                                                       ('Licuado de banana', '19:00:00')";
            migrationBuilder.Sql(sql);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
