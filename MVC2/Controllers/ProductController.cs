using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC2.Models.ViewModels;
using MVC2.Models;

namespace MVC2.Controllers
{
    public class ProductController : Controller
    {
        private FabricsEntities db = new FabricsEntities();

        public ActionResult ProductCreate()
        {

            return View();
        }
        // GET: Product
        public ActionResult ProductList()
        {
            VWProduct[] product = new VWProduct[5];
            int i = 0;

            foreach (var p in db.Product.Take(5))
            {
                string strMemo;
                if (p.Active == true)
                    strMemo = "Avaible";
                else
                    strMemo = "No Avaible";

                product[i] = new VWProduct()
                {
                    PID = p.ProductId,
                    PNAME = p.ProductName,
                    PRICE = (decimal)p.Price,
                    MEMO = strMemo

                };


                i++;
            }

            return View(product);
        }

        [HttpPost]
        public ActionResult ProductList(VWProduct newProduct)
        {
            VWProduct[] product = new VWProduct[6];
            int i = 0;

            foreach (var p in db.Product.Take(5))
            {
                string strMemo;
                if (p.Active == true)
                    strMemo = "Avaible";
                else
                    strMemo = "No Avaible";

                product[i] = new VWProduct()
                {
                    PID = p.ProductId ,
                    PNAME = p.ProductName,
                    PRICE = (decimal) p.Price,
                    MEMO = strMemo

                };
               
                
                i++;
            }



            product[i] = new VWProduct()
                {
                  PID = newProduct.PID,
                  PNAME = newProduct.PNAME,
                  PRICE = newProduct.PRICE,
                  MEMO = newProduct.MEMO
              };

           

            return View(product);
        }

       
    }
}