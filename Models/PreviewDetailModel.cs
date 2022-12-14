using System;
using SupperMarket3.Context;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupperMarket3.Models
{
    public class PreviewDetailModel
    {
        public Product objProduct { get; set; }
        public List<Categories> lstCategory { get; set; }
        public List<Product> lstProducts { get; set; }
    }
}