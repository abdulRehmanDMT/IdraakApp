using System;
using System.Collections.Generic;
using System.Text;

namespace IdraakApp.ViewModels
{
    public class CountryDetailVM
    {
        public long CountryId { get; set; }
        public string RegionName { get; set; }
        public string CountryNameEn { get; set; }
        public string CountryNameFr { get; set; }
        public string CountryNameAr { get; set; }
        public string IconImage { get; set; }
        public string IsoCode2 { get; set; }
        public string IsoCode3 { get; set; }
        public string CountryCode { get; set; }
        public string MobileMask { get; set; }
        public string CurrencySymbol { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyDecimals { get; set; }
        public string IsServiceAvailable { get; set; }
    }
}
