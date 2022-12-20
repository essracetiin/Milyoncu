using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Milyoncu.Dal.Migrations
{
    /// <inheritdoc />
    public partial class dateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LotteryDate",
                table: "Lotteries",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LotteryDate",
                table: "Lotteries",
                type: "int",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");
        }
    }
}
