using SupperMarket3.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupperMarket3.Models
{
    public class Product_Category
    {
        public List<Product> Products { get; set; }
        public List<Categories> Categories { get; set; }
    }
}