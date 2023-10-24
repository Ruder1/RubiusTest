using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Divisions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Subdivision = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Salary = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DivisionUser",
                columns: table => new
                {
                    DivisionsId = table.Column<int>(type: "integer", nullable: false),
                    UsersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DivisionUser", x => new { x.DivisionsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_DivisionUser_Divisions_DivisionsId",
                        column: x => x.DivisionsId,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DivisionUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersDivisions",
                columns: table => new
                {
                    UserDivisionID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserID = table.Column<int>(type: "integer", nullable: false),
                    DivisionID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersDivisions", x => x.UserDivisionID);
                    table.ForeignKey(
                        name: "FK_UsersDivisions_Divisions_DivisionID",
                        column: x => x.DivisionID,
                        principalTable: "Divisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersDivisions_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Divisions",
                columns: new[] { "Id", "Name", "Subdivision" },
                values: new object[,]
                {
                    { 1, "Финансовый", "Финансовый" },
                    { 2, "Логистики", "Финансовый" },
                    { 3, "Закупок", "Финансовый" },
                    { 4, "Развлечений", "Развлечений" },
                    { 5, "Кадров", "Финансовый" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "LastName", "Name", "Salary", "Surname" },
                values: new object[,]
                {
                    { 1, "example@example.com", "Иваныч", "Иван", 150, "Иванов" },
                    { 2, "temp@example.com", "Витальевич", "Евгений", 200, "Сизов" },
                    { 3, "Check@example.com", "Борисович", "Павел", 300, "Честаков" },
                    { 4, "myMail@example.com", "Артемович", "Константин", 250, "Лебидин" },
                    { 5, "Test@example.com", "Данилович", "Виталий", 170, "Шобасов" },
                    { 6, "Kocherga@example.com", "Борисович", "Иван", 120, "Кочерга" }
                });

            migrationBuilder.InsertData(
                table: "UsersDivisions",
                columns: new[] { "UserDivisionID", "DivisionID", "UserID" },
                values: new object[,]
                {
                    { 1, 2, 1 },
                    { 2, 2, 2 },
                    { 3, 2, 3 },
                    { 4, 2, 4 },
                    { 5, 2, 5 },
                    { 6, 1, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DivisionUser_UsersId",
                table: "DivisionUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersDivisions_DivisionID",
                table: "UsersDivisions",
                column: "DivisionID");

            migrationBuilder.CreateIndex(
                name: "IX_UsersDivisions_UserID",
                table: "UsersDivisions",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DivisionUser");

            migrationBuilder.DropTable(
                name: "UsersDivisions");

            migrationBuilder.DropTable(
                name: "Divisions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
