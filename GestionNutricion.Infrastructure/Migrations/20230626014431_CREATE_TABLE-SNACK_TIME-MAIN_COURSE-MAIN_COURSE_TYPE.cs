using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionNutricion.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CREATE_TABLESNACK_TIMEMAIN_COURSEMAIN_COURSE_TYPE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IntakeHour",
                table: "Snack");

            migrationBuilder.DropColumn(
                name: "IntakeHour",
                table: "PlanSnack");

            migrationBuilder.DropColumn(
                name: "Dinner",
                table: "DietaryPlan");

            migrationBuilder.DropColumn(
                name: "Lunch",
                table: "DietaryPlan");

            migrationBuilder.AddColumn<int>(
                name: "IdSnackTime",
                table: "Snack",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdSnackTime",
                table: "PlanSnack",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Observations",
                table: "DietaryPlan",
                type: "varchar(256)",
                unicode: false,
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Breakfast",
                table: "DietaryPlan",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50);

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

            migrationBuilder.AddColumn<int>(
                name: "MainCourseTypeId",
                table: "DietaryPlan",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MainCourseType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainCourseType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SnackTime",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SnackTime", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MainCourse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMainCourseType = table.Column<int>(type: "int", nullable: false),
                    Food = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Dessert = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IdDietaryPlan = table.Column<int>(type: "int", nullable: false),
                    MainCourseTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainCourse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MainCourse_DietaryPlan_IdDietaryPlan",
                        column: x => x.IdDietaryPlan,
                        principalTable: "DietaryPlan",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MainCourse_MainCourseType_MainCourseTypeId",
                        column: x => x.MainCourseTypeId,
                        principalTable: "MainCourseType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Snack_IdSnackTime",
                table: "Snack",
                column: "IdSnackTime");

            migrationBuilder.CreateIndex(
                name: "IX_PlanSnack_IdSnackTime",
                table: "PlanSnack",
                column: "IdSnackTime");

            migrationBuilder.CreateIndex(
                name: "IX_DietaryPlan_MainCourseTypeId",
                table: "DietaryPlan",
                column: "MainCourseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MainCourse_IdDietaryPlan",
                table: "MainCourse",
                column: "IdDietaryPlan");

            migrationBuilder.CreateIndex(
                name: "IX_MainCourse_MainCourseTypeId",
                table: "MainCourse",
                column: "MainCourseTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DietaryPlan_MainCourseType_MainCourseTypeId",
                table: "DietaryPlan",
                column: "MainCourseTypeId",
                principalTable: "MainCourseType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanSnack_SnackTime_IdSnackTime",
                table: "PlanSnack",
                column: "IdSnackTime",
                principalTable: "SnackTime",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Snack_SnackTime_IdSnackTime",
                table: "Snack",
                column: "IdSnackTime",
                principalTable: "SnackTime",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DietaryPlan_MainCourseType_MainCourseTypeId",
                table: "DietaryPlan");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanSnack_SnackTime_IdSnackTime",
                table: "PlanSnack");

            migrationBuilder.DropForeignKey(
                name: "FK_Snack_SnackTime_IdSnackTime",
                table: "Snack");

            migrationBuilder.DropTable(
                name: "MainCourse");

            migrationBuilder.DropTable(
                name: "SnackTime");

            migrationBuilder.DropTable(
                name: "MainCourseType");

            migrationBuilder.DropIndex(
                name: "IX_Snack_IdSnackTime",
                table: "Snack");

            migrationBuilder.DropIndex(
                name: "IX_PlanSnack_IdSnackTime",
                table: "PlanSnack");

            migrationBuilder.DropIndex(
                name: "IX_DietaryPlan_MainCourseTypeId",
                table: "DietaryPlan");

            migrationBuilder.DropColumn(
                name: "IdSnackTime",
                table: "Snack");

            migrationBuilder.DropColumn(
                name: "IdSnackTime",
                table: "PlanSnack");

            migrationBuilder.DropColumn(
                name: "IdDinner",
                table: "DietaryPlan");

            migrationBuilder.DropColumn(
                name: "IdLunch",
                table: "DietaryPlan");

            migrationBuilder.DropColumn(
                name: "MainCourseTypeId",
                table: "DietaryPlan");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "IntakeHour",
                table: "Snack",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "IntakeHour",
                table: "PlanSnack",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AlterColumn<string>(
                name: "Observations",
                table: "DietaryPlan",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(256)",
                oldUnicode: false,
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Breakfast",
                table: "DietaryPlan",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "Dinner",
                table: "DietaryPlan",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Lunch",
                table: "DietaryPlan",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
