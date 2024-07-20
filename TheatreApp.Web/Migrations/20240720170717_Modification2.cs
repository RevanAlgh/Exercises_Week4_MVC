using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheatreApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class Modification2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoviesAuthors_Authors_AuthorID",
                table: "MoviesAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_MoviesAuthors_Movies_MovieID",
                table: "MoviesAuthors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MoviesAuthors",
                table: "MoviesAuthors");

            migrationBuilder.RenameTable(
                name: "MoviesAuthors",
                newName: "MovieAuthors");

            migrationBuilder.RenameIndex(
                name: "IX_MoviesAuthors_AuthorID",
                table: "MovieAuthors",
                newName: "IX_MovieAuthors_AuthorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieAuthors",
                table: "MovieAuthors",
                columns: new[] { "MovieID", "AuthorID" });

            migrationBuilder.AddForeignKey(
                name: "FK_MovieAuthors_Authors_AuthorID",
                table: "MovieAuthors",
                column: "AuthorID",
                principalTable: "Authors",
                principalColumn: "AuthorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieAuthors_Movies_MovieID",
                table: "MovieAuthors",
                column: "MovieID",
                principalTable: "Movies",
                principalColumn: "MovieID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieAuthors_Authors_AuthorID",
                table: "MovieAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieAuthors_Movies_MovieID",
                table: "MovieAuthors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieAuthors",
                table: "MovieAuthors");

            migrationBuilder.RenameTable(
                name: "MovieAuthors",
                newName: "MoviesAuthors");

            migrationBuilder.RenameIndex(
                name: "IX_MovieAuthors_AuthorID",
                table: "MoviesAuthors",
                newName: "IX_MoviesAuthors_AuthorID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MoviesAuthors",
                table: "MoviesAuthors",
                columns: new[] { "MovieID", "AuthorID" });

            migrationBuilder.AddForeignKey(
                name: "FK_MoviesAuthors_Authors_AuthorID",
                table: "MoviesAuthors",
                column: "AuthorID",
                principalTable: "Authors",
                principalColumn: "AuthorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoviesAuthors_Movies_MovieID",
                table: "MoviesAuthors",
                column: "MovieID",
                principalTable: "Movies",
                principalColumn: "MovieID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
