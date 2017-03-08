using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace SSCompliance.Controllers
{
    public class FindController : Controller
    {
        public ActionResult ComplianceSearch()
        {
            ViewBag.Title = "Find";
            return View();
        }
    }
}
