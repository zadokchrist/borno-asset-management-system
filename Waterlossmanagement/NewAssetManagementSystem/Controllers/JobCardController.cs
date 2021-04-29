using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewAssetManagementSystem.Controllers
{
    public class JobCardController : Controller
    {
        // GET: JobCard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateJobCard()
        {
            return View();
        }

        public ActionResult ViewJobCards()
        {
            try
            {
                AssetManagementDashboardInsideLogic.Models.JobCard jobCard = new AssetManagementDashboardInsideLogic.Models.JobCard();
                AssetManagementDashboardInsideLogic.Logic.JobCardProcessor jobCardProcessor = new AssetManagementDashboardInsideLogic.Logic.JobCardProcessor(jobCard);
                List<AssetManagementDashboardInsideLogic.Models.JobCard> jobCards = jobCardProcessor.GetJobCards();
                ViewBag.JobCards = jobCards;
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                throw;
            }
            return View();
        }

        [HttpPost]
        public ActionResult CreateJobCard(FormCollection form)
        {
            try
            {
                AssetManagementDashboardInsideLogic.Models.JobCard jobCard = new AssetManagementDashboardInsideLogic.Models.JobCard();
                jobCard.actiontaken = Request.Form["actiontaken"];
                jobCard.appby = Request.Form["appby"];
                jobCard.blockmapno = Request.Form["blockmapno"];
                jobCard.Callid = Request.Form["callid"];
                jobCard.compdate = Request.Form["compdate"];
                jobCard.contractor = Request.Form["contractor"];
                jobCard.contractornum = Request.Form["contractornum"];
                jobCard.Dateassigned = Request.Form["dateassigned"];
                jobCard.Datereported = Request.Form["datereported"];
                jobCard.fixcond = Request.Form["fixcond"];
                jobCard.fixturetype = Request.Form["fixturetype"];
                jobCard.Informername = Request.Form["informername"];
                jobCard.jobcategory = Request.Form["jobcategory"];
                jobCard.Joblocation = Request.Form["joblocation"];
                jobCard.jobname = Request.Form["jobname"];
                jobCard.material = Request.Form["material"];
                jobCard.Phnnumber = Request.Form["phnnumber"];
                jobCard.prepby = Request.Form["prepby"];
                jobCard.reasonofdelay = Request.Form["reasonofdelay"];
                jobCard.size = Request.Form["size"];
                jobCard.Source = Request.Form["source"];
                jobCard.storekeepername = Request.Form["storekeepername"];
                jobCard.Timereported = Request.Form["timereported"];
                jobCard.title = Request.Form["title"];
                jobCard.xcordinates = Request.Form["xcordinates"];
                jobCard.ycordinates = Request.Form["ycordinates"];
                AssetManagementDashboardInsideLogic.Logic.JobCardProcessor jobCardProcessor = new AssetManagementDashboardInsideLogic.Logic.JobCardProcessor(jobCard);
                jobCardProcessor.CreateJobCard();
                ViewBag.Message = "JOB CARD HAS BEEN SAVED SUCCESSFULLY";
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View();
        }
    }
}