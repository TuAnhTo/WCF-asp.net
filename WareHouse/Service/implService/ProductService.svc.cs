using System;
using System.Collections.Generic;
using System.Linq;
using WareHouse.App_Data;
using WareHouse.Model;

namespace WareHouse
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProductService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ProductService.svc or ProductService.svc.cs at the Solution Explorer and start debugging.
    public class ProductService : IProductService
    {
        public ProductService() {}

        public bool create(Product product)
        {
           using(warehousedemoEntities mde = new warehousedemoEntities())
            {
                try
                {
                    ProductEntity pe = new ProductEntity();
                    pe.ProductName = product.ProductName;
                    pe.ProductCode = product.ProductCode;
                    mde.ProductEntities.Add(pe);
                    mde.SaveChanges();
                    return true;
                } catch
                {
                    return false;
                }
            }
        }

        public bool delete(Product product)
        {
            using (warehousedemoEntities mde = new warehousedemoEntities())
            {
                try
                {
                    int id = Convert.ToInt32(product.ProductID);
                    ProductEntity pe = mde.ProductEntities.Single(a => a.ProductID == id);

                    pe.ProductName = product.ProductName;
                    pe.ProductCode = product.ProductCode;
                    mde.ProductEntities.Remove(pe);
                    mde.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }   
        }

        

        public bool edit(Product product)
        {
            using(warehousedemoEntities mde = new warehousedemoEntities())
            {
                try
                {
                    int id = Convert.ToInt32(product.ProductID);
                    ProductEntity pe = mde.ProductEntities.Single(a => a.ProductID == id);

                    pe.ProductName = product.ProductName;
                    pe.ProductCode = product.ProductCode;
                    mde.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        

        public List<Product> finddAll()
        {
            using (warehousedemoEntities mde = new warehousedemoEntities())
            {

                return mde.ProductEntities.Select(a => new Product
                {
                    ProductName = a.ProductName,
                    ProductCode = a.ProductCode
                }).ToList();
            } ;
        }
    }
}
