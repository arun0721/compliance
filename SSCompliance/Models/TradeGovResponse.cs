using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSCompliance.Models
{
    public class TradeGovResponse
    {
        public int total { get; set; }
        public int offset { get; set; }
        public List<TradeGovSource> sources_used { get; set; }
        public DateTime search_performed_at { get; set; }
        public List<TradeGovResult> results { get; set; }
        public SearchQuery requestQuery { get; set; }
    }
}