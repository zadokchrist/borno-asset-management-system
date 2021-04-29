using AssetManagementDashboardInsideLogic.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementDashboardInsideLogic.Logic
{
    public class Processor
    {
        DatabaseHandler dh = new DatabaseHandler();
        public DataTable dataTable;
        public void CreateUser(string username, string password, string email, string fname, string lname, string department)
        {
            try
            {
                dh.CreateUser(username, password, email, fname, lname, department);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal void CreateJobCard(JobCard jobCard)
        {
            dh.CreateJobCard(jobCard.actiontaken, jobCard.appby, jobCard.blockmapno, jobCard.Callid, jobCard.compdate, jobCard.contractor
                , jobCard.contractornum, jobCard.Dateassigned, jobCard.Datereported, jobCard.fixcond, jobCard.fixturetype, jobCard.Informername,
                jobCard.jobcategory, jobCard.Joblocation, jobCard.jobname, jobCard.material, jobCard.Phnnumber, jobCard.prepby, jobCard.reasonofdelay,
                jobCard.size, jobCard.Source, jobCard.storekeepername, jobCard.Timereported, jobCard.title, jobCard.xcordinates, jobCard.ycordinates);
        }

        internal DataTable GetJobCards()
        {
            try
            {
                dataTable = dh.GetJobCardDetails();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dataTable;
        }

        public DataTable GetHardWareStockWithVendor()
        {
            try
            {
                dataTable = dh.GetHardWareStockWithVendor();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dataTable;
        }

        public DataTable GetEmployees()
        {
            dataTable = dh.GetEmployees();
            return dataTable;
        }

        public DataTable GetSoftwareStockWithVendor()
        {
            try
            {
                dataTable = dh.GetSoftwareStockWithVendor();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dataTable;
        }

        public void DeleteUser(string userid)
        {
            try
            {
                dh.DeleteUser(userid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetCategories()
        {
            try
            {
                dataTable = dh.GetCategories();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dataTable;
        }

        public void CreateWaterLoss(WaterLoss waterLoss)
        {
            try
            {
                dh.CreateWaterLoss(waterLoss.Burstdate, waterLoss.Location, waterLoss.operationalarea, waterLoss.status, waterLoss.xcordinates, waterLoss.ycordinates,waterLoss.remarks);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateUser(SystemUser user)
        {
            try
            {
                dh.CreateUser(user.Fname, user.Lname, user.Uemail, user.Uname, user.Uid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetSystemUsersWithDepartment()
        {
            try
            {
                dataTable = dh.GetSystemUsersWithDepartment();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dataTable;
        }

        public DataTable GetHardWareStock()
        {
            try
            {
                dataTable = dh.GetHardWareStock();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dataTable;
        }

        public void AssigntItem(AssignmentModel assignmentModel)
        {
            try
            {
                dh.AssigntItem(assignmentModel.AssignedTo,assignmentModel.AssignmentType,assignmentModel.DateAssigned,assignmentModel.DateToReturn,assignmentModel.Entity,assignmentModel.Qty);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetLoginDetails(string username,string pwd)
        {
            try
            {
                dataTable = dh.GetLoginDetails(username, pwd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dataTable;
        }

        public DataTable GetAssignedItemsHardware()
        {
            try
            {
                dataTable = dh.GetAssignedItemsHardware();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dataTable;
        }

        public void CreateHardWareStock(HardWareStock hardWareStock)
        {
            try
            {
                dh.CreateHardWareStock(hardWareStock.hw_name, hardWareStock.qty,hardWareStock.avbl_qty,hardWareStock.vid,hardWareStock.dop,hardWareStock.price,hardWareStock.cid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CreateCategory(Category category)
        {
            try
            {
                dh.CreateCategory(category.cname,category.ctype,category.cdesc);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetSystemUsers()
        {
            try
            {
                dataTable = dh.GetAllUsers();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dataTable;
        }
        public DataTable GetAssetRegister()
        {
            try
            {
                dataTable = dh.GetAssetRegister();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dataTable;
        }
        public DataTable GetWaterLossReport()
        {
            try
            {
                dataTable = dh.GetWaterLossReport();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dataTable;
        }

        public DataTable GetSoftwareStock()
        {
            try
            {
                dataTable = dh.GetSoftwareStock();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dataTable;
        }

        public void CreateUserDeparment(Department department)
        {
            try
            {
                dh.CreateDepartment(department.lname, department.room_name, department.floor, department.building);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetUserDepartments()
        {
            try
            {
                dataTable = dh.GetDepartment();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dataTable;
        }

        public DataTable GetSystemUsers(string id)
        {
            try
            {
                dataTable = dh.GetSystemUsersWithDepartment(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dataTable;
        }

        public void CreateVendor(Vendor vendor)
        {
            try
            {
                dh.CreateVendor(vendor.Vname, vendor.cno, vendor.Address, vendor.Email, vendor.website, vendor.thumb);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetVendors()
        {
            try
            {
                dataTable = dh.GetVendors();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dataTable;
        }

        public DataTable GetAssignedItemsSoftware()
        {
            try
            {
                dataTable = dh.GetAssignedItemsSoftware();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dataTable;
        }

        public void CreateSoftwareStock(SoftwareStock softwareStock)
        {
            try
            {
                dh.CreateSoftwareStock(softwareStock.sw_name, softwareStock.serial, softwareStock.vid, softwareStock.dop, softwareStock.price, softwareStock.exp_date, softwareStock.cid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RegisterNetworkAsset(AssetRegister assetRegister)
        {
            try
            {
                dh.RegisterNetworkAsset(assetRegister.Assettype, assetRegister.chamber, assetRegister.condition, assetRegister.markplate, assetRegister.markpost,
                    assetRegister.officername, assetRegister.paytype, assetRegister.PipeMaterial, assetRegister.SerialNum, assetRegister.Size,
                    assetRegister.streetname, assetRegister.xcordinate, assetRegister.ycordinate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RegisterEmployee(Employee employee)
        {
            try
            {
                dh.RegisterEmployee(employee.Address,employee.ContractDate,employee.Department,employee.DOB,employee.EmployeeId,employee.EmployeeName,employee.EmpType,employee.ExpiryDate,employee.PhoneNumber);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
