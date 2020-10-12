using Microsoft.EntityFrameworkCore.Migrations;

namespace squittal.MatchReportPlanetmans.Migrations
{
    public partial class AddAliasToConstructedTeamMembershipModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Alias",
                table: "ConstructedTeamPlayerMembership",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alias",
                table: "ConstructedTeamPlayerMembership");
        }
    }
}
