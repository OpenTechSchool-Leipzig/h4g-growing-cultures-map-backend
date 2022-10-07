using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hack4good.Infrastructure.Data.Migrations
{
    public partial class Role : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "TokenSession",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "Account",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "IsAdmin", "Login", "Password" },
                values: new object[,]
                {
                    { new Guid("7d0f8501-a76c-4f1c-90ad-5ef95b93dee1"), false, "user", "user" },
                    { new Guid("c040c031-c485-4925-942a-c7cdbef231fa"), true, "admin", "admin" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("7d0f8501-a76c-4f1c-90ad-5ef95b93dee1"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("c040c031-c485-4925-942a-c7cdbef231fa"));

            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "TokenSession");

            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "Account");
        }
    }
}
