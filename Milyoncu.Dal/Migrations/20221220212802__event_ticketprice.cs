﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Milyoncu.Dal.Migrations
{
    /// <inheritdoc />
    public partial class eventticketprice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TicketPrice",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketPrice",
                table: "Events");
        }
    }
}
