using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewAssetManagementSystem.Controllers
{
    public class NetworkAssetController : Controller
    {
        // GET: NetworkAsset
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NetworkRegister()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NetworkRegister(FormCollection collection)
        {
            try
            {
                AssetManagementDashboardInsideLogic.Models.AssetRegister assetRegister = new AssetManagementDashboardInsideLogic.Models.AssetRegister();
                assetRegister.Assettype = Request.Form["assettype"];
                assetRegister.chamber = Request.Form["chambers"];
                assetRegister.condition = Request.Form["condition"];
                assetRegister.markplate = Request.Form["markplate"];
                assetRegister.markpost = Request.Form["markpost"];
                assetRegister.officername = Request.Form["officername"];
                assetRegister.paytype = Request.Form["paytype"];
                assetRegister.PipeMaterial = Request.Form["pipematerial"];
                assetRegister.SerialNum = Request.Form["serialno"];
                assetRegister.Size = Request.Form["size"];
                assetRegister.streetname = Request.Form["streetname"];
                assetRegister.xcordinate = Request.Form["xcordinate"];
                assetRegister.ycordinate = Request.Form["ycordinate"];
                AssetManagementDashboardInsideLogic.Logic.Processor processor = new AssetManagementDashboardInsideLogic.Logic.Processor();
                processor.RegisterNetworkAsset(assetRegister);
                return RedirectToAction("NetworkRegisterReport", "NetworkAsset");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
            
        }

        public ActionResult NetworkRegisterReport()
        {
            try
            {
                AssetManagementDashboardInsideLogic.Logic.Processor processor = new AssetManagementDashboardInsideLogic.Logic.Processor();
                DataTable assetregisterdata = processor.GetAssetRegister();
                if (assetregisterdata.Rows.Count > 0)
                {
                    List<AssetManagementDashboardInsideLogic.Models.AssetRegister> assetRegisters = new List<AssetManagementDashboardInsideLogic.Models.AssetRegister>();
                    foreach (DataRow dr in assetregisterdata.Rows)
                    {
                        AssetManagementDashboardInsideLogic.Models.AssetRegister assetRegister = new AssetManagementDashboardInsideLogic.Models.AssetRegister();
                        assetRegister.Assettype = dr["AssetType"].ToString();
                        assetRegister.chamber = dr["Chamber"].ToString();
                        assetRegister.condition = dr["Condition"].ToString();
                        assetRegister.markplate = dr["MarkPlate"].ToString();
                        assetRegister.markpost = dr["MarkPost"].ToString();
                        assetRegister.officername = dr["OfficerName"].ToString();
                        assetRegister.paytype = dr["PayType"].ToString();
                        assetRegister.PipeMaterial = dr["PipeMaterial"].ToString();
                        assetRegister.SerialNum = dr["SerialNumber"].ToString();
                        assetRegister.Size = dr["Size"].ToString();
                        assetRegister.streetname = dr["StreetName"].ToString();
                        assetRegister.xcordinate = dr["Xcordinate"].ToString();
                        assetRegister.ycordinate = dr["Ycordinate"].ToString();
                        assetRegister.RecordId = dr["RecordId"].ToString();
                        assetRegisters.Add(assetRegister);
                    }
                    ViewBag.Assetregisters = assetRegisters;
                }
                else
                {
                    ViewBag.Message = "No Assets Found";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            return View();
        }
    }
}