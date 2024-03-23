using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projectAPI.Migrations
{
    /// <inheritdoc />
    public partial class newrole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "49aed0b6-90ae-455d-ab11-68acd8bf8601", "1", "Admin", "Admin" },
                    { "903b1cb2-2177-49fb-acbc-fbdda6672879", "2", "User", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49aed0b6-90ae-455d-ab11-68acd8bf8601");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "903b1cb2-2177-49fb-acbc-fbdda6672879");
        }
    }
}
