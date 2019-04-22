using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using POS.Models.Operation;
using POS.Models.Setup;

namespace POS.DAL.Operation
{
    public class PurchaseGetway
    {
        PosDbContext dbContext = new PosDbContext();
        public IEnumerable<SelectListItem> GetItemSelectList()
        {
            var list = dbContext.Items.ToList();

            var selectList = new List<SelectListItem>()
            {
                new SelectListItem { Text = "---Select---", Value = "", Selected = true }
            };

            selectList.AddRange(list.Select(li => new SelectListItem { Text = li.Code + " - " + li.Name, Value = li.Id.ToString() }));

            return selectList;
        }
        public IEnumerable<SelectListItem> GetBranchSelectList()
        {
            var list = dbContext.Branches.ToList();

            var selectList = new List<SelectListItem>()
            {
                new SelectListItem { Text = "---Select---", Value = "", Selected = true }
            };

            selectList.AddRange(list.Select(li => new SelectListItem { Text = li.Address, Value = li.Id.ToString() }));

            return selectList;
        }
        public IEnumerable<SelectListItem> GetEmployeeSelectList()
        {
            var list = dbContext.Employees.ToList();

            var selectList = new List<SelectListItem>()
            {
                new SelectListItem { Text = "---Select---", Value = "", Selected = true }
            };

            selectList.AddRange(list.Select(li => new SelectListItem { Text = li.Name, Value = li.Id.ToString() }));

            return selectList;
        }
        public IEnumerable<SelectListItem> GetSupplierSelectList()
        {
            var list = dbContext.Parties.Where(x => x.IsSupplier == true).ToList();

            var selectList = new List<SelectListItem>()
            {
                new SelectListItem { Text = "---Select---", Value = "", Selected = true }
            };

            selectList.AddRange(list.Select(li => new SelectListItem { Text = li.Name, Value = li.Id.ToString() }));

            return selectList;
        }

        public List<Employee> GetEmployeeList(long branchId)
        {
            var employeeList = dbContext.Employees.Where(x => x.BranchId == branchId).ToList();
            return employeeList;
        }

        public bool IsPurchaseOperationSuccess(PurchaseOperationInfo purchaseOperationInformation)
        {
            dbContext.PurchaseOperationInformations.Add(purchaseOperationInformation);
            var isSuccess = dbContext.SaveChanges() > 0;

            IsStockUpdated(purchaseOperationInformation.PurchaseItems, purchaseOperationInformation.BranchId);

            return isSuccess;
        }

        public bool IsStockUpdated(List<PurchaseOperation> items, long branchId)
        {
            foreach (var item in items)
            {
                var upStockItem = dbContext.Stocks.FirstOrDefault(x => x.ItemId == item.ItemId && x.BranchId == branchId);

                if (upStockItem != null)
                {
                    var newAvgPrice =
                        ((upStockItem.AveragePrice * upStockItem.StockQuantity) + (item.UnitPrice * item.Quantity)) /
                        (upStockItem.StockQuantity + item.Quantity);

                    upStockItem.StockQuantity += item.Quantity;
                    upStockItem.AveragePrice = newAvgPrice;
                }
                else
                {
                    var stockNewItem = new Stock()
                    {
                        BranchId = branchId,
                        ItemId = item.ItemId,
                        StockQuantity = item.Quantity,
                        AveragePrice = item.UnitPrice,
                        Date = DateTime.Now
                    };

                    dbContext.Stocks.Add(stockNewItem);
                }

            }

            return dbContext.SaveChanges() > 0;
        }

        public Item GetItem(long id)
        {
            var item = dbContext.Items.Find(id);
            return item;
        }

        public string GetPurchaseNo()
        {
            long purchaseNo;

            if (dbContext.PurchaseOperationInformations.ToList().Count > 0)
            {
                purchaseNo = Convert.ToInt64(dbContext.PurchaseOperationInformations.Select(x => x.PurchaseNo).Max());
            }
            else
            {
                purchaseNo = 0;
            }

            return string.Format("{0:0000000}", (purchaseNo + 1));
        }

        public PurchaseOperationInfo GetPurchaseOpInfo(string purchaseNo)
        {
            PurchaseOperationInfo item = dbContext.PurchaseOperationInformations.Where(x => x.PurchaseNo == purchaseNo).Include(x => x.PurchaseItems).FirstOrDefault();

            return item;
        }

        public PurchaseOperationInfo GetPurchaseOpInfo(long id)
        {
            PurchaseOperationInfo item = dbContext.PurchaseOperationInformations.Where(x => x.Id == id).Include(x => x.PurchaseItems).FirstOrDefault();

            return item;
        }

        public IEnumerable<PurchaseOperationInfo> GetPurchaseOpInfoList()
        {
            var items = dbContext.PurchaseOperationInformations.Include(x => x.PurchaseItems);
            return items;
        }
        public IEnumerable<PurchaseOperationInfo> GetPurchaseOpInfoList(long branchId, DateTime fromDate, DateTime toDate)
        {
            var items = dbContext.PurchaseOperationInformations
                .Where(x => x.BranchId == branchId && x.PurchaseDate >= fromDate && x.PurchaseDate <= toDate)
                .Include(x => x.PurchaseItems);
            return items;
        }
    }
}
