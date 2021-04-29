using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewAssetManagementSystem.Controllers
{
    public class UserController : Controller
    {
        AssetManagementDashboardInsideLogic.Logic.Processor processor = new AssetManagementDashboardInsideLogic.Logic.Processor();

        public ActionResult CreateUser()
        {
            GetUserDepartments();
            return View();
        }

        public ActionResult Water()
        {
            GetUserDepartments();
            return View();
        }

        [HttpPost]
        public ActionResult Water(FormCollection login)
        {
            AssetManagementDashboardInsideLogic.Models.WaterLoss waterLoss = new AssetManagementDashboardInsideLogic.Models.WaterLoss();
            waterLoss.Burstdate = Request.Form["burstdate"];
            waterLoss.Location = Request.Form["location"];
            waterLoss.operationalarea = Request.Form["operationalarea"];
            waterLoss.remarks = Request.Form["remarks"];
            waterLoss.status = Request.Form["status"];
            waterLoss.xcordinates = Request.Form["xcordinates"];
            waterLoss.ycordinates = Request.Form["ycordinates"];
            processor.CreateWaterLoss(waterLoss);
            return RedirectToAction("WaterLossReport", "User");
        }

        public ActionResult EditUser(string userid)
        {
            if (string.IsNullOrEmpty(userid))
            {
                return RedirectToAction("ViewUsers", "User");
            }
            else
            {
                GetUserDetailstoEdit(userid);
            }
            GetUserDepartments();
            return View();
        }

        public ActionResult Delete(string userid)
        {
            if (string.IsNullOrEmpty(userid))
            {
            }
            else
            {
                processor.DeleteUser(userid);
            }
            return RedirectToAction("ViewUsers", "User"); ;
        }

        [HttpPost]
        public ActionResult EditUser(FormCollection login)
        {
            try
            {
                AssetManagementDashboardInsideLogic.Models.SystemUser user = new AssetManagementDashboardInsideLogic.Models.SystemUser();
                user.Fname = Request.Form["firstname"];
                user.Lname = Request.Form["lastname"];
                user.Uemail = Request.Form["Uemail"];
                user.Uname = Request.Form["username"];
                user.Udepart = Request.Form["department"];
                user.Uid = Request.Form["userid"];
                processor.UpdateUser(user);
                return RedirectToAction("ViewUsers", "User");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        [HttpPost]
        public ActionResult CreateUser(FormCollection login)
        {
            try
            {
                AssetManagementDashboardInsideLogic.Models.SystemUser user = new AssetManagementDashboardInsideLogic.Models.SystemUser();
                user.Fname = Request.Form["firstname"];
                user.Lname = Request.Form["lastname"];
                user.Pwd = Request.Form["password"];
                user.Uemail = Request.Form["Uemail"];
                user.Uname = Request.Form["username"];
                user.Pwd = Request.Form["password1"];
                string pwd = Request.Form["password1"];
                user.Udepart = Request.Form["department"];

                if (!user.Pwd.Equals(pwd))
                {
                    ViewBag.Message = "Password do not match";
                }
                else
                {
                    processor.CreateUser(user.Uname, user.Pwd, user.Uemail, user.Fname, user.Lname, user.Udepart);
                    ViewBag.Message = "User Has been created successfully";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View();
        }
        public ActionResult WaterLossReport()
        {
            try
            {
                DataTable users = processor.GetWaterLossReport();
                if (users.Rows.Count > 0)
                {
                    List<AssetManagementDashboardInsideLogic.Models.WaterLoss> waterLosses = new List<AssetManagementDashboardInsideLogic.Models.WaterLoss>();
                    foreach (DataRow dr in users.Rows)
                    {
                        AssetManagementDashboardInsideLogic.Models.WaterLoss waterLoss = new AssetManagementDashboardInsideLogic.Models.WaterLoss();
                        waterLoss.Burstdate = dr["BustDate"].ToString();
                        waterLoss.Location = dr["Location"].ToString();
                        waterLoss.operationalarea = dr["OperationArea"].ToString();
                        waterLoss.status = dr["Status"].ToString();
                        waterLoss.xcordinates = dr["XCordinates"].ToString();
                        waterLoss.ycordinates = dr["YCordinates"].ToString();
                        waterLoss.remarks = dr["Remarks"].ToString();
                        waterLosses.Add(waterLoss);
                    }
                    ViewBag.WaterLosses = waterLosses;
                }
                else
                {
                    ViewBag.Message = "No Users Found";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            return View();
        }
        public ActionResult ViewUsers()
        {
            try
            {
                DataTable users = processor.GetSystemUsers();
                if (users.Rows.Count>0)
                {
                    List<AssetManagementDashboardInsideLogic.Models.SystemUser> systemUsers = new List<AssetManagementDashboardInsideLogic.Models.SystemUser>();
                    foreach (DataRow dr in users.Rows)
                    {
                        AssetManagementDashboardInsideLogic.Models.SystemUser user = new AssetManagementDashboardInsideLogic.Models.SystemUser();
                        user.Fname = dr["Fname"].ToString();
                        user.Lname = dr["Lname"].ToString();
                        user.Uemail = dr["Uemail"].ToString();
                        user.Uid = dr["Uid"].ToString();
                        user.Uname = dr["Uname"].ToString();
                        user.Utype = dr["Utype"].ToString();
                        systemUsers.Add(user);
                    }
                    ViewBag.SystemUsers = systemUsers;
                }
                else
                {
                    ViewBag.Message = "No Users Found";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            return View();
        }

        public void GetUserDepartments()
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
        }

        private void GetUserDetailstoEdit(string id)
        {
            try
            {
                DataTable users = processor.GetSystemUsers(id);
                if (users.Rows.Count > 0)
                {
                    AssetManagementDashboardInsideLogic.Models.SystemUser user = new AssetManagementDashboardInsideLogic.Models.SystemUser();
                    user.Fname = users.Rows[0]["Fname"].ToString();
                    user.Lname = users.Rows[0]["Lname"].ToString();
                    user.Uemail = users.Rows[0]["Uemail"].ToString();
                    user.Uid = users.Rows[0]["Uid"].ToString();
                    user.Uname = users.Rows[0]["Uname"].ToString();
                    user.Utype = users.Rows[0]["Office"].ToString();
                    user.Uid = users.Rows[0]["uid"].ToString();
                    ViewBag.SystemUserToEdit = user;
                }
                else
                {
                    ViewBag.Message = "No Users Found";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
        }

    }
}