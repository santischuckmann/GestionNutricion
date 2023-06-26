using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionNutricion.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DELETE_DIETARYPLAN_INTS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdDinner",
                table: "DietaryPlan");

            migrationBuilder.DropColumn(
                name: "IdLunch",
                table: "DietaryPlan");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdDinner",
                table: "DietaryPlan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdLunch",
                table: "DietaryPlan",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
