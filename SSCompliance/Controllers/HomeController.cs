using SSCompliance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSCompliance.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            SSComplianceLogin user = new SSComplianceLogin();
            return View(user);
        }

        [HttpPost]
        public ActionResult Index(SSComplianceLogin user)
        {
            bool success = false;
            var display = UserLogins().Where(u => u.UserName == user.UserName && u.UserPassword == user.UserPassword).FirstOrDefault();
            if(display!=null)
            {
                ViewBag.Status = "Correct UserName and Password";
                success = true;
            }
            else
            {
                ViewBag.Status = "Incorrect UserName or Password";
            }

            if (success)
                return RedirectToAction("ComplianceSearch", "Find");

            return View(user);
        }

        public List<SSComplianceLogin> UserLogins()
        {
            List<SSComplianceLogin> users = new List<SSComplianceLogin>();
            users.Add(new SSComplianceLogin { UserName = "Jon", UserPassword = "password" });
            return users;
        }
    }
}
