using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewAssetManagementSystem.Controllers
{
    public class HumanResourceController : Controller
    {
        AssetManagementDashboardInsideLogic.Logic.Processor processor = new AssetManagementDashboardInsideLogic.Logic.Processor();
        public ActionResult NewEmployeeRecord()
        {
            GetUserDepartments();
            return View();
        }

        public ActionResult LeaveApplication() 
        {
            return View();
        }

        public ActionResult EmployeeReport()
        {
            try
            {
                
                List<AssetManagementDashboardInsideLogic.Models.Employee> employees = new List<AssetManagementDashboardInsideLogic.Models.Employee>();
                DataTable table = processor.GetEmployees();
                if (table.Rows.Count>0)
                {
                    foreach (DataRow dr in table.Rows)
                    {
                        AssetManagementDashboardInsideLogic.Models.Employee employee = new AssetManagementDashboardInsideLogic.Models.Employee();
                        employee.Address = dr["EmpAddress"].ToString();
                        employee.ContractDate = dr["Contractdate"].ToString();
                        employee.Department = dr["lname"].ToString();
                        employee.DOB = dr["DateOfBirth"].ToString();
                        employee.EmployeeId = dr["EmployeeId"].ToString();
                        employee.EmployeeName = dr["EmployeeName"].ToString();
                        employee.EmpType = dr["EmployeeType"].ToString();
                        employee.ExpiryDate = dr["Expirydate"].ToString();
                        employee.PhoneNumber = dr["EmpPhoneNumber"].ToString();
                        employee.Status = dr["Status"].ToString();
                        employee.DateRecorded = dr["RecordDate"].ToString();
                        employees.Add(employee);
                    }
                    ViewBag.Employees = employees;
                }
                else
                {
                    ViewBag.Message = "NO RECORDS FOUND";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View();
        }

        [HttpPost]
        public ActionResult NewEmployeeRecord(FormCollection formCollection)
        {
            try
            {
                AssetManagementDashboardInsideLogic.Models.Employee employee = new AssetManagementDashboardInsideLogic.Models.Employee();
                employee.Address = Request.Form["empaddr"];
                employee.ContractDate = Request.Form["empcontdate"];
                employee.Department = Request.Form["department"];
                employee.DOB = Request.Form["empdob"];
                employee.EmployeeId = Request.Form["empid"];
                employee.EmployeeName = Request.Form["empname"];
                employee.EmpType = Request.Form["emptype"];
                employee.ExpiryDate = Request.Form["empcontexpiry"];
                employee.PhoneNumber = Request.Form["empnum"];
                processor.RegisterEmployee(employee);
                ViewBag.Message = "Employee Has been registered Successfully";
                GetUserDepartments();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
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
    }
}