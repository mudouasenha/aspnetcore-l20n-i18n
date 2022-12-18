using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspnetcore_l20n_i18n.Infrastructure.Migrations
{
    public partial class AddAccountBalance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AccountBalance",
                table: "CorinthiansFan",
                type: "numeric(19,5)",
                precision: 19,
                scale: 5,
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountBalance",
                table: "CorinthiansFan");
        }
    }
}
