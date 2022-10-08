using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hack4good.Infrastructure.Data.Migrations
{
    public partial class Quiz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuizTour",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizTour", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuizStep",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    QuizId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ExternalId = table.Column<Guid>(type: "uuid", nullable: false),
                    Order = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizStep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizStep_QuizTour_QuizId",
                        column: x => x.QuizId,
                        principalTable: "QuizTour",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("7d0f8501-a76c-4f1c-90ad-5ef95b93dee1"),
                columns: new[] { "IsAdmin", "Login", "Password" },
                values: new object[] { true, "admin", "admin" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("c040c031-c485-4925-942a-c7cdbef231fa"),
                columns: new[] { "IsAdmin", "Login", "Password" },
                values: new object[] { false, "user", "user" });

            migrationBuilder.CreateIndex(
                name: "IX_QuizStep_QuizId",
                table: "QuizStep",
                column: "QuizId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuizStep");

            migrationBuilder.DropTable(
                name: "QuizTour");

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("7d0f8501-a76c-4f1c-90ad-5ef95b93dee1"),
                columns: new[] { "IsAdmin", "Login", "Password" },
                values: new object[] { false, "user", "user" });

            migrationBuilder.UpdateData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("c040c031-c485-4925-942a-c7cdbef231fa"),
                columns: new[] { "IsAdmin", "Login", "Password" },
                values: new object[] { true, "admin", "admin" });
        }
    }
}
