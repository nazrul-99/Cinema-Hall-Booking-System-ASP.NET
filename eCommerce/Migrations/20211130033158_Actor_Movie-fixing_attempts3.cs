using Microsoft.EntityFrameworkCore.Migrations;

namespace eCommerce.Migrations
{
    public partial class Actor_Moviefixing_attempts3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actors_Movies_Actors_Movies_Actor_MovieActorID_Actor_MovieMovieID",
                table: "Actors_Movies");

            migrationBuilder.DropIndex(
                name: "IX_Actors_Movies_Actor_MovieActorID_Actor_MovieMovieID",
                table: "Actors_Movies");

            migrationBuilder.DropColumn(
                name: "Actor_MovieActorID",
                table: "Actors_Movies");

            migrationBuilder.DropColumn(
                name: "Actor_MovieMovieID",
                table: "Actors_Movies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Actor_MovieActorID",
                table: "Actors_Movies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Actor_MovieMovieID",
                table: "Actors_Movies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Actors_Movies_Actor_MovieActorID_Actor_MovieMovieID",
                table: "Actors_Movies",
                columns: new[] { "Actor_MovieActorID", "Actor_MovieMovieID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Actors_Movies_Actors_Movies_Actor_MovieActorID_Actor_MovieMovieID",
                table: "Actors_Movies",
                columns: new[] { "Actor_MovieActorID", "Actor_MovieMovieID" },
                principalTable: "Actors_Movies",
                principalColumns: new[] { "ActorID", "MovieID" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
