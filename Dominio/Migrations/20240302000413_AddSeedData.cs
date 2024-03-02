using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Dominio.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
#if DEBUG
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Active", "Name", "Removed" },
                values: new object[,]
                {
                    { 1, true, "FraSal", false },
                    { 2, true, "YouTube", false }
                });
#endif
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
#if DEBUG
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2);
#endif
        }
    }
}
