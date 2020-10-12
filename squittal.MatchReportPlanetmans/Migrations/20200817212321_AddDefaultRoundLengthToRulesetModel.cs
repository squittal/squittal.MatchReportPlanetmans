using Microsoft.EntityFrameworkCore.Migrations;

namespace squittal.MatchReportPlanetmans.Migrations
{
    public partial class AddDefaultRoundLengthToRulesetModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DefaultRoundLength",
                table: "Ruleset",
                nullable: false,
                defaultValue: 900);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultRoundLength",
                table: "Ruleset");
        }
    }
}
