using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projectAPI.Migrations
{
    /// <inheritdoc />
    public partial class lgnreg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { "2bdf5d9a-34b0-47f3-b330-204685bf05b4", "1", "SuperAdmin", "SuperAdmin" },
                    { "31d76d1a-64f8-4d2a-a4fb-5389e20822df", "3", "User", "User" },
                    { "3b4e41d4-aa2b-47fa-a0a8-957983376526", "2", "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "34b5b966-411b-4845-abd5-715a9afa603b", "2", "Admin", "Admin" },
                    { "73fa7f98-f290-431d-acb2-fd1d0d8c89db", "3", "User", "User" },
                    { "a0816190-372c-4a52-a5f2-591e838ee005", "1", "SuperAdmin", "SuperAdmin" }
                });
        }
    }
}
