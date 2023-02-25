using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentSystem.Server.Migrations
{
    /// <inheritdoc />
    public partial class ScheduleItemEdit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ScheduleItem",
                table: "ScheduleItem");

            migrationBuilder.RenameTable(
                name: "ScheduleItem",
                newName: "ScheduleItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScheduleItems",
                table: "ScheduleItems",
                columns: new[] { "UserId", "CourseId", "LecturerId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ScheduleItems",
                table: "ScheduleItems");

            migrationBuilder.RenameTable(
                name: "ScheduleItems",
                newName: "ScheduleItem");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScheduleItem",
                table: "ScheduleItem",
                columns: new[] { "UserId", "CourseId", "LecturerId" });
        }
    }
}
