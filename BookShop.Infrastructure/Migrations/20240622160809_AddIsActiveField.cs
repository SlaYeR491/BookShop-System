using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIsActiveField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "CustomerAccounts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AdminAccounts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AdminAccounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsActive",
                value: false);

            migrationBuilder.UpdateData(
                table: "AdminAccounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsActive",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "CustomerAccounts");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AdminAccounts");
        }
    }
}
