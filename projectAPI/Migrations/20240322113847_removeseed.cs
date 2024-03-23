using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projectAPI.Migrations
{
    /// <inheritdoc />
    public partial class removeseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
