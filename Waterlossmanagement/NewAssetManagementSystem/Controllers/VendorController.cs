using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewAssetManagementSystem.Controllers
{
    public class VendorController : Controller
    {
        AssetManagementDashboardInsideLogic.Logic.Processor processor = new AssetManagementDashboardInsideLogic.Logic.Processor();
        // GET: Vendor
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateVendor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateVendor(HttpPostedFileBase fileBase)
        {
            try
            {
                AssetManagementDashboardInsideLogic.Models.Vendor vendor = new AssetManagementDashboardInsideLogic.Models.Vendor();
                vendor.Vname = Request.Form["vendorname"];
                vendor.cno = Request.Form["contactnumber"];
                vendor.Address = Request.Form["address"];
                vendor.thumb = Request.Form["Image"];
                vendor.Email = Request.Form["emailid"];
                vendor.website = Request.Form["website"];
                processor.CreateVendor(vendor);
                ViewBag.Message = "Vendor has been created successfully";
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View();
        }

        public ActionResult ViewVendors()
        {
            GetVendors();
            return View();
        }

        public void GetVendors()
        {
            try
            {
                DataTable vendorsdata = processor.GetVendors();
                if (vendorsdata.Rows.Count > 0)
                {
                    List<AssetManagementDashboardInsideLogic.Models.Vendor> vendors = new List<AssetManagementDashboardInsideLogic.Models.Vendor>();
                    foreach (DataRow dr in vendorsdata.Rows)
                    {
                        AssetManagementDashboardInsideLogic.Models.Vendor vendor = new AssetManagementDashboardInsideLogic.Models.Vendor();
                        vendor.Address = dr["Address"].ToString();
                        vendor.Id = dr["Id"].ToString();
                        vendor.Vname = dr["Vname"].ToString();
                        vendor.cno = dr["cno"].ToString();
                        vendor.Email = dr["Email"].ToString();
                        vendor.website = dr["website"].ToString();
                        vendor.thumb = dr["thumb"].ToString();
                        vendors.Add(vendor);
                    }
                    ViewBag.Vendors = vendors;
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