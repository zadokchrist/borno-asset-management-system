using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewAssetManagementSystem.Controllers
{
    public class AssignController : Controller
    {
        AssetManagementDashboardInsideLogic.Logic.Processor processor = new AssetManagementDashboardInsideLogic.Logic.Processor();
        // GET: Assign
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AssignToUser()
        {
            GetUserWithDepartment();
            return View();
        }

        [HttpGet]
        public ActionResult GetAssignmentType(string entityid)
        {
            DataTable data = null;
            if (entityid.Equals("1"))
            {
                data = processor.GetHardWareStockWithVendor();
            }
            else
            {
                data = processor.GetSoftwareStockWithVendor();
            }


            var result = JsonConvert.SerializeObject(data, Formatting.Indented,
                           new JsonSerializerSettings
                           {
                               ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                           });
            return Json(result, JsonRequestBehavior.AllowGet);//Json(data, JsonRequestBehavior.AllowGet); 
        }

        [HttpPost]
        public ActionResult AssignToUser(FormCollection login)
        {
            try
            {
                AssetManagementDashboardInsideLogic.Models.AssignmentModel assignmentModel = new AssetManagementDashboardInsideLogic.Models.AssignmentModel();
                assignmentModel.Entity = Request["entity"];
                assignmentModel.AssignmentType = Request["assignmentype"];
                assignmentModel.Qty = Request["qty"];
                assignmentModel.DateAssigned = Request["dassigned"];
                assignmentModel.DateAssigned = Request["dreturn"];
                assignmentModel.DateAssigned = Request["dreturn"];
                assignmentModel.AssignedTo = Request["assignedto"];
                processor.AssigntItem(assignmentModel);
                ViewBag.Message = "Item successfully Assigned to User";
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View();
        }

        public ActionResult ViewAssignedItems()
        {
            GetAssignedHardware();
            GetAssignedSoftware();
            return View();
        }
        private void GetUserWithDepartment()
        {
            try
            {
                DataTable users = processor.GetSystemUsersWithDepartment();
                if (users.Rows.Count > 0)
                {
                    List<AssetManagementDashboardInsideLogic.Models.SystemUser> systemUsers = new List<AssetManagementDashboardInsideLogic.Models.SystemUser>();
                    foreach (DataRow dr in users.Rows)
                    {
                        AssetManagementDashboardInsideLogic.Models.SystemUser user = new AssetManagementDashboardInsideLogic.Models.SystemUser();
                        user.Lname = dr["lname"].ToString();
                        user.Uid = dr["uid"].ToString();
                        user.Uname = dr["uname"].ToString();

                        systemUsers.Add(user);
                    }
                    ViewBag.SystemUsers = systemUsers;
                }
                else
                {
                    ViewBag.Error = "No Users Found";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
        }

        private void GetAssignedHardware()
        {
            try
            {

                DataTable dataTable = processor.GetAssignedItemsHardware();
                if (dataTable.Rows.Count > 0)
                {
                    List<AssetManagementDashboardInsideLogic.Models.ItemsAssigned> itemsAssigneds = new List<AssetManagementDashboardInsideLogic.Models.ItemsAssigned>();
                    foreach (DataRow dr in dataTable.Rows)
                    {
                        AssetManagementDashboardInsideLogic.Models.ItemsAssigned itemsAssigned = new AssetManagementDashboardInsideLogic.Models.ItemsAssigned();
                        itemsAssigned.cname = dr["cname"].ToString();
                        itemsAssigned.ctype = dr["ctype"].ToString();
                        itemsAssigned.doa = dr["doa"].ToString();
                        itemsAssigned.doe = dr["doe"].ToString();
                        itemsAssigned.fname = dr["fname"].ToString();
                        itemsAssigned.hw_name = dr["hw_name"].ToString();
                        itemsAssigned.Id = dr["Id"].ToString();
                        itemsAssigned.lname = dr["lname"].ToString();
                        itemsAssigned.qty = dr["qty"].ToString();
                        itemsAssigned.thumb = dr["thumb"].ToString();
                        itemsAssigned.vname = dr["vname"].ToString();
                        itemsAssigneds.Add(itemsAssigned);
                    }
                    ViewBag.AssignedHardware = itemsAssigneds;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
        }
        private void GetAssignedSoftware()
        {
            try
            {

                DataTable dataTable = processor.GetAssignedItemsSoftware();
                if (dataTable.Rows.Count > 0)
                {
                    List<AssetManagementDashboardInsideLogic.Models.ItemsAssigned> itemsAssigneds = new List<AssetManagementDashboardInsideLogic.Models.ItemsAssigned>();
                    foreach (DataRow dr in dataTable.Rows)
                    {
                        AssetManagementDashboardInsideLogic.Models.ItemsAssigned itemsAssigned = new AssetManagementDashboardInsideLogic.Models.ItemsAssigned();
                        itemsAssigned.cname = dr["cname"].ToString();
                        itemsAssigned.ctype = dr["ctype"].ToString();
                        itemsAssigned.doa = dr["doa"].ToString();
                        itemsAssigned.doe = dr["doe"].ToString();
                        itemsAssigned.fname = dr["fname"].ToString();
                        itemsAssigned.hw_name = dr["sw_name"].ToString();
                        itemsAssigned.Id = dr["Id"].ToString();
                        itemsAssigned.lname = dr["lname"].ToString();
                        itemsAssigned.qty = dr["qty"].ToString();
                        itemsAssigned.thumb = dr["thumb"].ToString();
                        itemsAssigned.vname = dr["vname"].ToString();
                        itemsAssigneds.Add(itemsAssigned);
                    }
                    ViewBag.AssignedSoftware = itemsAssigneds;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
        }
    }
}