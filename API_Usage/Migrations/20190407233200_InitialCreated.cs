using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace API_Usage.Migrations
{
    public partial class InitialCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gainers",
                columns: table => new
                {
                    symbol = table.Column<string>(nullable: false),
                    avgTotalVolume = table.Column<int>(nullable: false),
                    calculationPrice = table.Column<string>(nullable: true),
                    change = table.Column<float>(nullable: false),
                    changePercent = table.Column<float>(nullable: false),
                    close = table.Column<float>(nullable: false),
                    closeTime = table.Column<long>(nullable: false),
                    companyName = table.Column<string>(nullable: true),
                    delayedPrice = table.Column<float>(nullable: false),
                    delayedPriceTime = table.Column<long>(nullable: false),
                    extendedChange = table.Column<float>(nullable: false),
                    extendedChangePercent = table.Column<float>(nullable: false),
                    extendedPrice = table.Column<float>(nullable: false),
                    extendedPriceTime = table.Column<long>(nullable: false),
                    high = table.Column<float>(nullable: false),
                    iexAskPrice = table.Column<float>(nullable: false),
                    iexAskSize = table.Column<float>(nullable: false),
                    iexBidPrice = table.Column<float>(nullable: false),
                    iexBidSize = table.Column<float>(nullable: false),
                    iexLastUpdated = table.Column<string>(nullable: true),
                    iexMarketPercent = table.Column<float>(nullable: false),
                    iexRealtimePrice = table.Column<float>(nullable: false),
                    iexRealtimeSize = table.Column<float>(nullable: false),
                    iexVolume = table.Column<float>(nullable: false),
                    latestPrice = table.Column<float>(nullable: false),
                    latestSource = table.Column<string>(nullable: true),
                    latestTime = table.Column<string>(nullable: true),
                    latestUpdate = table.Column<long>(nullable: false),
                    latestVolume = table.Column<int>(nullable: false),
                    low = table.Column<float>(nullable: false),
                    marketCap = table.Column<long>(nullable: false),
                    open = table.Column<float>(nullable: false),
                    openTime = table.Column<long>(nullable: false),
                    peRatio = table.Column<float>(nullable: false),
                    previousClose = table.Column<float>(nullable: false),
                    primaryExchange = table.Column<string>(nullable: true),
                    sector = table.Column<string>(nullable: true),
                    week52High = table.Column<float>(nullable: false),
                    week52Low = table.Column<float>(nullable: false),
                    ytdChange = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gainers", x => x.symbol);
                });

            migrationBuilder.CreateTable(
                name: "History",
                columns: table => new
                {
                    uniqueSymbolsTraded = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    averageDailyRoutedVolume = table.Column<float>(nullable: false),
                    averageDailyVolume = table.Column<float>(nullable: false),
                    averageFillSize = table.Column<int>(nullable: false),
                    averageMarketShare = table.Column<int>(nullable: false),
                    averageOrderSize = table.Column<int>(nullable: false),
                    bin10000Percent = table.Column<float>(nullable: false),
                    bin10000Trades = table.Column<int>(nullable: false),
                    bin1000Percent = table.Column<float>(nullable: false),
                    bin100Percent = table.Column<float>(nullable: false),
                    bin101Percent = table.Column<float>(nullable: false),
                    bin20000Trades = table.Column<int>(nullable: false),
                    bin200Percent = table.Column<float>(nullable: false),
                    bin300Percent = table.Column<float>(nullable: false),
                    bin400Percent = table.Column<float>(nullable: false),
                    bin50000Trades = table.Column<int>(nullable: false),
                    bin5000Percent = table.Column<float>(nullable: false),
                    bin500Percent = table.Column<float>(nullable: false),
                    blockPercent = table.Column<float>(nullable: false),
                    etfPercent = table.Column<float>(nullable: false),
                    largeCapPercent = table.Column<float>(nullable: false),
                    midCapPercent = table.Column<float>(nullable: false),
                    selfCrossPercent = table.Column<float>(nullable: false),
                    smallCapPercent = table.Column<float>(nullable: false),
                    venueARCXFirstWaveRate = table.Column<float>(nullable: false),
                    venueARCXFirstWaveWeight = table.Column<float>(nullable: false),
                    venueBATSFirstWaveRate = table.Column<float>(nullable: false),
                    venueBATSFirstWaveWeight = table.Column<float>(nullable: false),
                    venueBATYFirstWaveRate = table.Column<float>(nullable: false),
                    venueBATYFirstWaveWeight = table.Column<float>(nullable: false),
                    venueEDGAFirstWaveRate = table.Column<float>(nullable: false),
                    venueEDGAFirstWaveWeight = table.Column<float>(nullable: false),
                    venueEDGXFirstWaveRate = table.Column<float>(nullable: false),
                    venueEDGXFirstWaveWeight = table.Column<float>(nullable: false),
                    venueOverallFirstWaveRate = table.Column<float>(nullable: false),
                    venueOverallFirstWaveWeight = table.Column<int>(nullable: false),
                    venueXASEFirstWaveRate = table.Column<float>(nullable: false),
                    venueXASEFirstWaveWeight = table.Column<float>(nullable: false),
                    venueXBOSFirstWaveRate = table.Column<float>(nullable: false),
                    venueXBOSFirstWaveWeight = table.Column<float>(nullable: false),
                    venueXCHIFirstWaveRate = table.Column<float>(nullable: false),
                    venueXCHIFirstWaveWeight = table.Column<float>(nullable: false),
                    venueXCISFirstWaveRate = table.Column<float>(nullable: false),
                    venueXCISFirstWaveWeight = table.Column<float>(nullable: false),
                    venueXNGSFirstWaveRate = table.Column<float>(nullable: false),
                    venueXNGSFirstWaveWeight = table.Column<float>(nullable: false),
                    venueXNYSFirstWaveRate = table.Column<float>(nullable: false),
                    venueXNYSFirstWaveWeight = table.Column<float>(nullable: false),
                    venueXPHLFirstWaveRate = table.Column<float>(nullable: false),
                    venueXPHLFirstWaveWeight = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_History", x => x.uniqueSymbolsTraded);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gainers");

            migrationBuilder.DropTable(
                name: "History");
        }
    }
}
