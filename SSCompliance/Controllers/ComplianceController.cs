using RestSharp;
using SSCompliance.Models;
using SSCompliance.ServiceApi;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;

namespace SSCompliance.Controllers
{
    public class ComplianceController : ApiController
    {

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetResponse()
        {
            NameValueCollection ncv = HttpUtility.ParseQueryString(Request.RequestUri.Query);
            TradeGovService tds = new TradeGovService();
            var _response = tds.GetTradeGovResponse(ncv);

            return Ok(_response);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.ActionName("FindAll")]
        public IHttpActionResult AllResponses([FromBody]SearchRequest searchRequest)
        {
            if (searchRequest == null)
            {
                return BadRequest("Invalid passed data");
            }

            if (string.IsNullOrEmpty(searchRequest.api_key))
            {
                return BadRequest("Please pass api key");
            }

            if (searchRequest.queries == null || searchRequest.queries.Count == 0)
            {
                return BadRequest("Invalid passed data");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TradeGovService tds = new TradeGovService();
            var responses = tds.GetTradeGovResponses(searchRequest);
            return Ok(responses);
        }
    }
}
