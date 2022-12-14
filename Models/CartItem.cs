using SupperMarket3.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupperMarket3.Models
{
    [Serializable]
    public class CartItem
    {
       public Product Product { get; set; }
        public int Quantity { get; set; }
      
    }
    public class Cart
    {
       List<CartItem> items = new List<CartItem>();
        public IEnumerable<CartItem> Items
        {
            get { return items; }
        }
        public void Add(Product _product, int _quantity)
        {
            var item = items.FirstOrDefault(s => s.Product.IdProduct == _product.IdProduct);
            if (item == null)
            {
                items.Add(new CartItem
                {
                    Product = _product,
                    Quantity = _quantity
                });
            }
            else
            {
                item.Quantity += _quantity;
            }
        }
        public void Update(int id , int _quantity)
        {
        var item = items.FirstOrDefault(s => s.Product.IdProduct == id);
            if(item != null)
            {
                item.Quantity = _quantity;
            }
        }
        public double Sum_total()
        {
            var SumPice = items.Sum(s=>s.Product.PriceSale * s.Quantity);
            return (double)SumPice;
        }
        public void Remove(int id)
        {
            items.RemoveAll(s => s.Product.IdProduct == id);
        }

        //tinh so luong gio hang 
        public int Sum_Quantity_Giohang(int id)
        {
           return items.Sum(s => s.Quantity);

        }
        //Xoa gio hang
        public void Clear()
        {
            items.Clear();
        }

      
    }
}