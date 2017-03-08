using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSCompliance.Models
{
    public class TradeGovSource
    {
        public string source { get; set; }
        public DateTime source_last_updated { get; set; }
        public DateTime last_imported { get; set; }
        public string import_rate { get; set; }
    }
}