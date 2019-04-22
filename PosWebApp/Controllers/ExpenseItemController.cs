using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using POS.BLL.Setup;
using POS.Models.Setup;
using POS.Models.ViewModel;

namespace PosWebApp.Controllers
{
    public class ExpenseItemController : Controller
    {
        ExpenseItemManager _expenseItemBll = new ExpenseItemManager();
        ExpenseItemVM ModelVm = new ExpenseItemVM();
        ExpenseItem expenseItemEn = new ExpenseItem();

        // GET: ExpenseItem
        public ActionResult Index()
        {
            ModelVm.Items = _expenseItemBll.GetExpenseItemList().OrderByDescending(x => x.Date).ToList();
            return View(ModelVm.Items);
        }

        public ActionResult Create()
        {
            ModelVm.SelectList = _expenseItemBll.GetExpenseItemSelectList();
            return View(ModelVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExpenseItemVM expenseItemVM)
        {
            expenseItemVM.Date = DateTime.Now;

            ExpenseItem expenseItem = Mapper.Map<ExpenseItem>(expenseItemVM);
            if (ModelState.IsValid)
            {
                if (_expenseItemBll.IsExpenseItemSaved(expenseItem))
                {
                    return RedirectToAction("Index");
                }
            }

            ModelVm.SelectList = _expenseItemBll.GetExpenseItemSelectList();
            return View(ModelVm);
        }


        public ActionResult Details(long id)
        {
            ExpenseItem expenseItem = _expenseItemBll.FindExpenseItem(id);
            ExpenseItemVM expenseItemVM = Mapper.Map<ExpenseItemVM>(expenseItem);
            return PartialView("_Details", expenseItemVM);
        }

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            expenseItemEn = _expenseItemBll.FindExpenseItem(id);
            ExpenseItemVM expenseItemVm = Mapper.Map<ExpenseItemVM>(expenseItemEn);

            if (expenseItemVm == null)
            {
                return HttpNotFound();
            }

            expenseItemVm.SelectList = _expenseItemBll.GetExpenseItemSelectList();
            return View(expenseItemVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExpenseItemVM expenseItemVm)
        {
            ExpenseItem expenseitem = Mapper.Map<ExpenseItem>(expenseItemVm);
            if (ModelState.IsValid)
            {
                if (_expenseItemBll.IsExpenseItemUpdated(expenseitem))
                {
                    return RedirectToAction("Index");
                }
            }

            return View(expenseItemVm);
        }

        public ActionResult Delete(long id)
        {
            var isDeleted = _expenseItemBll.IsExpenseItemDeleted(id);

            return Json(isDeleted, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetItemFullCode(long id)
        {
            var preCode = _expenseItemBll.GetExpenseCategoryCode(id);
            var code = _expenseItemBll.GetExpenseItemCode(id);
            return Json(new { preCode, code }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult IsUniqueName(string Name, string initialName)
        {
            var isUnique = _expenseItemBll.IsUniqueName(Name, initialName);
            return Json(isUnique, JsonRequestBehavior.AllowGet);
        }

        public ActionResult IsUniqueCode(string PreCode, string Code, string initialPreCode, string initialCode)
        {
            var isUnique = _expenseItemBll.IsUniqueCode(PreCode, Code, initialPreCode, initialCode);
            return Json(isUnique, JsonRequestBehavior.AllowGet);
        }
    }
}