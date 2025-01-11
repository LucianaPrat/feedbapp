using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dominio.Migrations
{
    /// <inheritdoc />
    public partial class AddPositionsTable : Migration
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
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeveloperId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Recurrence = table.Column<int>(type: "int", nullable: false),
                    Removed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Positions_Developers_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Developers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Positions_DeveloperId",
                table: "Positions",
                column: "DeveloperId");

            migrationBuilder.AddForeignKey(
                name: "FK_Developers_Leaders_LeaderId",
                table: "Developers",
                column: "LeaderId",
                principalTable: "Leaders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Developers_Leaders_LeaderId",
                table: "Developers");

            migrationBuilder.DropTable(
                name: "Positions");

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
    }
}
