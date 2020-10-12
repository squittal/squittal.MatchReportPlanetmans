using Microsoft.EntityFrameworkCore.Migrations;

namespace squittal.MatchReportPlanetmans.Migrations
{
    public partial class AddRulesetSourceFileColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SourceFile",
                table: "Ruleset",
                nullable: true,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SourceFile",
                table: "Ruleset");
        }
    }
}
