using RestSharp;
using SSCompliance.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace SSCompliance.ServiceApi
{
    public class TradeGovService : ServiceBase
    {
        private const string ServiceUrl = "consolidated_screening_list/search";
        private const string API_KEY = "api_key";
        private const string KEYWORD_KEY = "q";
        private const string FUZZYNAME_KEY = "fuzzy_name";
        private const string NAME_KEY = "name";
        private const string TYPE_KEY = "type";

        private const string apibaseuri = "https://api.trade.gov/";

        public TradeGovService() : base(apibaseuri)
        {
        }

        public List<TradeGovResponse> GetTradeGovResponses(SearchRequest searchRequest)
        {
            List<TradeGovResponse> responses = new List<TradeGovResponse>();

            string apiKey = searchRequest.api_key;
            foreach(SearchQuery searchQ in searchRequest.queries)
            {
                NameValueCollection items = new NameValueCollection();
                items.Add(API_KEY, apiKey);
                items.Add(NAME_KEY, searchQ.name);
                items.Add(KEYWORD_KEY, searchQ.q);
                items.Add(FUZZYNAME_KEY, searchQ.fuzzy_name);
                items.Add(TYPE_KEY, searchQ.type);
                var response = GetTradeGovResponse(items);
                if (response != null)
                {
                    response.requestQuery = searchQ;
                    responses.Add(response);

                }
            }


            return responses;
        }

        public TradeGovResponse GetTradeGovResponse(NameValueCollection items)
        {
            var restRequest = CreateRequest(ServiceUrl, RestSharp.Method.GET);
            restRequest = AddParams(items,restRequest);

            var response = Client.Execute<TradeGovResponse>(restRequest);

            LastResponse = response;

            return response.Data;
        }

        private IRestRequest AddParams(NameValueCollection nvc,IRestRequest request)
        {
            var parameters = nvc.AllKeys.SelectMany(nvc.GetValues, (k, v) => new { key = k, value = v });

            foreach(var param in parameters)
            {
                if (param.key == "type" && param.value == "Off")
                {
                    continue;
                }
                    if (param.key == "fuzzy_name")
                {
                    if (string.IsNullOrEmpty(param.value))
                        request.AddParameter(param.key, "false");
                    if (param.value == "on")
                        request.AddParameter(param.key, "true");

                    continue;
                }
                if (!string.IsNullOrEmpty(param.value))
                {
                    request.AddParameter(param.key, param.value);
                }
            }

            return request;
        }
    }
}
///Sample trade gov search query
///            ///https://api.trade.gov/consolidated_screening_list/search?api_key=VeaYLDhMLX_HwcbEbx27s5r3&q=al%20kayali&countries=US&sources=DPL%2CFSE%2C561&name=name123&address=address123&end_date=2019-05-29%20TO%202018-06-21&expiration_date=2016-12-27%20TO%202016-12-14&issue_date=2016-12-26%20TO%202016-12-26&fuzzy_name=true
