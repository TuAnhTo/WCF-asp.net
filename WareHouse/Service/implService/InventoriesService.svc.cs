using System;
using System.Collections.Generic;
using System.Linq;
using WareHouse.App_Data;
using WareHouse.Model;

namespace WareHouse
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "InventoriesService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select InventoriesService.svc or InventoriesService.svc.cs at the Solution Explorer and start debugging.
    public class InventoriesService : IInventoriesService
    {
        public bool create(Inventory inventory)
        {
            using (warehousedemoEntities mde = new warehousedemoEntities())
            {
                try
                {
                    inventoryEntity pe = new inventoryEntity();
                   
                    pe.ProductID = inventory.ProductID;
                    pe.Quantity = inventory.Quanlity;
                    mde.inventoryEntities.Add(pe);
                    mde.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool delete(Inventory inventory)
        {
            using (warehousedemoEntities mde = new warehousedemoEntities())
            {
                try
                {
                    inventoryEntity pe = new inventoryEntity();

                    pe.ProductID = inventory.ProductID;
                    pe.Quantity = inventory.Quanlity;
                    mde.inventoryEntities.Remove(pe);
                    mde.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        

        public bool edit(Inventory inventory)
        {
            using (warehousedemoEntities mde = new warehousedemoEntities())
            {
                try
                {
                    int id = Convert.ToInt32(inventory.ProductID);
                    inventoryEntity pe = mde.inventoryEntities.Single(a => a.InventoryID == id);

                    pe.InventoryID = inventory.ProductID;
                    pe.Quantity = inventory.Quanlity;
                    mde.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public List<Inventory> finddAll()
        {
            using (warehousedemoEntities mde = new warehousedemoEntities())
            {

                return mde.inventoryEntities.Select(a => new Inventory
                {
                    ProductID = a.ProductID,
                    Quanlity = a.Quantity
                }).ToList();
            };
        }

        public bool StockIn(Inventory inventory)
        {
            using(warehousedemoEntities mde = new warehousedemoEntities())
            {
                try
                {
                    inventoryEntity pe = new inventoryEntity();
                    var check = mde.inventoryEntities.Where(a => a.ProductID == inventory.ProductID).FirstOrDefault();
                    if (check != null)
                    {

                        check.Quantity = check.Quantity + inventory.Quanlity;
                        mde.Entry(check).State = System.Data.Entity.EntityState.Modified;

                    }
                    else if( check == null)
                    {
                        pe.ProductID = inventory.ProductID;
                        pe.Quantity = inventory.Quanlity;
                        mde.inventoryEntities.Add(pe);
                    }
                    else
                    {
                        mde.inventoryEntities.Add(pe);
                    }
                    mde.SaveChanges();
                    return true;
                } catch
                {
                    return false;
                }
            }
        }

        public bool StockOut(Inventory inventory)
        {
            using (warehousedemoEntities mde = new warehousedemoEntities())
            {
                try
                {
                    inventoryEntity pe = new inventoryEntity();
                    var check = mde.inventoryEntities.Where(a => a.ProductID == inventory.ProductID).FirstOrDefault();
                    if (check != null)
                    {

                        check.Quantity = check.Quantity - inventory.Quanlity;
                        mde.Entry(check).State = System.Data.Entity.EntityState.Modified;

                    }
                    else
                    {
                        mde.inventoryEntities.Add(pe);
                    }
                    mde.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
