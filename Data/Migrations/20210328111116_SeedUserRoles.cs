using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace vidly.Migrations
{
    public partial class SeedUserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("AspNetRoles", new string[] { "Id", "Name", "NormalizedName" }, new object[] { "1", "CanManageMovies", "CANMANAGEMOVIES" });
            migrationBuilder.InsertData("AspNetRoles", new string[] { "Id", "Name", "NormalizedName" }, new object[] { "2", "CanManageCustomer", "CANMANAGECUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
