using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace AssetManagementDashboardInsideLogic.Logic
{
    class DatabaseHandler
    {
        DbCommand command;
        Database DbConnection;
        DataTable returntable;

        internal DatabaseHandler()
        {
            try
            {
                DbConnection = DatabaseFactory.CreateDatabase("AssetManagementSystem");
            }
            catch (Exception ex)
            {
                throw ex;
                throw;
            }
        }

        internal void CreateUser( string username,string password,string email,string fname,string lname,string department)
        {
            try
            {
                command = DbConnection.GetStoredProcCommand("CreateUser", username, password, email,fname,lname,department);
                DbConnection.ExecuteNonQuery(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal void CreateJobCard(string actiontaken, string appby, string blockmapno, string callid, string compdate,
            string contractor, string contractornum, string dateassigned, string datereported, string fixcond,
            string fixturetype, string informername, string jobcategory, string joblocation, string jobname,
            string material, string phnnumber, string prepby, string reasonofdelay, string size, string source,
            string storekeepername, string timereported, string title, string xcordinates, string ycordinates)
        {
            try
            {
                command = DbConnection.GetStoredProcCommand("CreateJobCard", actiontaken, appby, blockmapno, callid, compdate,
             contractor, contractornum, dateassigned, datereported, fixcond,
             fixturetype, informername, jobcategory, joblocation, jobname,
             material, phnnumber, prepby, reasonofdelay, size, source,
             storekeepername, timereported, title, xcordinates, ycordinates);
                DbConnection.ExecuteNonQuery(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal DataTable GetEmployeesById(string empid)
        {
            try
            {
                command = DbConnection.GetStoredProcCommand("GetEmployeesById", empid);
                returntable = DbConnection.ExecuteDataSet(command).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returntable;
        }

        internal DataTable GetJobCardDetails()
        {
            try
            {
                command = DbConnection.GetStoredProcCommand("GetJobCard");
                returntable = DbConnection.ExecuteDataSet(command).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returntable;
        }

        internal DataTable GetEmployees()
        {
            try
            {
                command = DbConnection.GetStoredProcCommand("GetEmployees");
                returntable = DbConnection.ExecuteDataSet(command).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returntable;
        }

        internal DataTable GetHardWareStockWithVendor()
        {
            try
            {
                command = DbConnection.GetStoredProcCommand("GetHardWareStockWithVendor");
                returntable = DbConnection.ExecuteDataSet(command).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returntable;
        }

        internal void DeleteUser(string userid)
        {
            try
            {
                command = DbConnection.GetStoredProcCommand("DeleteUser", userid);
                DbConnection.ExecuteNonQuery(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal void CreateFleet(string carType, string model, string driver, string locationOfDuty, string fuelAllocation, string maintainaceSchedule, string insuranceType, string insuranceExpiry)
        {
            command = DbConnection.GetStoredProcCommand("CreateFleet", carType, model, driver, locationOfDuty, fuelAllocation, maintainaceSchedule, insuranceType, insuranceExpiry);
            DbConnection.ExecuteNonQuery(command);
        }

        internal DataTable GetFleet()
        {
            try
            {
                command = DbConnection.GetStoredProcCommand("GetFleet");
                returntable = DbConnection.ExecuteDataSet(command).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returntable;
        }

        internal DataTable GetSoftwareStockWithVendor()
        {
            try
            {
                command = DbConnection.GetStoredProcCommand("GetSoftwareStockWithVendor");
                returntable = DbConnection.ExecuteDataSet(command).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returntable;
        }

        internal void CreateWaterLoss(string burstdate, string location, string operationalarea, string status, string xcordinates, string ycordinates,string remarks)
        {
            try
            {
                command = DbConnection.GetStoredProcCommand("CreateWaterLoss",  burstdate,  location,  operationalarea,  status,  xcordinates, ycordinates,remarks);
                DbConnection.ExecuteDataSet(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal void CreateUser(string fname, string lname, string uemail, string uname, string uid)
        {
            try
            {
                command = DbConnection.GetStoredProcCommand("UpdateSystemUser", fname, lname, uemail, uname, uid);
                DbConnection.ExecuteNonQuery(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal DataTable GetSystemUsersWithDepartment()
        {
            try
            {
                command = DbConnection.GetStoredProcCommand("GetSystemUsersWithDepartment");
                returntable = DbConnection.ExecuteDataSet(command).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returntable;
        }

        internal void AssigntItem(string assignedTo, string assignmentType, string dateAssigned, string dateToReturn, string entity, string qty)
        {
            try
            {
                command = DbConnection.GetStoredProcCommand("AssignToUser", entity, assignmentType, qty, assignedTo, dateAssigned, dateToReturn);
                DbConnection.ExecuteNonQuery(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal DataTable GetCategories()
        {
            try
            {
                command = DbConnection.GetStoredProcCommand("GetAllCategories");
                returntable = DbConnection.ExecuteDataSet(command).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returntable;
        }

        internal DataTable GetAssignedItemsHardware()
        {
            try
            {
                command = DbConnection.GetStoredProcCommand("GetAssignedItemsHardware");
                returntable = DbConnection.ExecuteDataSet(command).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returntable;
        }

        internal DataTable GetHardWareStock()
        {
            try
            {
                command = DbConnection.GetStoredProcCommand("GetHardWareStock");
                returntable = DbConnection.ExecuteDataSet(command).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returntable;
        }

        internal DataTable GetAssetRegister()
        {
            try
            {
                command = DbConnection.GetStoredProcCommand("GetAssetRegister");
                returntable = DbConnection.ExecuteDataSet(command).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returntable;
        }

        internal void CreateHardWareStock(string hw_name, string qty, string avbl_qty, string vid, string dop, string price, string cid)
        {
            try
            {
                command = DbConnection.GetStoredProcCommand("CreateHardWareStock", hw_name, qty, avbl_qty, vid, dop, price, cid);
                DbConnection.ExecuteNonQuery(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal DataTable GetLoginDetails(string username,string pwd)
        {
            try
            {
                command = DbConnection.GetStoredProcCommand("GetLoginDetails", username, pwd);
                returntable = DbConnection.ExecuteDataSet(command).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returntable;
        }

        internal DataTable GetSoftwareStock()
        {
            try
            {
                command = DbConnection.GetStoredProcCommand("GetSoftwareStock");
                returntable = DbConnection.ExecuteDataSet(command).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returntable;
        }

        internal DataTable GetSystemUsersWithDepartment(string id)
        {
            try
            {
                command = DbConnection.GetStoredProcCommand("GetSystemUsersWithDepartmentById", id);
                returntable = DbConnection.ExecuteDataSet(command).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returntable;
        }

        internal void CreateCategory(string cname, string ctype, string cdesc)
        {
            try
            {
                command = DbConnection.GetStoredProcCommand("CreateCategory", cname, ctype, cdesc);
                DbConnection.ExecuteNonQuery(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal DataTable GetAllUsers()
        {
            try
            {
                command = DbConnection.GetStoredProcCommand("GetSystemUsers");
                returntable = DbConnection.ExecuteDataSet(command).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returntable;
        }

        internal DataTable GetWaterLossReport()
        {
            try
            {
                command = DbConnection.GetStoredProcCommand("GetWaterLossReport");
                returntable = DbConnection.ExecuteDataSet(command).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returntable;
        }

        internal void RegisterNetworkAsset(string assettype, string chamber, string condition, string markplate, string markpost, string officername, string paytype, string pipeMaterial, string serialNum, string size, string streetname, string xcordinate, string ycordinate)
        {
            try
            {
                command = DbConnection.GetStoredProcCommand("RegisterNetworkAsset", assettype, chamber, condition, markplate, markpost, officername, paytype, pipeMaterial,
                    serialNum, size, streetname, xcordinate, ycordinate);
                DbConnection.ExecuteNonQuery(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal void RegisterEmployee(string address, string contractDate, string department, string dOB, string employeeId, string employeeName, string empType, string expiryDate, string phoneNumber)
        {
            try
            {
                command = DbConnection.GetStoredProcCommand("RegisterEmployee", address, contractDate, department, dOB, employeeId, employeeName, empType, expiryDate, phoneNumber);
                DbConnection.ExecuteNonQuery(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal DataTable GetAssignedItemsSoftware()
        {
            try
            {
                command = DbConnection.GetStoredProcCommand("GetAssignedItemsSoftware");
                returntable = DbConnection.ExecuteDataSet(command).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returntable;
        }

        internal void CreateDepartment(string lname,string roomname,string floor,string building)
        {
            try
            {
                command = DbConnection.GetStoredProcCommand("CreateDepartment", lname, roomname, floor, building);
                DbConnection.ExecuteNonQuery(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal void CreateSoftwareStock(string sw_name, string serial, string vid, string dop, string price, string exp_date, string cid)
        {
            try
            {
                command = DbConnection.GetStoredProcCommand("CreateSoftwareStock", sw_name, serial, vid, dop, price, exp_date, cid);
                DbConnection.ExecuteNonQuery(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal DataTable GetDepartment()
        {
            try
            {
                command = DbConnection.GetStoredProcCommand("GetUserDepartment");
                returntable = DbConnection.ExecuteDataSet(command).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returntable;
        }

        internal DataTable GetVendors()
        {
            try
            {
                command = DbConnection.GetStoredProcCommand("GetVendors");
                returntable = DbConnection.ExecuteDataSet(command).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returntable;
        }

        internal void CreateVendor(string Vname, string cno, string Address, string Email, string website, string thumb)
        {
            try
            {
                command = DbConnection.GetStoredProcCommand("CreateVendor", Vname, cno, Address, Email, website, thumb);
                DbConnection.ExecuteNonQuery(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
