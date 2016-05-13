using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC2.Models;
using MVC2.Repositories;

namespace MVC2.Service
{
    public class ProductService : Repository<Product>
    {
        private readonly IRepository<Product> _productRep;

     
        public ProductService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _productRep = new Repository<Product>(unitOfWork);
            
        }

        public IEnumerable<Product> Lookup()
        {
            return _productRep.LookupAll();
        }

        public Product GetSingle(int PId)
        {
            return _productRep.GetSingle(d => d.ProductId == PId);
        }

        public int GetMaxID()
        {
            return _productRep.LookupAll().Max(d => d.ProductId);
        }

      
        public void Add(Product product)
        {
            _productRep.Create(product);
           
          
        }

        public void Edit(Product pageData, Product oldData)
        {
            oldData.ProductId = pageData.ProductId;
            oldData.ProductName = pageData.ProductName;
            oldData.Price = pageData.Price;
            oldData.Stock = pageData.Stock;
        }

        public void Delete(Product data)
        {
            _productRep.Remove(data);
        }

        public void Save()
        {
            _productRep.Commit();
        }
    }
}