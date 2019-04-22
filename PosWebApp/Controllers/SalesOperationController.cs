using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using POS.BLL.Operation;
using POS.Models.Operation;
using POS.Models.ViewModel;

namespace PosWebApp.Controllers
{
    public class SalesOperationController : Controller
    {
        SalesOperationInfoVM salesVm = new SalesOperationInfoVM();
        SalesManager salesBll = new SalesManager();

        // GET: SalesOperation
        public ActionResult Index()
        {
            salesVm.SalesDate = DateTime.Now;
            salesVm.SalesNo = salesBll.GetSalesNo();
            salesVm.SelectListItem = salesBll.GetItemSelectList();
            salesVm.SelectListBranch = salesBll.GetBranchSelectList();
            salesVm.SelectListEmployee = salesBll.GetEmployeeSelectList();
            return View(salesVm);
        }

        [HttpPost]
        public ActionResult Index(SalesOperationInfoVM soiVm)
        {
            soiVm.Date = DateTime.Now;

            SalesOperationInfo soi = Mapper.Map<SalesOperationInfo>(soiVm);
            if (ModelState.IsValid)
            {
                if (salesBll.IsSalesOperationSuccess(soi))
                {
                    return RedirectToAction("Result", new { salesNo = soi.SalesNo });
                }
            }

            soiVm.SelectListItem = salesBll.GetItemSelectList();
            soiVm.SelectListBranch = salesBll.GetBranchSelectList();
            soiVm.SelectListEmployee = salesBll.GetEmployeeSelectList();
            return View(soiVm);
        }

        public ActionResult GetItemStatus(long branchId, long itemId)
        {
            var obj = salesBll.GetItemStatus(branchId, itemId);
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Result(string salesNo)
        {
            return View(salesBll.GetSalesOpInfo(salesNo));
        }



        public ActionResult Report()
        {
            salesVm.SelectListBranch = salesBll.GetBranchSelectList();
            salesVm.SalesOpInfoList = salesBll.GetSalesOpInfoList();
            return View(salesVm);
        }

        [HttpPost]
        public ActionResult Report(long branchId, DateTime fromDate, DateTime toDate)
        {
            salesVm.SelectListBranch = salesBll.GetBranchSelectList();
            salesVm.SalesOpInfoList = salesBll.GetSalesOpInfoList(branchId, fromDate, toDate);
            return View(salesVm);
        }

        public ActionResult SalesOpReportDetails(long id)
        {
            var item = salesBll.GetSalesOpInfo(id);
            return PartialView("_SalesOpReportDetails", item);
        }



        public ActionResult GetEmployeeList(long branchId)
        {
            var employeeList = salesBll.GetEmployeeList(branchId);
            return Json(employeeList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetStockItemList(long branchId)
        {
            var employeeList = salesBll.GetStockItemList(branchId);
            return Json(employeeList, JsonRequestBehavior.AllowGet);
        }
    }
}