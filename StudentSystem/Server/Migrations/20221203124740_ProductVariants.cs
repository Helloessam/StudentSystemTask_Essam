using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentSystem.Server.Migrations
{
    /// <inheritdoc />
    public partial class ProductVariants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseVariants_Courses_CourseId",
                table: "CourseVariants");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "CourseVariants",
                newName: "courseId");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Courses",
                newName: "courseId");

            migrationBuilder.AddColumn<int>(
                name: "courseId",
                table: "CourseLecturers",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CourseLecturers",
                keyColumn: "lecturerId",
                keyValue: 1331,
                column: "courseId",
                value: null);

            migrationBuilder.UpdateData(
                table: "CourseLecturers",
                keyColumn: "lecturerId",
                keyValue: 1344,
                column: "courseId",
                value: null);

            migrationBuilder.UpdateData(
                table: "CourseLecturers",
                keyColumn: "lecturerId",
                keyValue: 3121,
                column: "courseId",
                value: null);

            migrationBuilder.UpdateData(
                table: "CourseLecturers",
                keyColumn: "lecturerId",
                keyValue: 3928,
                column: "courseId",
                value: null);

            migrationBuilder.UpdateData(
                table: "CourseLecturers",
                keyColumn: "lecturerId",
                keyValue: 4356,
                column: "courseId",
                value: null);

            migrationBuilder.UpdateData(
                table: "CourseLecturers",
                keyColumn: "lecturerId",
                keyValue: 5005,
                column: "courseId",
                value: null);

            migrationBuilder.UpdateData(
                table: "CourseLecturers",
                keyColumn: "lecturerId",
                keyValue: 9028,
                column: "courseId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_CourseLecturers_courseId",
                table: "CourseLecturers",
                column: "courseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseLecturers_Courses_courseId",
                table: "CourseLecturers",
                column: "courseId",
                principalTable: "Courses",
                principalColumn: "courseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseVariants_Courses_courseId",
                table: "CourseVariants",
                column: "courseId",
                principalTable: "Courses",
                principalColumn: "courseId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseLecturers_Courses_courseId",
                table: "CourseLecturers");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseVariants_Courses_courseId",
                table: "CourseVariants");

            migrationBuilder.DropIndex(
                name: "IX_CourseLecturers_courseId",
                table: "CourseLecturers");

            migrationBuilder.DropColumn(
                name: "courseId",
                table: "CourseLecturers");

            migrationBuilder.RenameColumn(
                name: "courseId",
                table: "CourseVariants",
                newName: "CourseId");

            migrationBuilder.RenameColumn(
                name: "courseId",
                table: "Courses",
                newName: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseVariants_Courses_CourseId",
                table: "CourseVariants",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
