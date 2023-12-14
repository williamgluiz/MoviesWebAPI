using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class SessionandMovieTheater : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieTheaterId",
                table: "Sessions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_MovieTheaterId",
                table: "Sessions",
                column: "MovieTheaterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_MovieTheaters_MovieTheaterId",
                table: "Sessions",
                column: "MovieTheaterId",
                principalTable: "MovieTheaters",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_MovieTheaters_MovieTheaterId",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_MovieTheaterId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "MovieTheaterId",
                table: "Sessions");
        }
    }
}
