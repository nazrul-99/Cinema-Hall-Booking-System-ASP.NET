using Microsoft.EntityFrameworkCore.Migrations;

namespace eCommerce.Migrations
{
    public partial class fixing_movie_database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Producers_PrducerID",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "Fullname",
                table: "Producers",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "PrducerID",
                table: "Movies",
                newName: "ProducerID");

            migrationBuilder.RenameColumn(
                name: "MovieCatagory",
                table: "Movies",
                newName: "MovieCategory");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_PrducerID",
                table: "Movies",
                newName: "IX_Movies_ProducerID");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Movies",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Producers_ProducerID",
                table: "Movies",
                column: "ProducerID",
                principalTable: "Producers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Producers_ProducerID",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Producers",
                newName: "Fullname");

            migrationBuilder.RenameColumn(
                name: "ProducerID",
                table: "Movies",
                newName: "PrducerID");

            migrationBuilder.RenameColumn(
                name: "MovieCategory",
                table: "Movies",
                newName: "MovieCatagory");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_ProducerID",
                table: "Movies",
                newName: "IX_Movies_PrducerID");

            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Producers_PrducerID",
                table: "Movies",
                column: "PrducerID",
                principalTable: "Producers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
