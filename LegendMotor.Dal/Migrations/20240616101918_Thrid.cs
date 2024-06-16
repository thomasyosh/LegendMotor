using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LegendMotor.Dal.Migrations
{
    /// <inheritdoc />
    public partial class Thrid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "orderLine",
                columns: table => new
                {
                    LineId = table.Column<string>(type: "TEXT", nullable: false),
                    OrderHeaderId = table.Column<string>(type: "TEXT", nullable: false),
                    SparePartId = table.Column<string>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    GRN = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderLine", x => x.LineId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orderLine");
        }
    }
}
