using SupperMarket3.Context;
using SupperMarket3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SupperMarket3.Controllers
{
    public class HomeController : Controller
    {
        ShopBanHangEntities objModel = new ShopBanHangEntities();
        // GET: Homee
        public ActionResult Index()
        {
            var lstProduct = objModel.Product.ToList();
            var lstCategory = objModel.Categories.ToList();

            Product_Category objProductCategory = new Product_Category();
            objProductCategory.Products = lstProduct;
            objProductCategory.Categories = lstCategory;
            return View(objProductCategory);
        }
    }
}
