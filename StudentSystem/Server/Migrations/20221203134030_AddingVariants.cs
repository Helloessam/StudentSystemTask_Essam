using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentSystem.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddingVariants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CourseVariants",
                columns: new[] { "CourseLecturerId", "courseId", "ClassId" },
                values: new object[,]
                {
                    { 4356, 104, "405A" },
                    { 5005, 109, "100G" },
                    { 1344, 145, "545A" },
                    { 3121, 295, "101G" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CourseVariants",
                keyColumns: new[] { "CourseLecturerId", "courseId" },
                keyValues: new object[] { 4356, 104 });

            migrationBuilder.DeleteData(
                table: "CourseVariants",
                keyColumns: new[] { "CourseLecturerId", "courseId" },
                keyValues: new object[] { 5005, 109 });

            migrationBuilder.DeleteData(
                table: "CourseVariants",
                keyColumns: new[] { "CourseLecturerId", "courseId" },
                keyValues: new object[] { 1344, 145 });

            migrationBuilder.DeleteData(
                table: "CourseVariants",
                keyColumns: new[] { "CourseLecturerId", "courseId" },
                keyValues: new object[] { 3121, 295 });
        }
    }
}
