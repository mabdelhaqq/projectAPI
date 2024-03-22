using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projectAPI.Migrations
{
    /// <inheritdoc />
    public partial class stusubuni : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StudentSubject_StudentId",
                table: "StudentSubject");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "271a3bc8-b78d-4b1f-b0a3-4505993c61cb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e7b0db4-2c0d-48ab-bce9-cd7ebbfacf24");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5726141d-8851-4d28-88fe-7fad37cd7eae");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "34b5b966-411b-4845-abd5-715a9afa603b", "2", "Admin", "Admin" },
                    { "73fa7f98-f290-431d-acb2-fd1d0d8c89db", "3", "User", "User" },
                    { "a0816190-372c-4a52-a5f2-591e838ee005", "1", "SuperAdmin", "SuperAdmin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubject_StudentId_SubjectId",
                table: "StudentSubject",
                columns: new[] { "StudentId", "SubjectId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StudentSubject_StudentId_SubjectId",
                table: "StudentSubject");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "34b5b966-411b-4845-abd5-715a9afa603b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73fa7f98-f290-431d-acb2-fd1d0d8c89db");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0816190-372c-4a52-a5f2-591e838ee005");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "271a3bc8-b78d-4b1f-b0a3-4505993c61cb", "2", "Admin", "Admin" },
                    { "4e7b0db4-2c0d-48ab-bce9-cd7ebbfacf24", "1", "SuperAdmin", "SuperAdmin" },
                    { "5726141d-8851-4d28-88fe-7fad37cd7eae", "3", "User", "User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubject_StudentId",
                table: "StudentSubject",
                column: "StudentId");
        }
    }
}
