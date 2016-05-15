using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC2.Models;
using MVC2.Repositories;
using MVC2.ViewModel;

namespace MVC2.Service
{
    public class ProductVMService : Repository<Product>
    {
        private readonly IRepository<Product> _productRep;

     
        public ProductVMService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _productRep = new Repository<Product>(unitOfWork);
            
        }

        public IEnumerable<ProductsViewModel> Lookup()
        {
            var source = _productRep.LookupAll().Take(5);
            var result = source.Select(product => new ProductsViewModel()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Active = product.Active,
                Price = product.Price,
                Stock = product.Stock,
              
            }).ToList();
            return result;
        }

        public ProductsViewModel GetSingle(int PId)
        {
            //  return _productRep.GetSingle(d => d.ProductId == PId);

            var source = _productRep.GetSingle(d => d.ProductId == PId);
            
            ProductsViewModel product = new ProductsViewModel 
            {
                ProductId = source.ProductId,
                ProductName = source.ProductName,
                Active = source.Active,
                Price = source.Price,
                Stock = source.Stock,

            };
            return product;
        }

        public int GetMaxID()
        {
            return _productRep.LookupAll().Max(d => d.ProductId);

        }

        public void Add(ProductsViewModel product)
        {
            var result = new Product()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Price = product.Price,
                Active = product.Active,
                Stock = product.Stock
            };

            Add(result);
        }

        public void Add(Product product)
        {
            _productRep.Create(product);
           
          
        }

        public ProductsViewModel Edit(int pid)
        {
            var hasOldData = _productRep.Query(d => d.ProductId == pid).Count() > 0;
            Product product = _productRep.GetSingle(d => d.ProductId == pid);
            if (hasOldData)
            {
                ProductsViewModel VMproduct
                = new ProductsViewModel
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    Price = product.Price,
                    Active = product.Active,
                    Stock = product.Stock
                };
                return VMproduct;
            }
            else
            {
                return null;
            }

        }

        public bool Edit(ProductsViewModel pageData)
        {
            var hasOldData = _productRep.Query(d => d.ProductId == pageData.ProductId).Count() > 0;
         
            if(hasOldData )
            {
                Product oldProduct = _productRep.GetSingle(d =>d.ProductId== pageData.ProductId);
               oldProduct.ProductName = pageData.ProductName;
                oldProduct.Price = pageData.Price;
                oldProduct.Active = pageData.Active;
                oldProduct.Stock = pageData.Stock;
                return true;

            }
            else
            {
                return false;
            }
            
        }

        public bool Delete(int? pid)
        {
         
            Product product = _productRep.GetSingle(d => d.ProductId == pid);
            if (product==null)
            {
                return false;
            }
            else
            {
                Delete(product);
                return true;
            }

        }




        public bool Delete(ProductsViewModel data)
        {
            var hasData = _productRep.Query(d => d.ProductId==data.ProductId).Count()>0;

            if(hasData)
            {
                Product delData = _productRep.GetSingle(d => d.ProductId == data.ProductId);
                Delete(delData);
                return true;
            }
            else
            {
                return false;
            }
           
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