using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace API_Usage.Models
{
    public class Historical_Summary
    {
        [Key]
        public int uniqueSymbolsTraded { get; set; }
        public float averageDailyVolume { get; set; }
        public float averageDailyRoutedVolume { get; set; }
        public int averageMarketShare { get; set; }
        public int averageOrderSize { get; set; }
        public int averageFillSize { get; set; }
        public float bin100Percent { get; set; }
        public float bin101Percent { get; set; }
        public float bin200Percent { get; set; }
        public float bin300Percent { get; set; }
        public float bin400Percent { get; set; }
        public float bin500Percent { get; set; }
        public float bin1000Percent { get; set; }
        public float bin5000Percent { get; set; }
        public float bin10000Percent { get; set; }
        public int bin10000Trades { get; set; }
        public int bin20000Trades { get; set; }
        public int bin50000Trades { get; set; }
        public float blockPercent { get; set; }
        public float selfCrossPercent { get; set; }
        public float etfPercent { get; set; }
        public float largeCapPercent { get; set; }
        public float midCapPercent { get; set; }
        public float smallCapPercent { get; set; }
        public float venueARCXFirstWaveWeight { get; set; }
        public float venueBATSFirstWaveWeight { get; set; }
        public float venueBATYFirstWaveWeight { get; set; }
        public float venueEDGAFirstWaveWeight { get; set; }
        public float venueEDGXFirstWaveWeight { get; set; }
        public int venueOverallFirstWaveWeight { get; set; }
        public float venueXASEFirstWaveWeight { get; set; }
        public float venueXBOSFirstWaveWeight { get; set; }
        public float venueXCHIFirstWaveWeight { get; set; }
        public float venueXCISFirstWaveWeight { get; set; }
        public float venueXNGSFirstWaveWeight { get; set; }
        public float venueXNYSFirstWaveWeight { get; set; }
        public float venueXPHLFirstWaveWeight { get; set; }
        public float venueARCXFirstWaveRate { get; set; }
        public float venueBATSFirstWaveRate { get; set; }
        public float venueBATYFirstWaveRate { get; set; }
        public float venueEDGAFirstWaveRate { get; set; }
        public float venueEDGXFirstWaveRate { get; set; }
        public float venueOverallFirstWaveRate { get; set; }
        public float venueXASEFirstWaveRate { get; set; }
        public float venueXBOSFirstWaveRate { get; set; }
        public float venueXCHIFirstWaveRate { get; set; }
        public float venueXCISFirstWaveRate { get; set; }
        public float venueXNGSFirstWaveRate { get; set; }
        public float venueXNYSFirstWaveRate { get; set; }
        public float venueXPHLFirstWaveRate { get; set; }
    }
}
