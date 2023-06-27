using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionNutricion.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class INSERTDATA_SNACKTIME : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"
                    SET IDENTITY_INSERT [dbo].[SnackTime] ON;
                    
                    INSERT INTO [dbo].[SnackTime]([Id],[Description]) Values 
                        (1, 'BreakfastAndLunch'),
                        (2, 'AfternoonSnack'),
                        (3, 'BeforeDinner'),
                        (4, 'ExactTime');

                    SET IDENTITY_INSERT [dbo].[SnackTime] OFF";

            migrationBuilder.Sql(sql);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
