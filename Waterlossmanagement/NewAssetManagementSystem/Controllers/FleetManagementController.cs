using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewAssetManagementSystem.Controllers
{
    public class FleetManagementController : Controller
    {
        AssetManagementDashboardInsideLogic.Logic.Processor processor = new AssetManagementDashboardInsideLogic.Logic.Processor();
        // GET: FleetManagement
        public ActionResult AddNewFleet()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNewFleet(FormCollection collection)
        {
            try
            {
                AssetManagementDashboardInsideLogic.Models.Fleet fleet = new AssetManagementDashboardInsideLogic.Models.Fleet();
                fleet.CarType = Request["cartype"];
                fleet.Model = Request["model"];
                fleet.Driver = Request["driver"];
                fleet.LocationOfDuty = Request["locofduty"];
                fleet.FuelAllocation = Request["fuelalloc"];
                fleet.MaintainaceSchedule = Request["maintschedule"];
                fleet.InsuranceType = Request["insurancetype"];
                fleet.InsuranceExpiry = Request["insuranceexpiry"];
                processor.CreateFleet(fleet);
                ViewBag.Message = "FLEET CREATED SUCCESSFULLY";
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View();
        }

        public ActionResult ViewRecordedFleets() 
        {
            try
            {
                AssetManagementDashboardInsideLogic.Models.RecordedFleets recordedFleets = new AssetManagementDashboardInsideLogic.Models.RecordedFleets();
                recordedFleets = processor.GetFleets();
                if (recordedFleets.fleets ==null)
                {
                    ViewBag.Error = "NO FLEET FOUND";
                    
                }
                else if (recordedFleets.fleets.Count>0)
                {
                    ViewBag.Fleet = recordedFleets.fleets;
                }
                else
                {
                    ViewBag.Error = "NO FLEET FOUND";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View();
        }
    }
}