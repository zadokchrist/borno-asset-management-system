using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewAssetManagementSystem.Controllers
{
    public class CategoryController : Controller
    {
        AssetManagementDashboardInsideLogic.Logic.Processor processor = new AssetManagementDashboardInsideLogic.Logic.Processor();
        // GET: Category
        public ActionResult ViewCategories()
        {
            GetCategories();
            return View();
        }

        public ActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCategory(FormCollection cat)
        {
            try
            {
                AssetManagementDashboardInsideLogic.Models.Category category = new AssetManagementDashboardInsideLogic.Models.Category();
                category.cname = Request["catname"];
                category.ctype = Request["cattype"];
                category.cdesc = Request["catdesc"];
                processor.CreateCategory(category);
                ViewBag.Message = "Category has been Created Successfully";
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return View();
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