using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cars.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddCarImageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Cars");

            migrationBuilder.CreateTable(
                name: "CarImgs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarImgs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarImgs_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarImgs_CarId",
                table: "CarImgs",
                column: "CarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarImgs");

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
