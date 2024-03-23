using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projectAPI.Migrations
{
    /// <inheritdoc />
    public partial class editreg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "5e962f53-fc6c-4c00-8c38-44ed89412f92", "3", "User", "User" },
                    { "d1ea92fd-a428-4054-b7b6-35e3f5339d45", "1", "SuperAdmin", "SuperAdmin" },
                    { "eaa25fc4-d18c-4e9b-889b-8e3d76ac0371", "2", "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e962f53-fc6c-4c00-8c38-44ed89412f92");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1ea92fd-a428-4054-b7b6-35e3f5339d45");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eaa25fc4-d18c-4e9b-889b-8e3d76ac0371");

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
    }
}
