using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSCompliance.Models
{
    public class SearchQuery
    {
        public string name { get; set; }
        public string q { get; set; }
        public string fuzzy_name { get; set; }
        public string type { get; set; }
    }
}
