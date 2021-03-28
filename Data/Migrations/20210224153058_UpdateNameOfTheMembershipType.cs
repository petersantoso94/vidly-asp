using Microsoft.EntityFrameworkCore.Migrations;

namespace vidly.Migrations
{
    public partial class UpdateNameOfTheMembershipType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData("MembershipType", "Id", 1, "Name", "Bronze");
            migrationBuilder.UpdateData("MembershipType", "Id", 2, "Name", "Silver");
            migrationBuilder.UpdateData("MembershipType", "Id", 3, "Name", "Gold");
            migrationBuilder.UpdateData("MembershipType", "Id", 4, "Name", "Platinum");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
