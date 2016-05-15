using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC2.ViewModel;
using MVC2.Repositories;
using MVC2.Service;

namespace MVC2.Controllers
{
    public class ProductsVMController : Controller
    {
      
        private readonly ProductVMService _productSvc;

        public ProductsVMController()
        {
            var unitOfWork = new EFUnitOfWork();
            _productSvc = new ProductVMService(unitOfWork);

        }
        // GET: Orders
        public ActionResult Index()
        {
            return View(_productSvc.Lookup());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = _productSvc.Edit(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] ProductsViewModel product)
        {
            if (ModelState.IsValid)
            {
                product.ProductId = _productSvc.GetMaxID() + 1;
                _productSvc.Add(product);
                _productSvc.Save();
                //  UnitOfWork.Save(); => 拉出出執行,比較明確
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = _productSvc.Edit(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Orders/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] ProductsViewModel product)
        {
            if (_productSvc.Edit(product))
            {
                _productSvc.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = _productSvc.Edit(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var product = _productSvc.GetSingle(id);
            _productSvc.Delete(product);
            _productSvc.Save();
            return RedirectToAction("Index");
        }

    }
}
