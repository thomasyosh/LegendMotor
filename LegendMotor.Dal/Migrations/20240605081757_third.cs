using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LegendMotor.Dal.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Staff_Email_Name",
                table: "Staff",
                columns: new[] { "Email", "Name" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Staff_Email_Name",
                table: "Staff");
        }
    }
}
