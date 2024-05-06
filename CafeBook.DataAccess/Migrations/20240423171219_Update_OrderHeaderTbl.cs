using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeBook.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Update_OrderHeaderTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OderStatus",
                table: "OrderHeaders",
                newName: "OrderStatus");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderStatus",
                table: "OrderHeaders",
                newName: "OderStatus");
        }
    }
}
