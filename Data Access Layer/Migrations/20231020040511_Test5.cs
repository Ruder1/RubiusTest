using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Test5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Divisions_DivisionsId",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Users_UsersId",
                table: "Enrollments");

            migrationBuilder.DropTable(
                name: "UsersDivisions");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "Enrollments",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "DivisionsId",
                table: "Enrollments",
                newName: "DivisionId");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_UsersId",
                table: "Enrollments",
                newName: "IX_Enrollments_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Divisions_DivisionId",
                table: "Enrollments",
                column: "DivisionId",
                principalTable: "Divisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Users_UserId",
                table: "Enrollments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Divisions_DivisionId",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Users_UserId",
                table: "Enrollments");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Enrollments",
                newName: "UsersId");

            migrationBuilder.RenameColumn(
                name: "DivisionId",
                table: "Enrollments",
                newName: "DivisionsId");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_UserId",
                table: "Enrollments",
                newName: "IX_Enrollments_UsersId");

            migrationBuilder.CreateTable(
                name: "UsersDivisions",
                columns: table => new
                {
                    UserDivisionID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DivisionID = table.Column<int>(type: "integer", nullable: false),
                    UserID = table.Column<int>(type: "integer", nullable: false)
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
                table: "UsersDivisions",
                columns: new[] { "UserDivisionID", "DivisionID", "UserID" },
                values: new object[,]
                {
                    { 1, 2, 1 },
                    { 2, 2, 2 },
                    { 3, 2, 3 },
                    { 4, 2, 4 },
                    { 5, 2, 5 },
                    { 6, 1, 6 },
                    { 7, 4, 1 },
                    { 8, 3, 1 },
                    { 9, 1, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersDivisions_DivisionID",
                table: "UsersDivisions",
                column: "DivisionID");

            migrationBuilder.CreateIndex(
                name: "IX_UsersDivisions_UserID",
                table: "UsersDivisions",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Divisions_DivisionsId",
                table: "Enrollments",
                column: "DivisionsId",
                principalTable: "Divisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Users_UsersId",
                table: "Enrollments",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
