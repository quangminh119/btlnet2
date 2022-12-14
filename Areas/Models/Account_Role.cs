using SupperMarket3.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupperMarket3.Areas.Models
{
    public class Account_Role
    {
        public List<Accounts> Accounts { get; set; }
        public List<Roles> Roles { get; set; }
    }
}