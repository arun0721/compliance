using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSCompliance.Models
{
    public class TradeGovId
    {
        public string country { get; set; }
        public DateTime expiration_date { get; set; }//investigate this field
        public DateTime issue_date { get; set; }
        public string number { get; set; }
        public string type { get; set; }
    }
}