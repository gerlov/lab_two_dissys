using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations.Id
{
    /// <inheritdoc />
    public partial class UpdatedAppDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "BidListDbs",
                keyColumn: "Id",
                keyValue: -1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AuctionDbs",
                columns: new[] { "Id", "Description", "EndDate", "ItemName", "StartPrice", "UserName" },
                values: new object[] { -1, "Seed Data Description", new DateTime(2024, 10, 11, 15, 57, 25, 430, DateTimeKind.Local).AddTicks(4918), "Seed", 9999.0, "SeedUserNameForAuction" });

            migrationBuilder.InsertData(
                table: "BidListDbs",
                columns: new[] { "Id", "Title", "UserName" },
                values: new object[] { -1, "SeedTitle", "SeedUserName" });

            migrationBuilder.InsertData(
                table: "BidDbs",
                columns: new[] { "Id", "Amount", "AuctionId", "BidListId", "UserName" },
                values: new object[] { -1, 100.0, -1, -1, "SeedUserName" });
        }
    }
}
