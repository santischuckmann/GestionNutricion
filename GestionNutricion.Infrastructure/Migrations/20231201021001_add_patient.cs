using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionNutricion.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_patient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "DietaryPlan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    FirstAppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastAppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                });

            var insertPatient = @"
                    insert into [dbo].[Patient] values ('Santiago', 'Schuckmann', getdate(), getdate(), 1);
            ";

            migrationBuilder.Sql(insertPatient);

            var updateDietaryPlans = @"
                    update [dbo].[DietaryPlan] set [PatientId] = 1
            ";

            migrationBuilder.Sql(updateDietaryPlans);

            migrationBuilder.CreateIndex(
                name: "IX_DietaryPlan_PatientId",
                table: "DietaryPlan",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_DietaryPlan_Patient_PatientId",
                table: "DietaryPlan",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DietaryPlan_Patient_PatientId",
                table: "DietaryPlan");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropIndex(
                name: "IX_DietaryPlan_PatientId",
                table: "DietaryPlan");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "DietaryPlan");
        }
    }
}
