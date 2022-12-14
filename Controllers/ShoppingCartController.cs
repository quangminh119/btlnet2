using SupperMarket3.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SupperMarket3.Models;

using System.Security.Claims;
using System.Web.Script.Serialization;

namespace SupperMarket3.Controllers
{
    public class ShoppingCartController : Controller
    {
        ShopBanHangEntities objModel = new ShopBanHangEntities();
        // GET: ShoppingCart
       
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
           if(cart == null || Session["Cart"] == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
       
        public ActionResult AddtoCart(int id)
        {
            var pro = objModel.Product.SingleOrDefault(s=>s.IdProduct == id);
            
            if(pro != null)
            {
                GetCart().Add(pro ,1);
            }

            return RedirectToAction("ShowToCart" , "ShoppingCart");

        }
        public ActionResult ShowToCart()
        {
            if(Session["Cart"] == null)
          
                return RedirectToAction("ShowToCart", "ShoppingCart");
                Cart cart = Session["Cart"] as Cart;
         
            return View(cart);

        }
        public ActionResult Update_Quantity(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int id_product = int.Parse(form["Id_Product"]);
            int quantity = int.Parse(form["quantity"]);
            cart.Update(id_product, quantity);
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }
        public ActionResult RemoveCart(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.Remove(id);
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }
        public PartialViewResult BagCart()
        {
            int total_item = 0;
            Cart cart = Session["Cart"] as Cart;
            if (cart != null)
            
                total_item = cart.Sum_Quantity_Giohang(total_item);
                ViewBag.TotalItem = total_item;
                return PartialView("BagCart");
            
        }


    }
    
}