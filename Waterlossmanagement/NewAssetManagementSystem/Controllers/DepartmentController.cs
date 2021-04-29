using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewAssetManagementSystem.Controllers
{
    public class DepartmentController : Controller
    {
        AssetManagementDashboardInsideLogic.Logic.Processor processor = new AssetManagementDashboardInsideLogic.Logic.Processor();
        // GET: Department
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateDepartment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateDepartment(FormCollection login)
        {
            try
            {
                AssetManagementDashboardInsideLogic.Models.Department department = new AssetManagementDashboardInsideLogic.Models.Department();
                department.lname = Request.Form["departname"];
                department.room_name = Request.Form["roomname"];
                department.floor = Request.Form["floorname"];
                department.building = Request.Form["buildname"];
                processor.CreateUserDeparment(department);
                ViewBag.Message = "Department has been created successfully";
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View();
        }

        public ActionResult ViewDepartment()
        {
            try
            {
                DataTable users = processor.GetUserDepartments();
                if (users.Rows.Count > 0)
                {
                    List<AssetManagementDashboardInsideLogic.Models.Department> departments = new List<AssetManagementDashboardInsideLogic.Models.Department>();
                    foreach (DataRow dr in users.Rows)
                    {
                        AssetManagementDashboardInsideLogic.Models.Department department = new AssetManagementDashboardInsideLogic.Models.Department();
                        department.Id = dr["Id"].ToString();
                        department.lname = dr["lname"].ToString();
                        department.room_name = dr["room_name"].ToString();
                        department.floor = dr["floor"].ToString();
                        department.building = dr["building"].ToString();
                        department.RecordDate = dr["RecordDate"].ToString();
                        departments.Add(department);
                    }
                    ViewBag.Departments = departments;
                }
                else
                {
                    ViewBag.Message = "No Department Found";
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