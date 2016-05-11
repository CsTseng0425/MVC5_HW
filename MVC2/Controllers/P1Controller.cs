using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC2.Models.ViewModels;

namespace MVC2.Controllers
{
    public class P1Controller : Controller
    {
        // GET: P1
        public ActionResult Index()
        {
            return View(new MyViewModel()
            {
                Message = "Welcome to ASP.NET MVC!",
                UserLevel = 3,
                IsMaster = true
             
            });
        }
    }
}