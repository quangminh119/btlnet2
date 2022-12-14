using SupperMarket3.Context;
using SupperMarket3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SupperMarket3.Controllers
{
    public class PreviewController : Controller
    {
        // GET: Preview
        ShopBanHangEntities objModel = new ShopBanHangEntities();
        public ActionResult Index(int Id)
        {
            //Lay thong tin san pham theo Id truyen vao.
            var objProduct = objModel.Product.Where(n => n.IdProduct == Id).FirstOrDefault();

            //Lay danh sach danh muc
            var lstCategory = objModel.Categories.ToList();

            //Lay san pham lien quan lay tu IdCat trong bang Product
            var lstProduct = objModel.Product.Where(n => n.CateGoryID == objProduct.CateGoryID).ToList();

            PreviewDetailModel ObjPreviewDetailModel = new PreviewDetailModel();
            ObjPreviewDetailModel.lstProducts = lstProduct;
            ObjPreviewDetailModel.objProduct = objProduct;
            ObjPreviewDetailModel.lstCategory = lstCategory;
            return View(ObjPreviewDetailModel);
        }
    }
}