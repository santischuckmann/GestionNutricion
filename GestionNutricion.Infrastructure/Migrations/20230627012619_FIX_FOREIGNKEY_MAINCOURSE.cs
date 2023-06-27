using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionNutricion.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FIX_FOREIGNKEY_MAINCOURSE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DietaryPlan_MainCourseType_MainCourseTypeId",
                table: "DietaryPlan");

            migrationBuilder.DropForeignKey(
                name: "FK_MainCourse_MainCourseType_MainCourseTypeId",
                table: "MainCourse");

            migrationBuilder.DropIndex(
                name: "IX_MainCourse_MainCourseTypeId",
                table: "MainCourse");

            migrationBuilder.DropIndex(
                name: "IX_DietaryPlan_MainCourseTypeId",
                table: "DietaryPlan");

            migrationBuilder.DropColumn(
                name: "MainCourseTypeId",
                table: "MainCourse");

            migrationBuilder.DropColumn(
                name: "MainCourseTypeId",
                table: "DietaryPlan");

            migrationBuilder.CreateIndex(
                name: "IX_MainCourse_IdMainCourseType",
                table: "MainCourse",
                column: "IdMainCourseType");

            migrationBuilder.AddForeignKey(
                name: "FK_MainCourse_MainCourseType_IdMainCourseType",
                table: "MainCourse",
                column: "IdMainCourseType",
                principalTable: "MainCourseType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainCourse_MainCourseType_IdMainCourseType",
                table: "MainCourse");

            migrationBuilder.DropIndex(
                name: "IX_MainCourse_IdMainCourseType",
                table: "MainCourse");

            migrationBuilder.AddColumn<int>(
                name: "MainCourseTypeId",
                table: "MainCourse",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MainCourseTypeId",
                table: "DietaryPlan",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MainCourse_MainCourseTypeId",
                table: "MainCourse",
                column: "MainCourseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DietaryPlan_MainCourseTypeId",
                table: "DietaryPlan",
                column: "MainCourseTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DietaryPlan_MainCourseType_MainCourseTypeId",
                table: "DietaryPlan",
                column: "MainCourseTypeId",
                principalTable: "MainCourseType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MainCourse_MainCourseType_MainCourseTypeId",
                table: "MainCourse",
                column: "MainCourseTypeId",
                principalTable: "MainCourseType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
