using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentSystem.Server.Migrations
{
    /// <inheritdoc />
    public partial class CreateInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepratmentId = table.Column<int>(type: "int", nullable: false),
                    Depratment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LecturerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false),
                    Timeslot = table.Column<int>(type: "int", nullable: false),
                    CreditHours = table.Column<int>(type: "int", nullable: false),
                    ClassID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "ClassID", "CourseName", "CreditHours", "Day", "Depratment", "DepratmentId", "LecturerName", "Timeslot" },
                values: new object[,]
                {
                    { 104, "3C", "Economy", 3, 2, "Computer Engineering", 1, "Dr.Saad", 2 },
                    { 109, "3C", "Statistics", 3, 3, "Mechanical Engineering", 2, "Dr.Omar", 4 },
                    { 135, "3C", "C++ Programming", 3, 1, "Computer Engineering", 1, "Dr.Aly", 3 },
                    { 145, "3C", "Java Programming", 3, 1, "Computer Engineering", 1, "Dr.Mostafa", 2 },
                    { 155, "1B", "Python Programming", 3, 1, "Computer Engineering", 1, "Dr.Mohammed", 1 },
                    { 284, "3MA", "Dynamics", 3, 2, "Mechanical Engineering", 2, "Dr.Abdullah", 3 },
                    { 295, "1MA", "Maths", 3, 2, "Mechanical Engineering", 2, "Dr.Ola", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
