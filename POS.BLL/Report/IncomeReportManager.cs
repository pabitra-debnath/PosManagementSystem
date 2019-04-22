using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using POS.DAL.Report;
using POS.Models.ViewModel;

namespace POS.BLL.Report
{
    public class IncomeReportManager
    {
        IncomeReportGetway _incomeReportDal = new IncomeReportGetway();


        public IEnumerable<SelectListItem> GetBranchSelectList()
        {
            return _incomeReportDal.GetBranchSelectList();
        }

        public IEnumerable<IncomePurchaseReport> GetIncomePurchaseReportList()
        {
            return _incomeReportDal.GetIncomePurchaseReportList();
        }

        public IEnumerable<IncomeSalesReport> GetIncomeSalesReportList()
        {
            return _incomeReportDal.GetIncomeSalesReportList();
        }

        public IEnumerable<IncomeExpenseReport> GetIncomeExpenseReportList()
        {
            return _incomeReportDal.GetIncomeExpenseReportList();
        }

        public IEnumerable<IncomePurchaseReport> GetIncomePurchaseReportList(long branchId, DateTime fromDate,
            DateTime toDate)
        {
            return _incomeReportDal.GetIncomePurchaseReportList(branchId, fromDate, toDate);
        }

        public IEnumerable<IncomeSalesReport> GetIncomeSalesReportList(long branchId, DateTime fromDate,
            DateTime toDate)
        {
            return _incomeReportDal.GetIncomeSalesReportList(branchId, fromDate, toDate);
        }

        public IEnumerable<IncomeExpenseReport> GetIncomeExpenseReportList(long branchId, DateTime fromDate,
            DateTime toDate)
        {
            return _incomeReportDal.GetIncomeExpenseReportList(branchId, fromDate, toDate);
        }

        public string GetBranchAddress(long branchId)
        {
            return _incomeReportDal.GetBranchAddress(branchId);
        }
    }
}
