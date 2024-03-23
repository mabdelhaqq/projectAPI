using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projectAPI.Migrations
{
    /// <inheritdoc />
    public partial class editreg2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "03062ae3-8c18-4736-92ec-8a258b02f1c2", "2", "Admin", "Admin" },
                    { "2ead8416-38bd-4c23-b1bc-fa495ed1fc4d", "1", "SuperAdmin", "SuperAdmin" },
                    { "fb782c39-25b6-4db7-ae6f-c7f0b72a202f", "3", "User", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03062ae3-8c18-4736-92ec-8a258b02f1c2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ead8416-38bd-4c23-b1bc-fa495ed1fc4d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb782c39-25b6-4db7-ae6f-c7f0b72a202f");

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
    }
}
