using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectAPI.Migrations
{
    /// <inheritdoc />
    public partial class editstu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_students",
                table: "students");

            migrationBuilder.RenameTable(
                name: "students",
                newName: "Student");

            migrationBuilder.RenameColumn(
                name: "StudentID",
                table: "Student",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                table: "Student",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                table: "Student");

            migrationBuilder.RenameTable(
                name: "Student",
                newName: "students");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "students",
                newName: "StudentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_students",
                table: "students",
                column: "StudentID");
        }
    }
}
