using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bulky.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addSessionToOrderHeader : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "orderStatus",
                table: "OrderHeaders",
                newName: "OrderStatus");

            migrationBuilder.AddColumn<string>(
                name: "sessionId",
                table: "OrderHeaders",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sessionId",
                table: "OrderHeaders");

            migrationBuilder.RenameColumn(
                name: "OrderStatus",
                table: "OrderHeaders",
                newName: "orderStatus");
        }
    }
}
