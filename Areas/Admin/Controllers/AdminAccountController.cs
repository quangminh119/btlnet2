using SupperMarket3.Areas.Models;
using SupperMarket3.Context;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SupperMarket3.Areas.Admin.Controllers
{
    public class AdminAccountController : Controller
    {
        ShopBanHangEntities objModel = new ShopBanHangEntities();

        // GET: Admin/AdminAccount
        public ActionResult Index()
        {
            var lstAccount = objModel.Accounts.ToList();
            var lstRole = objModel.Roles.ToList();

            Account_Role objAccountRole = new Account_Role();
            objAccountRole.Accounts = lstAccount;
            objAccountRole.Roles = lstRole;
            return View(objAccountRole);
        }

     
        // GET: Admin/AdminAccount/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminAccount/Create
        [HttpPost]
        public ActionResult Create(Accounts model)
        {
            try
            {
                objModel.Accounts.Add(model);
                objModel.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/AdminAccount/Edit/5
        public ActionResult Edit(int id)
        {
            var editing = objModel.Accounts.Find(id);
            return View(editing);
        
        }

        // POST: Admin/AdminAccount/Edit/5
        [HttpPost]
        public ActionResult Edit(Accounts model)
        {
            try
            {
                var oldItem = objModel.Accounts.Find(model.AccountID);
                oldItem.FullName = model.FullName;
                oldItem.Phone = model.Phone;
                oldItem.Email = model.Email;
                oldItem.Password = model.Password;
                oldItem.Salt = model.Salt;
                oldItem.Active = model.Active;
                oldItem.RoleID = model.RoleID;
                oldItem.LastLogin = model.LastLogin;
                oldItem.CreateDate = model.CreateDate;

                objModel.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/AdminAccount/Delete/5
        public ActionResult Delete(int id)
        {

            var deleteing = objModel.Accounts.Find(id);
            return View(deleteing);
        }

        // POST: Admin/AdminAccount/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var deleting = objModel.Accounts.Find(id);
                objModel.Accounts.Remove(deleting);
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
