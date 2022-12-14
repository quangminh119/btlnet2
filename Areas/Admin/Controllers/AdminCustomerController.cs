using SupperMarket3.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SupperMarket3.Areas.Admin.Controllers
{
    public class AdminCustomerController : Controller
    {
        ShopBanHangEntities objModel = new ShopBanHangEntities();
        // GET: Admin/AdminCustomer
        public ActionResult Index()
        {
            var lstCustomer = objModel.Customer.ToList();
            return View(lstCustomer);
        }

        // GET: Admin/AdminCustomer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/AdminCustomer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AdminCustomer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/AdminCustomer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/AdminCustomer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/AdminCustomer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/AdminCustomer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
