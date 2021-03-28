using Microsoft.EntityFrameworkCore.Migrations;

namespace vidly.Migrations
{
    public partial class SeedMembershipTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("MembershipType", new[] { "Id", "SignUpFee", "DurationInMonths", "DiscountRate" }, new object[] { 1, 0, 0, 0 });
            migrationBuilder.InsertData("MembershipType", new[] { "Id", "SignUpFee", "DurationInMonths", "DiscountRate" }, new object[] { 2, 30, 1, 10 });
            migrationBuilder.InsertData("MembershipType", new[] { "Id", "SignUpFee", "DurationInMonths", "DiscountRate" }, new object[] { 3, 90, 3, 15 });
            migrationBuilder.InsertData("MembershipType", new[] { "Id", "SignUpFee", "DurationInMonths", "DiscountRate" }, new object[] { 4, 300, 15, 30 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
