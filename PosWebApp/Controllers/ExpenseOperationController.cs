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
    public class ExpenseOperationController : Controller
    {
        ExpenseOperationInfoVM exOiVm = new ExpenseOperationInfoVM();
        ExpOperationManager _expenseBll = new ExpOperationManager();

        // GET: ExpenseOperation
        public ActionResult Index()
        {
            exOiVm.ExpenseDate = DateTime.Now;
            exOiVm.ExpenseNo = _expenseBll.GetExpenseNo();
            exOiVm.SelectListItem = _expenseBll.GetExpenseItemSelectList();
            exOiVm.SelectListBranch = _expenseBll.GetBranchSelectList();
            exOiVm.SelectListEmployee = _expenseBll.GetEmployeeSelectList();
            return View(exOiVm);
        }

        [HttpPost]
        public ActionResult Index(ExpenseOperationInfoVM exPoVm)
        {
            exPoVm.Date = DateTime.Now;

            ExpenseOperationInfo expenseOperationInformation = Mapper.Map<ExpenseOperationInfo>(exPoVm);

            if (ModelState.IsValid)
            {
                if (_expenseBll.IsExpenseOperationSuccess(expenseOperationInformation))
                {
                    return RedirectToAction("Result", new { expenseNo = exPoVm.ExpenseNo });
                }
            }

            exOiVm.SelectListItem = _expenseBll.GetExpenseItemSelectList();
            exOiVm.SelectListBranch = _expenseBll.GetBranchSelectList();
            exOiVm.SelectListEmployee = _expenseBll.GetEmployeeSelectList();
            return View(exOiVm);
        }

        public ActionResult Result(string expenseNo)
        {
            return View(_expenseBll.GetExpenseOpInfo(expenseNo));
        }




        public ActionResult Report()
        {
            exOiVm.SelectListBranch = _expenseBll.GetBranchSelectList();
            exOiVm.ExpenseOpInfoList = _expenseBll.GetExpenseOpInfoList();
            return View(exOiVm);
        }

        [HttpPost]
        public ActionResult Report(long branchId, DateTime fromDate, DateTime toDate)
        {
            exOiVm.SelectListBranch = _expenseBll.GetBranchSelectList();
            exOiVm.ExpenseOpInfoList = _expenseBll.GetExpenseOpInfoList(branchId, fromDate, toDate);
            return View(exOiVm);
        }

        public ActionResult ExpenseOpReportDetails(long id)
        {
            var item = _expenseBll.GetExpenseOpInfo(id);
            return PartialView("_ExpenseOpReportDetails", item);
        }



        public ActionResult GetEmployeeList(long branchId)
        {
            var employeeList = _expenseBll.GetEmployeeList(branchId);
            return Json(employeeList, JsonRequestBehavior.AllowGet);
        }
    }
}