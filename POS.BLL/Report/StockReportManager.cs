using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using POS.DAL.Report;
using POS.Models.Operation;

namespace POS.BLL.Report
{
    public class StockReportManager
    {
        StockReportGetway _stockDal = new StockReportGetway();

        public IEnumerable<SelectListItem> GetBranchSelectList()
        {
            return _stockDal.GetBranchSelectList();
        }

        public IEnumerable<Stock> GetStockList()
        {
            return _stockDal.GetStockList();
        }

        public IEnumerable<Stock> GetStockList(long branchId)
        {
            return _stockDal.GetStockList(branchId);

        }

    }
}
