using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Test3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UsersDivisions",
                columns: new[] { "UserDivisionID", "DivisionID", "UserID" },
                values: new object[,]
                {
                    { 7, 4, 1 },
                    { 8, 3, 1 },
                    { 9, 1, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UsersDivisions",
                keyColumn: "UserDivisionID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "UsersDivisions",
                keyColumn: "UserDivisionID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "UsersDivisions",
                keyColumn: "UserDivisionID",
                keyValue: 9);
        }
    }
}
