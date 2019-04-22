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
    public class PurchaseOperationController : Controller
    {
        PurchaseOperationInfoVM purchaseOperationInformationVm = new PurchaseOperationInfoVM();

        PurchaseManager _purchaseBLL = new PurchaseManager();

        // GET: PurchaseOperation
        public ActionResult Index()
        {
            purchaseOperationInformationVm.PurchaseDate = DateTime.Now;
            purchaseOperationInformationVm.PurchaseNo = _purchaseBLL.GetPurchaseNo();
            purchaseOperationInformationVm.SelectListItem = _purchaseBLL.GetItemSelectList();
            purchaseOperationInformationVm.SelectListBranch = _purchaseBLL.GetBranchSelectList();
            purchaseOperationInformationVm.SelectListEmployee = _purchaseBLL.GetEmployeeSelectList();
            purchaseOperationInformationVm.SelectListSupplier = _purchaseBLL.GetSupplierSelectList();
            return View(purchaseOperationInformationVm);
        }

        [HttpPost]
        public ActionResult Index(PurchaseOperationInfoVM purOraVm)
        {
            purOraVm.Date = DateTime.Now;

            PurchaseOperationInfo pio = Mapper.Map<PurchaseOperationInfo>(purOraVm);



            if (ModelState.IsValid)
            {
                if (_purchaseBLL.IsPurchaseOperationSuccess(pio))
                {
                    return RedirectToAction("Result", new { purchaseNo = purOraVm.PurchaseNo });
                }
            }

            purOraVm.SelectListItem = _purchaseBLL.GetItemSelectList();
            purOraVm.SelectListBranch = _purchaseBLL.GetBranchSelectList();
            purOraVm.SelectListEmployee = _purchaseBLL.GetEmployeeSelectList();
            purOraVm.SelectListSupplier = _purchaseBLL.GetSupplierSelectList();
            return View(purOraVm);
        }

        [HttpPost]
        public ActionResult GetItem(long id)
        {
            var getItem = _purchaseBLL.GetItem(id);
            return Json(getItem, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Result(string purchaseNo)
        {
            return View(_purchaseBLL.GetPurchaseOpInfo(purchaseNo));
        }



        public ActionResult Report()
        {
            purchaseOperationInformationVm.SelectListBranch = _purchaseBLL.GetBranchSelectList();
            purchaseOperationInformationVm.SelectListSupplier = _purchaseBLL.GetSupplierSelectList();
            purchaseOperationInformationVm.SelectListEmployee = _purchaseBLL.GetEmployeeSelectList();
            purchaseOperationInformationVm.PurchaseOpInfoList = _purchaseBLL.GetPurchaseOpInfoList();
            return View(purchaseOperationInformationVm);
        }

        [HttpPost]
        public ActionResult Report(long branchId, DateTime fromDate, DateTime toDate)
        {
            purchaseOperationInformationVm.SelectListBranch = _purchaseBLL.GetBranchSelectList();
            purchaseOperationInformationVm.SelectListSupplier = _purchaseBLL.GetSupplierSelectList();
            purchaseOperationInformationVm.SelectListEmployee = _purchaseBLL.GetEmployeeSelectList();
            purchaseOperationInformationVm.PurchaseOpInfoList = _purchaseBLL.GetPurchaseOpInfoList(branchId, fromDate, toDate);
            return View(purchaseOperationInformationVm);
        }

        public ActionResult PurchaseOpReportDetails(long id)
        {
            var item = _purchaseBLL.GetPurchaseOpInfo(id);
            return PartialView("_PurchaseOpReportDetails", item);
        }



        public ActionResult GetEmployeeList(long branchId)
        {
            var employeeList = _purchaseBLL.GetEmployeeList(branchId);
            return Json(employeeList, JsonRequestBehavior.AllowGet);
        }
    }
}