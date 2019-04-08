using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace API_Usage.Migrations
{
    public partial class IntialCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    symbol = table.Column<string>(nullable: false),
                    date = table.Column<string>(nullable: true),
                    iexId = table.Column<string>(nullable: true),
                    isEnabled = table.Column<bool>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.symbol);
                });

            migrationBuilder.CreateTable(
                name: "Dividend",
                columns: table => new
                {
                    exdate = table.Column<string>(nullable: false),
                    declaredDate = table.Column<string>(nullable: true),
                    paymentDate = table.Column<string>(nullable: true),
                    qualified = table.Column<string>(nullable: true),
                    recordDate = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dividend", x => x.exdate);
                });

            migrationBuilder.CreateTable(
                name: "InFocus",
                columns: table => new
                {
                    symbol = table.Column<string>(nullable: false),
                    avgTotalVolume = table.Column<long>(nullable: false),
                    calculationPrice = table.Column<string>(nullable: true),
                    change = table.Column<double>(nullable: false),
                    changePercent = table.Column<double>(nullable: false),
                    close = table.Column<float>(nullable: false),
                    closeTime = table.Column<long>(nullable: false),
                    companyName = table.Column<string>(nullable: true),
                    delayedPrice = table.Column<double>(nullable: false),
                    delayedPriceTime = table.Column<long>(nullable: false),
                    extendedChange = table.Column<double>(nullable: false),
                    extendedChangePercent = table.Column<double>(nullable: false),
                    extendedPrice = table.Column<long>(nullable: false),
                    extendedPriceTime = table.Column<long>(nullable: false),
                    high = table.Column<float>(nullable: false),
                    iexAskPrice = table.Column<string>(nullable: true),
                    iexAskSize = table.Column<string>(nullable: true),
                    iexBidPrice = table.Column<string>(nullable: true),
                    iexBidSize = table.Column<string>(nullable: true),
                    iexLastUpdated = table.Column<string>(nullable: true),
                    iexMarketPercent = table.Column<string>(nullable: true),
                    iexRealtimePrice = table.Column<string>(nullable: true),
                    iexRealtimeSize = table.Column<string>(nullable: true),
                    iexVolume = table.Column<string>(nullable: true),
                    latestPrice = table.Column<double>(nullable: false),
                    latestSource = table.Column<string>(nullable: true),
                    latestTime = table.Column<string>(nullable: true),
                    latestUpdate = table.Column<long>(nullable: false),
                    latestVolume = table.Column<int>(nullable: false),
                    low = table.Column<double>(nullable: false),
                    marketCap = table.Column<long>(nullable: false),
                    open = table.Column<string>(nullable: true),
                    openTime = table.Column<long>(nullable: false),
                    peRatio = table.Column<string>(nullable: true),
                    previousClose = table.Column<double>(nullable: false),
                    primaryExchange = table.Column<string>(nullable: true),
                    sector = table.Column<string>(nullable: true),
                    week52High = table.Column<float>(nullable: false),
                    week52Low = table.Column<float>(nullable: false),
                    ytdChange = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InFocus", x => x.symbol);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    datetime = table.Column<DateTime>(nullable: false),
                    headline = table.Column<string>(nullable: true),
                    image = table.Column<string>(nullable: true),
                    related = table.Column<string>(nullable: true),
                    source = table.Column<string>(nullable: true),
                    summary = table.Column<string>(nullable: true),
                    url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.datetime);
                });

            migrationBuilder.CreateTable(
                name: "SectorPerform",
                columns: table => new
                {
                    name = table.Column<string>(nullable: false),
                    lastUpdated = table.Column<double>(nullable: false),
                    performance = table.Column<float>(nullable: false),
                    type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectorPerform", x => x.name);
                });

            migrationBuilder.CreateTable(
                name: "Equities",
                columns: table => new
                {
                    EquityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    change = table.Column<float>(nullable: false),
                    changeOverTime = table.Column<float>(nullable: false),
                    changePercent = table.Column<float>(nullable: false),
                    close = table.Column<float>(nullable: false),
                    date = table.Column<string>(nullable: true),
                    high = table.Column<float>(nullable: false),
                    label = table.Column<string>(nullable: true),
                    low = table.Column<float>(nullable: false),
                    open = table.Column<float>(nullable: false),
                    symbol = table.Column<string>(nullable: true),
                    unadjustedVolume = table.Column<int>(nullable: false),
                    volume = table.Column<int>(nullable: false),
                    vwap = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equities", x => x.EquityId);
                    table.ForeignKey(
                        name: "FK_Equities_Companies_symbol",
                        column: x => x.symbol,
                        principalTable: "Companies",
                        principalColumn: "symbol",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equities_symbol",
                table: "Equities",
                column: "symbol");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dividend");

            migrationBuilder.DropTable(
                name: "Equities");

            migrationBuilder.DropTable(
                name: "InFocus");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "SectorPerform");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
