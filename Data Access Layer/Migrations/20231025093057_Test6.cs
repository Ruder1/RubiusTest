using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Test6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subdivision",
                table: "Divisions");

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "Divisions",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 1,
                column: "ParentId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 2,
                column: "ParentId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 3,
                column: "ParentId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 4,
                column: "ParentId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 5,
                column: "ParentId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_ParentId",
                table: "Divisions",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Divisions_Divisions_ParentId",
                table: "Divisions",
                column: "ParentId",
                principalTable: "Divisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Divisions_Divisions_ParentId",
                table: "Divisions");

            migrationBuilder.DropIndex(
                name: "IX_Divisions_ParentId",
                table: "Divisions");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Divisions");

            migrationBuilder.AddColumn<string>(
                name: "Subdivision",
                table: "Divisions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Subdivision",
                value: "Финансовый");

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Subdivision",
                value: "Финансовый");

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Subdivision",
                value: "Финансовый");

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Subdivision",
                value: "Развлечений");

            migrationBuilder.UpdateData(
                table: "Divisions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Subdivision",
                value: "Финансовый");
        }
    }
}
