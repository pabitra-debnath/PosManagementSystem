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
    public class SalesGetway
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

        public List<Employee> GetEmployeeList(long branchId)
        {
            var employeeList = dbContext.Employees.Where(x => x.BranchId == branchId).ToList();
            return employeeList;
        }
        public List<Item> GetStockItemList(long branchId)
        {
            var stockList = dbContext.Stocks.Where(x => x.BranchId == branchId && x.StockQuantity > 0).Include(x => x.Item).Select(x => x.Item).ToList();
            return stockList;
        }

        public string GetSalesNo()
        {
            long salesNo;

            if (dbContext.SalesOperationInformations.ToList().Count > 0)
            {
                salesNo = Convert.ToInt64(dbContext.SalesOperationInformations.Select(x => x.SalesNo).Max());
            }
            else
            {
                salesNo = 0;
            }

            return string.Format("{0:0000000}", (salesNo + 1));
        }

        public bool IsSalesOperationSuccess(SalesOperationInfo opi)
        {

            dbContext.SalesOperationInformations.Add(opi);
            var isSuccess = dbContext.SaveChanges() > 0;

            IsStockUpdated(opi.SalesItems, opi.BranchId);

            return isSuccess;
        }

        public bool IsStockUpdated(List<SalesOperation> items, long branchId)
        {
            foreach (var item in items)
            {
                var upStockItem = dbContext.Stocks.Where(x => x.ItemId == item.ItemId && x.BranchId == branchId).FirstOrDefault();

                if (upStockItem != null)
                {
                    upStockItem.StockQuantity -= item.Quantity;
                }
            }

            return dbContext.SaveChanges() > 0;
        }

        public object GetItemStatus(long branchId, long itemId)
        {
            var stockQty = dbContext.Stocks.Where(x => x.BranchId == branchId && x.ItemId == itemId).Select(x => x.StockQuantity).FirstOrDefault();
            var salesPrice = dbContext.Items.Where(x => x.Id == itemId).Select(x => x.SalePrice).FirstOrDefault();

            long itemStockQty = 0;
            double itemSalesPrice = 0;

            if (stockQty != null)
                itemStockQty = stockQty;
            if (salesPrice != null)
                itemSalesPrice = salesPrice;

            var obj = new { ItemStockQty = itemStockQty, ItemSalesPrice = itemSalesPrice };

            return obj;
        }

        public SalesOperationInfo GetSalesOpInfo(string salesNo)
        {
            SalesOperationInfo item = dbContext.SalesOperationInformations.Where(x => x.SalesNo == salesNo).Include(x => x.SalesItems).FirstOrDefault();

            return item;
        }

        public SalesOperationInfo GetSalesOpInfo(long id)
        {
            SalesOperationInfo item = dbContext.SalesOperationInformations.Where(x => x.Id == id).Include(x => x.SalesItems).FirstOrDefault();

            return item;
        }

        public IEnumerable<SalesOperationInfo> GetSalesOpInfoList()
        {
            var items = dbContext.SalesOperationInformations.Include(x => x.SalesItems);
            return items;
        }
        public IEnumerable<SalesOperationInfo> GetSalesOpInfoList(long branchId, DateTime fromDate, DateTime toDate)
        {
            var items = dbContext.SalesOperationInformations
                .Where(x => x.BranchId == branchId && x.SalesDate >= fromDate && x.SalesDate <= toDate)
                .Include(x => x.SalesItems);
            return items;
        }
    }
}
