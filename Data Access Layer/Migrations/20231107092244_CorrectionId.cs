using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class CorrectionId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "ParentId" },
                values: new object[] { "Кадров", 1 });

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Name", "ParentId" },
                values: new object[] { "Развлечений", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "ParentId" },
                values: new object[] { "Развлечений", null });

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Name", "ParentId" },
                values: new object[] { "Кадров", 1 });
        }
    }
}
