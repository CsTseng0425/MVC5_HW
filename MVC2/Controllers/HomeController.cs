using MVC2.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Message = "This is login page";

            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel pageData)
        {
            if (pageData.Account == "skill" &&
            pageData.Password == "tree")
            {
                pageData.Message =
                $"您使用{pageData.Account}登入成功。";
            }
            return View(pageData);
        }
    }
}