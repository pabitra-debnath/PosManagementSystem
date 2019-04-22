using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using POS.Models.Operation;

namespace POS.DAL.Report
{
    public class StockReportGetway
    {
        PosDbContext dbContext = new PosDbContext();
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

        public IEnumerable<Stock> GetStockList()
        {
            var items = dbContext.Stocks.Where(x => x.StockQuantity > 0).Include(x => x.Item).ToList();
            return items;
        }

        public IEnumerable<Stock> GetStockList(long branchId)
        {
            var items = dbContext.Stocks.Where(x => x.BranchId == branchId && x.StockQuantity > 0).Include(x => x.Item).ToList();
            return items;
        }
    }
}
