using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSCompliance.Models
{
    public class TradeGovResult
    {
        public string id { get; set; }
        public string entity_number { get; set; }
        public string name { get; set; }
        public string remarks { get; set; }
        public string source { get; set; }
        public string source_list_url { get; set; }
        public string title { get; set; }//nullable
        public string type { get; set; }
        public string federal_register_notice { get; set; }
        public string license_policy { get; set; }
        public string license_requirement { get; set; }
        public string standard_order { get; set; }
        public double score { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public List<TradeGovAdress> addresses { get; set; }
        public List<string> alt_names { get; set;}
        public List<string> citizenships { get; set; }//investigate this field
        public List<DateTime> dates_of_birth { get; set; }//investigate this field
        public List<TradeGovId> ids { get; set; }
        public List<string> nationalities { get; set; }//investigate
        public List<string> places_of_birth { get; set; }//investigate
        public List<string> programs { get; set; }//investigate

    }
}