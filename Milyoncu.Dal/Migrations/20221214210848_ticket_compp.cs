using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Milyoncu.Dal.Migrations
{
    /// <inheritdoc />
    public partial class ticketcompp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "Baskets");

            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "Tickets",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Completed",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "TicketId",
                table: "Baskets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
