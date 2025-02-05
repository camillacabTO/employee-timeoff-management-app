using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeeTimeOffManagementApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingUsersAndRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "08e78b51-7355-4e8a-a60b-ede12f13989a", null, "Employee", "EMPLOYEE" },
                    { "29de083d-bfe5-4ad4-af3a-b5e9a055c9df", null, "Admin", "ADMIN" },
                    { "fc428a4b-4f52-457e-bbbe-a169fe994663", null, "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "408aa945-3d84-4421-8342-7269ec64d949", 0, "da70afc5-7c9e-4057-92f3-af18e839d9e1", "admin@localhost.com", true, false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEKpmFFVFnFw0A1HkQxHmMFzrVCjS5eTILoajLXcV2p76KpDADpB9T3d/eWYe8GeDJA==", null, false, "32afbe4a-9f10-4a81-81d6-f4bc125930a4", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "29de083d-bfe5-4ad4-af3a-b5e9a055c9df", "408aa945-3d84-4421-8342-7269ec64d949" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08e78b51-7355-4e8a-a60b-ede12f13989a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc428a4b-4f52-457e-bbbe-a169fe994663");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "29de083d-bfe5-4ad4-af3a-b5e9a055c9df", "408aa945-3d84-4421-8342-7269ec64d949" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29de083d-bfe5-4ad4-af3a-b5e9a055c9df");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "408aa945-3d84-4421-8342-7269ec64d949");
        }
    }
}
