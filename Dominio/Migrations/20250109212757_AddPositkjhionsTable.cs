using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dominio.Migrations
{
    /// <inheritdoc />
    public partial class AddPositkjhionsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Developers_Leaders_LeaderId",
                table: "Developers");

            migrationBuilder.AlterColumn<int>(
                name: "LeaderId",
                table: "Developers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Developers_Leaders_LeaderId",
                table: "Developers",
                column: "LeaderId",
                principalTable: "Leaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Developers_Leaders_LeaderId",
                table: "Developers");

            migrationBuilder.AlterColumn<int>(
                name: "LeaderId",
                table: "Developers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Developers_Leaders_LeaderId",
                table: "Developers",
                column: "LeaderId",
                principalTable: "Leaders",
                principalColumn: "Id");
        }
    }
}
