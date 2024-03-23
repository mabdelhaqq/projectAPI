using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projectAPI.Migrations
{
    /// <inheritdoc />
    public partial class lgrg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2bdf5d9a-34b0-47f3-b330-204685bf05b4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31d76d1a-64f8-4d2a-a4fb-5389e20822df");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b4e41d4-aa2b-47fa-a0a8-957983376526");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "418a718e-9338-4203-8cc6-979047677530", "3", "User", "User" },
                    { "8c10fb93-2a1c-4de0-a0b3-0d81cdcb5fe5", "1", "SuperAdmin", "SuperAdmin" },
                    { "e37e7bbc-6753-4f9d-ac13-cb251784f0ce", "2", "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "418a718e-9338-4203-8cc6-979047677530");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c10fb93-2a1c-4de0-a0b3-0d81cdcb5fe5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e37e7bbc-6753-4f9d-ac13-cb251784f0ce");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2bdf5d9a-34b0-47f3-b330-204685bf05b4", "1", "SuperAdmin", "SuperAdmin" },
                    { "31d76d1a-64f8-4d2a-a4fb-5389e20822df", "3", "User", "User" },
                    { "3b4e41d4-aa2b-47fa-a0a8-957983376526", "2", "Admin", "Admin" }
                });
        }
    }
}
