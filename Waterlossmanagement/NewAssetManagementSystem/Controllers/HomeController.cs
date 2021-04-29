using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewAssetManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection login)
        {
            try
            {
                string username = Request.Form["username"];
                string password = Request.Form["password"];
                AssetManagementDashboardInsideLogic.Logic.Processor processor = new AssetManagementDashboardInsideLogic.Logic.Processor();
                DataTable data = processor.GetLoginDetails(username, password);
                if (data.Rows.Count > 0)
                {
                    Session["Uid"] = data.Rows[0]["Uid"].ToString();
                    Session["Uname"] = data.Rows[0]["Uname"].ToString();
                    Session["Pwd"] = data.Rows[0]["Pwd"].ToString();
                    Session["Fname"] = data.Rows[0]["Fname"].ToString();
                    Session["Lname"] = data.Rows[0]["Lname"].ToString();
                    Session["Utype"] = data.Rows[0]["Utype"].ToString();
                    return RedirectToAction("Dashboard", "Admin");
                }
                else
                {
                    ViewBag.Message = "WRONG USERNAME OR PASSWORD";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}