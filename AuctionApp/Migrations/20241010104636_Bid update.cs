using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionApp.Migrations
{
    /// <inheritdoc />
    public partial class Bidupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "Status",
                value: 1);

            migrationBuilder.InsertData(
                table: "ListOfBidsDbs",
                columns: new[] { "Id", "Title", "UserName" },
                values: new object[] { -2, "Pending Bids", "Jo4r" });

            migrationBuilder.InsertData(
                table: "BidDbs",
                columns: new[] { "Id", "ListOfBidsId", "Name", "Offer", "Status" },
                values: new object[] { -3, -2, "Rock", 200.0, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "ListOfBidsDbs",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "Status",
                value: 0);
        }
    }
}
