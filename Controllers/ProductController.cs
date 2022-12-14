using SupperMarket3.Context;
using SupperMarket3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SupperMarket3.Controllers
{
    public class ProductController : Controller
    {
        ShopBanHangEntities objModel = new ShopBanHangEntities();
        // GET: Product
        public ActionResult Index()
        {
            var lstProduct = new List<Product>();
            string cateId = HttpContext.Request.Params["CategoryId"];
            if (cateId != null)
            {
                int catId = Convert.ToInt32(cateId);
                lstProduct = objModel.Product.Where(n => n.CateGoryID == catId).ToList();
            }
            else
                lstProduct = objModel.Product.Where(n => n.CateGoryID == 23).ToList();
            var lstCategory = objModel.Categories.ToList();

            Product_Category objProductCategory = new Product_Category();
            objProductCategory.Products = lstProduct;
            objProductCategory.Categories = lstCategory;
            return View(objProductCategory);
           
        }
    }
}