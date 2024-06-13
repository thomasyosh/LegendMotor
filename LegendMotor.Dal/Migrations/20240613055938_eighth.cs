using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LegendMotor.Dal.Migrations
{
    /// <inheritdoc />
    public partial class eighth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Gemder",
                table: "Staff",
                newName: "LastLoginDateTime");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Staff",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "LoginFailedCounter",
                table: "Staff",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "LoginFailedCounter",
                table: "Staff");

            migrationBuilder.RenameColumn(
                name: "LastLoginDateTime",
                table: "Staff",
                newName: "Gemder");
        }
    }
}
