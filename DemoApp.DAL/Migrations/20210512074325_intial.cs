using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoApp.DAL.Migrations
{
    public partial class intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<string>(type: "Varchar(10)", nullable: false),
                    CityName = table.Column<string>(type: "Varchar(50)", nullable: true),
                    CountryId = table.Column<string>(type: "Varchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<string>(type: "Varchar(10)", nullable: false),
                    CountryName = table.Column<string>(type: "Varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "Varchar(100)", nullable: false),
                    UserName = table.Column<string>(type: "Varchar(100)", nullable: false),
                    Password = table.Column<string>(type: "Varchar(25)", nullable: false),
                    Contcat = table.Column<string>(type: "Varchar(10)", nullable: true),
                    Country = table.Column<string>(type: "Varchar(10)", nullable: false),
                    City = table.Column<string>(type: "Varchar(10)", nullable: false),
                    Gender = table.Column<string>(type: "Varchar(6)", nullable: false),
                    Terms = table.Column<bool>(type: "Bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
