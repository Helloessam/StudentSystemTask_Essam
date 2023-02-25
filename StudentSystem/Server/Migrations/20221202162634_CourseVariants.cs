using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentSystem.Server.Migrations
{
    /// <inheritdoc />
    public partial class CourseVariants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassID",
                table: "Courses");

            migrationBuilder.CreateTable(
                name: "CourseLecturers",
                columns: table => new
                {
                    lecturerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lecturerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseLecturers", x => x.lecturerId);
                });

            migrationBuilder.CreateTable(
                name: "CourseVariants",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    CourseLecturerId = table.Column<int>(type: "int", nullable: false),
                    ClassId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseVariants", x => new { x.CourseId, x.CourseLecturerId });
                    table.ForeignKey(
                        name: "FK_CourseVariants_CourseLecturers_CourseLecturerId",
                        column: x => x.CourseLecturerId,
                        principalTable: "CourseLecturers",
                        principalColumn: "lecturerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseVariants_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CourseLecturers",
                columns: new[] { "lecturerId", "lecturerName" },
                values: new object[,]
                {
                    { 1331, "Dr.Mohamed" },
                    { 1344, "Dr.Mostafa" },
                    { 3121, "Dr.Ola" },
                    { 3928, "Dr.Aly" },
                    { 4356, "Dr.Saad" },
                    { 5005, "Dr.Omar" },
                    { 9028, "Dr.Abdullah" }
                });

            migrationBuilder.InsertData(
                table: "CourseVariants",
                columns: new[] { "CourseId", "CourseLecturerId", "ClassId" },
                values: new object[,]
                {
                    { 135, 3121, "341A" },
                    { 135, 3928, "414B" },
                    { 155, 1331, "341A" },
                    { 155, 1344, "201C" },
                    { 284, 5005, "201G" },
                    { 284, 9028, "201G" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseVariants_CourseLecturerId",
                table: "CourseVariants",
                column: "CourseLecturerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseVariants");

            migrationBuilder.DropTable(
                name: "CourseLecturers");

            migrationBuilder.AddColumn<string>(
                name: "ClassID",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 104,
                column: "ClassID",
                value: "3C");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 109,
                column: "ClassID",
                value: "3C");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 135,
                column: "ClassID",
                value: "3C");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 145,
                column: "ClassID",
                value: "3C");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 155,
                column: "ClassID",
                value: "1B");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 284,
                column: "ClassID",
                value: "3MA");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 295,
                column: "ClassID",
                value: "1MA");
        }
    }
}
