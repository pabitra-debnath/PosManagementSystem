using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.BLL.Report;
using POS.Models.ViewModel;

namespace PosWebApp.Controllers
{
    public class StockReportController : Controller
    {
        StockReportVM stockReportVm = new StockReportVM();
        StockReportManager _stockReportBll = new StockReportManager();

        // GET: StockReport
        public ActionResult Index()
        {
            stockReportVm.SelectListBranch = _stockReportBll.GetBranchSelectList();
            stockReportVm.StockList = _stockReportBll.GetStockList();
            return View(stockReportVm);
        }

        [HttpPost]
        public ActionResult Index(long branchId)
        {
            stockReportVm.SelectListBranch = _stockReportBll.GetBranchSelectList();
            stockReportVm.StockList = _stockReportBll.GetStockList(branchId);
            return View(stockReportVm);
        }


    }
}