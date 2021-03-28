using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace vidly.Migrations
{
    public partial class SeedUserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("AspNetRoles", new string[] { "Id", "Name" }, new object[] { "1", "CanManageMovies" });
            migrationBuilder.InsertData("AspNetRoles", new string[] { "Id", "Name" }, new object[] { "2", "CanManageCustomer" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
