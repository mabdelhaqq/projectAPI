using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectAPI.Migrations
{
    /// <inheritdoc />
    public partial class newref : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
           name: "FirstName",
           table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
