using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeTimeOffManagementApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class replaceUserIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d3e0606-f3b8-4ae2-ba92-7a77b227889b", new DateOnly(1990, 12, 1), "Default", "Admin", "AQAAAAIAAYagAAAAED9hsRex9GvYpBfyhBq6s4MJS3qP9sqq3k8mFY++fKLhrGYksgWK3JBSXFRnsACljQ==", "235b055d-b94e-4c8d-9e21-6b8f49c6463b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da70afc5-7c9e-4057-92f3-af18e839d9e1", "AQAAAAIAAYagAAAAEKpmFFVFnFw0A1HkQxHmMFzrVCjS5eTILoajLXcV2p76KpDADpB9T3d/eWYe8GeDJA==", "32afbe4a-9f10-4a81-81d6-f4bc125930a4" });
        }
    }
}
