using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC2.Models.ViewModels
{
    public class Product
    {
        public string kind { get; set; }
        public string orderDate { get; set; }
        public int price { get; set; }
        public string memo { get; set; }
    }
}