using SupperMarket3.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SupperMarket3.Areas.Admin.Controllers
{
    public class AdminRolesController : Controller
    {

        ShopBanHangEntities objModel = new ShopBanHangEntities();
        // GET: Admin/AdminRoles
        public ActionResult Index()
        {
            var lstRoles = objModel.Roles.ToList();
            return View(lstRoles);
        }



        // GET: Admin/AdminRoles/Create
     
        public ActionResult Create()
        {
                return View();      
        }

        // POST: Admin/AdminRoles/Create
        [HttpPost]
        public ActionResult Create(Roles model)
        {
            try
            {
               objModel.Roles.Add(model);
                objModel.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/AdminRoles/Edit/5
        public ActionResult Edit(int id)
        {
            var editing = objModel.Roles.Find(id);
            return View(editing);
        }

        // POST: Admin/AdminRoles/Edit/5
        [HttpPost]
        public ActionResult Edit(Roles model)
        {
            try
            {
                var oldItem = objModel.Roles.Find(model.RoleID);
                oldItem.RoleName = model.RoleName;
                oldItem.Description = model.Description;
                objModel.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/AdminRoles/Delete/5
        public ActionResult Delete(int id)
        {
            var objRoles = objModel.Roles.Where(x => x.RoleID == id).FirstOrDefault();
            return View(objRoles);
        }

        // POST: Admin/AdminRoles/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var deleting = objModel.Roles.Find(id);
                objModel.Roles.Remove(deleting);
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
