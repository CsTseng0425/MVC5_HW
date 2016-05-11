using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC2.Models.ViewModels;

namespace MVC2.fonts
{
    public class ProductController : Controller
    {

        public ActionResult ProductCreate()
        {

            return View();
        }
        // GET: Product
        public ActionResult ProductList()
        {
            Product[] product = new Product[2];

            product[0] = new Product()
            {
                kind = "A",
                orderDate = "105/05/06",
                price = 100,
                memo = "No stock"
            };

            product[1] = new Product()
            {
                kind = "B",
                orderDate = "105/05/08",
                price = 200,
                memo = "Good"
            };

           
            return View(product);
        }

        [HttpPost]
        public ActionResult ProductList(Product newProduct)
        {
            Product[] product = new Product[3];

            product[0] = new Product()
            {
                kind = "A",
                orderDate = "105/05/06",
                price = 100,
                memo = "No stock"
            };

            product[1] = new Product()
            {
                kind = "B",
                orderDate = "105/05/08",
                price = 200,
                memo = "Good"
            };

              product[2] = new Product()
                {
                    kind = newProduct.kind,
                    orderDate = newProduct.orderDate,
                    price = newProduct.price,
                    memo = newProduct.memo
              };

           

            return View(product);
        }

       
    }
}