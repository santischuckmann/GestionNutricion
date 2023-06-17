using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionNutricion.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DietaryPlan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observations = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Breakfast = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Lunch = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Dinner = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietaryPlan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Snack",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Food = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IntakeHour = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Snack", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanSnack",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDietaryPlan = table.Column<int>(type: "int", nullable: false),
                    Food = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IntakeHour = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanSnack", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanSnack_DietaryPlan_IdDietaryPlan",
                        column: x => x.IdDietaryPlan,
                        principalTable: "DietaryPlan",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanSnack_IdDietaryPlan",
                table: "PlanSnack",
                column: "IdDietaryPlan");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanSnack");

            migrationBuilder.DropTable(
                name: "Snack");

            migrationBuilder.DropTable(
                name: "DietaryPlan");
        }
    }
}
