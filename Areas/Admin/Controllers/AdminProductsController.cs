using SupperMarket3.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SupperMarket3.Areas.Admin.Controllers
{
    public class AdminProductsController : Controller
    {
        ShopBanHangEntities objModel = new ShopBanHangEntities();
        // GET: Admin/AdminProducts
        public ActionResult Index()
        {
            var lstProducts = objModel.Product.ToList();
            return View(lstProducts);
        }

       

        // GET: Admin/AdminProducts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminProducts/Create
        [HttpPost]
        public ActionResult Create(Product model)
        {
           
            try
            {
               objModel.Product.Add(model);
                model.DateCreate = DateTime.Now;
                model.DateModified  = DateTime.Now;
                objModel.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/AdminProducts/Edit/5
        public ActionResult Edit(int id)
        {
            var editing = objModel.Product.Find(id);
            return View(editing);
        }

        // POST: Admin/AdminProducts/Edit/5
        [HttpPost]
        public ActionResult Edit(Product model)
        {
            try
            {
               
              var oldItem = objModel.Product.Find(model.IdProduct);
                oldItem.Name = model.Name;
                oldItem.Price = model.Price;
                oldItem.PriceSale = model.PriceSale;
                oldItem.CateGoryID = model.CateGoryID;
                oldItem.Avatar = model.Avatar;
                oldItem.Discount = model.Discount;
                oldItem.Thumb = model.Thumb;
                oldItem.Video = model.Video;
                oldItem.DateCreate = model.DateCreate;
                oldItem.DateModified = model.DateModified;
                oldItem.BestSellers = model.BestSellers;
                oldItem.HomeFlag = model.HomeFlag;
                oldItem.Active = model.Active;
                oldItem.Tag = model.Tag;
                oldItem.Alias = model.Alias;
                oldItem.MetaKey = model.MetaKey;
                oldItem.MetaDesc = model.MetaDesc;
                oldItem.UnitslnStock = model.UnitslnStock;
                objModel.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/AdminProducts/Delete/5
        public ActionResult Delete(int id)
        {
            var deleting = objModel.Product.Find(id);
            return View();
        }

        // POST: Admin/AdminProducts/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var deleting = objModel.Product.Find(id);
                objModel.Product.Remove(deleting);
                objModel.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
