using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Milyoncu.Dal.Migrations
{
    /// <inheritdoc />
    public partial class basketid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BasketId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_BasketId",
                table: "Tickets",
                column: "BasketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Baskets_BasketId",
                table: "Tickets",
                column: "BasketId",
                principalTable: "Baskets",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Baskets_BasketId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_BasketId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "BasketId",
                table: "Tickets");
        }
    }
}
