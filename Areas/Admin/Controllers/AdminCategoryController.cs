using SupperMarket3.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SupperMarket3.Areas.Admin.Controllers
{
    public class AdminCategoryController : Controller
    {
        ShopBanHangEntities objModel = new ShopBanHangEntities();
        // GET: Admin/AdminCategory
        public ActionResult Index()
        {
            var lstCategory = objModel.Categories.ToList();
            return View(lstCategory);
        }

        // GET: Admin/AdminCategory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/AdminCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminCategory/Create
        [HttpPost]
        public ActionResult Create(Categories model)
        {
            try
            {
                objModel.Categories.Add(model);
                objModel.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/AdminCategory/Edit/5
        public ActionResult Edit(int id)
        {
            var editing = objModel.Categories.Find(id);
            return View(editing);
        }

        // POST: Admin/AdminCategory/Edit/5
        [HttpPost]
        public ActionResult Edit(Categories model)
        {
            try
            {
                var oldItem = objModel.Categories.Find(model.CateGoryID);
                oldItem.CatName = model.CatName;
                oldItem.Description = model.Description;
                oldItem.ParentID = model.ParentID;
                oldItem.Levels = model.Levels;
                oldItem.Odering = model.Odering;
                oldItem.Published = model.Published;
                oldItem.Thumb = model.Thumb;
                oldItem.Title = model.Title;
                oldItem.Alias = model.Alias;
                oldItem.MetaDes = model.MetaDes;
                oldItem.MetaKey = model.MetaKey;
                oldItem.Cover = model.Cover;
                oldItem.SchemaMarkup = model.SchemaMarkup;

                objModel.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/AdminCategory/Delete/5
        public ActionResult Delete(int id)
        {
            var deleteing = objModel.Categories.Find(id);
            return View(deleteing);
        }

        // POST: Admin/AdminCategory/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
               var deleting = objModel.Categories.Find(id);
                objModel.Categories.Remove(deleting);
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
