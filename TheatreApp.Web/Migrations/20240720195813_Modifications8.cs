using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheatreApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class Modifications8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AdminName",
                table: "AspNetUsers",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "AspNetUsers",
                newName: "AdminName");
        }
    }
}
