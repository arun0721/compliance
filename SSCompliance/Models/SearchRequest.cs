using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSCompliance.Models
{
    public class SearchRequest
    {
        public string api_key { get; set; }
        public List<SearchQuery> queries { get; set; }
    }
}