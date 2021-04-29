using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewAssetManagementSystem.Controllers
{
    public class StockController : Controller
    {
        AssetManagementDashboardInsideLogic.Logic.Processor processor = new AssetManagementDashboardInsideLogic.Logic.Processor();
        public ActionResult CreateHadwareStock()
        {
            GetCategories();
            GetVendors();
            return View();
        }

        public ActionResult CreateSoftwareStock()
        {
            GetCategories();
            GetVendors();
            return View();
        }

        public ActionResult ViewHardWareStock()
        {
            try
            {
                DataTable hardwrstockdata = processor.GetHardWareStock();
                if (hardwrstockdata.Rows.Count > 0)
                {
                    List<AssetManagementDashboardInsideLogic.Models.HardWareStock> hardWareStocks = new List<AssetManagementDashboardInsideLogic.Models.HardWareStock>();
                    foreach (DataRow dr in hardwrstockdata.Rows)
                    {
                        AssetManagementDashboardInsideLogic.Models.HardWareStock hardWareStock = new AssetManagementDashboardInsideLogic.Models.HardWareStock();
                        hardWareStock.id = dr["id"].ToString();
                        hardWareStock.hw_name = dr["hw_name"].ToString();
                        hardWareStock.qty = dr["qty"].ToString();
                        hardWareStock.avbl_qty = dr["avbl_qty"].ToString();
                        hardWareStock.vid = dr["vid"].ToString();
                        hardWareStock.dop = dr["dop"].ToString();
                        hardWareStock.price = dr["price"].ToString();
                        hardWareStock.cid = dr["cid"].ToString();
                        hardWareStocks.Add(hardWareStock);
                    }
                    ViewBag.HardwareStock = hardWareStocks;
                }
                else
                {
                    ViewBag.Message = "No Hardware Stock Found";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            return View();
        }

        public ActionResult ViewSoftwareStock()
        {
            try
            {
                DataTable softwarestockdata = processor.GetSoftwareStock();
                if (softwarestockdata.Rows.Count > 0)
                {
                    List<AssetManagementDashboardInsideLogic.Models.SoftwareStock> softwarestocks = new List<AssetManagementDashboardInsideLogic.Models.SoftwareStock>();
                    foreach (DataRow dr in softwarestockdata.Rows)
                    {
                        AssetManagementDashboardInsideLogic.Models.SoftwareStock softwareStock = new AssetManagementDashboardInsideLogic.Models.SoftwareStock();
                        softwareStock.id = dr["id"].ToString();
                        softwareStock.sw_name = dr["sw_name"].ToString();
                        softwareStock.serial = dr["serial"].ToString();
                        softwareStock.vid = dr["vid"].ToString();
                        softwareStock.dop = dr["dop"].ToString();
                        softwareStock.price = dr["price"].ToString();
                        softwareStock.exp_date = dr["exp_date"].ToString();
                        softwareStock.cid = dr["cid"].ToString();
                        softwarestocks.Add(softwareStock);
                    }
                    ViewBag.SoftwareStock = softwarestocks;
                }
                else
                {
                    ViewBag.Message = "No Software Stock Found";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            return View();
        }

        [HttpPost]
        public ActionResult CreateHadwareStock(FormCollection hardwaresorck)
        {
            try
            {
                AssetManagementDashboardInsideLogic.Models.HardWareStock hardWareStock = new AssetManagementDashboardInsideLogic.Models.HardWareStock();
                hardWareStock.hw_name = Request.Form["hardwarename"];
                hardWareStock.qty = Request.Form["qty"];
                hardWareStock.avbl_qty = Request.Form["qty"];
                hardWareStock.vid = Request.Form["vname"];
                hardWareStock.dop = Request.Form["dop"];
                hardWareStock.price = Request.Form["unitprice"];
                hardWareStock.cid = Request.Form["cat"];
                processor.CreateHardWareStock(hardWareStock);
                ViewBag.Message = "Hardware Stock has been Added Successfully";
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View();
        }

        [HttpPost]
        public ActionResult CreateSoftwareStock(FormCollection hardwaresorck)
        {
            try
            {
                AssetManagementDashboardInsideLogic.Models.SoftwareStock softwareStock = new AssetManagementDashboardInsideLogic.Models.SoftwareStock();
                softwareStock.sw_name = Request.Form["softwarename"];
                softwareStock.serial = Request.Form["serialkey"];
                softwareStock.vid = Request.Form["vname"];
                softwareStock.dop = Request.Form["dop"];
                softwareStock.exp_date = Request.Form["doe"];
                softwareStock.price = Request.Form["unitprice"];
                softwareStock.cid = Request.Form["cat"];
                processor.CreateSoftwareStock(softwareStock);
                ViewBag.Message = "Software Stock has been Added Successfully";
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
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

        private void GetCategories()
        {
            try
            {
                DataTable categorydata = processor.GetCategories();
                if (categorydata.Rows.Count > 0)
                {
                    List<AssetManagementDashboardInsideLogic.Models.Category> categories = new List<AssetManagementDashboardInsideLogic.Models.Category>();
                    foreach (DataRow dr in categorydata.Rows)
                    {
                        AssetManagementDashboardInsideLogic.Models.Category category = new AssetManagementDashboardInsideLogic.Models.Category();
                        category.cid = dr["cid"].ToString();
                        category.cname = dr["cname"].ToString();
                        category.ctype = dr["ctype"].ToString();
                        category.cdesc = dr["cdesc"].ToString();
                        category.RecordDate = dr["RecordDate"].ToString();
                        categories.Add(category);
                    }
                    ViewBag.Categories = categories;
                }
                else
                {
                    ViewBag.Message = "No Category Found";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
        }
    }
}