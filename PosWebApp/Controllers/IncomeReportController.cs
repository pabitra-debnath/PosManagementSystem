using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.BLL.Report;
using POS.Models.ViewModel;

namespace PosWebApp.Controllers
{
    public class IncomeReportController : Controller
    {
        IncomeReportVM incomeReportVm = new IncomeReportVM();
        IncomeReportManager _incomeReportBll = new IncomeReportManager();
        // GET: IncomeReport
        public ActionResult Index()
        {
            incomeReportVm.SelectListBranch = _incomeReportBll.GetBranchSelectList();
            incomeReportVm.IncomePurchaseReportList = _incomeReportBll.GetIncomePurchaseReportList();
            incomeReportVm.IncomeSalesReportList = _incomeReportBll.GetIncomeSalesReportList();
            incomeReportVm.IncomeExpenseReportList = _incomeReportBll.GetIncomeExpenseReportList();
            return View(incomeReportVm);
        }

        [HttpPost]
        public ActionResult Index(long branchId, DateTime fromDate, DateTime toDate)
        {
            incomeReportVm.SelectListBranch = _incomeReportBll.GetBranchSelectList();
            incomeReportVm.IncomePurchaseReportList = _incomeReportBll.GetIncomePurchaseReportList(branchId, fromDate, toDate);
            incomeReportVm.IncomeSalesReportList = _incomeReportBll.GetIncomeSalesReportList(branchId, fromDate, toDate);
            incomeReportVm.IncomeExpenseReportList = _incomeReportBll.GetIncomeExpenseReportList(branchId, fromDate, toDate);
            return View(incomeReportVm);
        }

    }
}