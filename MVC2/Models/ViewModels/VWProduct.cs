using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC2.Models.ViewModels
{
    public class VWProduct
    {
        public int PID { get; set; }
        public string PNAME { get; set; }
        public decimal PRICE { get; set; }
        public string MEMO { get; set; }
    }
}