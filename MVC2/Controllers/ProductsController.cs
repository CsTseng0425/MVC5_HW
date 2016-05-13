using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC2.Models;
using MVC2.Repositories;
using MVC2.Service;

namespace MVC2.Controllers
{
    public class ProductsController : Controller
    {
        private FabricsEntities db = new FabricsEntities();

        private readonly ProductService _productSvc;

        public ProductsController()
        {
            var unitOfWork = new EFUnitOfWork();
            _productSvc = new ProductService(unitOfWork);

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
            Product product = _productSvc.GetSingle(id.Value);
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
        public ActionResult Create([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product)
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
            Product product = _productSvc.GetSingle(id.Value);
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
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product)
        {
            var oldData = _productSvc.GetSingle(product.ProductId);
            if (oldData != null && ModelState.IsValid)
            {
                _productSvc.Edit(product, oldData);
                _productSvc.Save();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _productSvc.GetSingle(id.Value);
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
            Product product = _productSvc.GetSingle(id);
            _productSvc.Delete(product);
            _productSvc.Save();
            return RedirectToAction("Index");
        }

    }
}
