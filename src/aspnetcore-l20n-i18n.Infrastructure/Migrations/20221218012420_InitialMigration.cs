using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspnetcore_l20n_i18n.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CorinthiansFan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "varchar(35)", maxLength: 35, nullable: false),
                    Address = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorinthiansFan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FootballMatch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameType = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1),
                    Adversary = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: false),
                    Stadium = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Away = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FootballMatch", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CorinthiansFan");

            migrationBuilder.DropTable(
                name: "FootballMatch");
        }
    }
}
