using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projectAPI.Migrations
{
    /// <inheritdoc />
    public partial class auth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1423cc9b-65d3-411e-8388-d67d1f910205", "1", "SuperAdmin", "SuperAdmin" },
                    { "8bd9f6d8-d207-4775-8918-be187a4cb8d7", "2", "Admin", "Admin" },
                    { "9038fbcf-8797-4b72-a0ff-72b48d987aa9", "3", "User", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1423cc9b-65d3-411e-8388-d67d1f910205");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8bd9f6d8-d207-4775-8918-be187a4cb8d7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9038fbcf-8797-4b72-a0ff-72b48d987aa9");
        }
    }
}
