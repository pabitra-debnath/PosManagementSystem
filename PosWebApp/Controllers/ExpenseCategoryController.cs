using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using POS.BLL.Setup;
using POS.Models.Setup;
using POS.Models.ViewModel;

namespace PosWebApp.Controllers
{
    public class ExpenseCategoryController : Controller
    {

        ExpenseCategoryManager _expenseCategoryManager = new ExpenseCategoryManager();
        // GET: ExpenseCategory
        public ActionResult Add()
        {
            ExpenseCategoryVM expenseCat = new ExpenseCategoryVM();
            expenseCat.All = _expenseCategoryManager.GetAll();
            ViewBag.ParentId = new List<SelectListItem>();
            return View(expenseCat);
        }

        [HttpPost]
        public ActionResult Add(ExpenseCategoryVM categoryVm)
        {
            try
            {
                ExpenseCategory category = Mapper.Map<ExpenseCategory>(categoryVm);
                if (ModelState.IsValid)
                {
                        if (_expenseCategoryManager.Add(category))
                        {
                            TempData["success"] = "Added successfully";
                            return RedirectToAction("Add");
                        }
                }
            }
            catch (Exception e)
            {
                TempData["exception"] = "failed to add. " + e.Message;
            }
            return Add();
        }

        public JsonResult GetAll()
        {
            return Json(_expenseCategoryManager.GetAll(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCode(string nameValue)
        {
            if (nameValue.Length > 2)
            {
                return Json(_expenseCategoryManager.GenerateCode(nameValue), JsonRequestBehavior.AllowGet);
            }
            return null;
        }

        public JsonResult Delete(int categoryId)
        {
            _expenseCategoryManager.Delete(categoryId);
            return null;
        }

        public JsonResult Edit(int categoryId)
        {
            return Json(_expenseCategoryManager.GetById(categoryId), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update(ExpenseCategoryVM expenseCategoryVm)
        {
            try
            {
                string prevName = expenseCategoryVm.PrevName;
                string prevCode = expenseCategoryVm.PrevCode;
                ExpenseCategory expenseCategory = Mapper.Map<ExpenseCategory>(expenseCategoryVm);
                if (ModelState.IsValid)
                {
                    if (_expenseCategoryManager.Update(expenseCategory, prevName, prevCode))
                    {
                        TempData["success"] = "Updated successfully";
                        return RedirectToAction("Add");
                    }
                }
            }
            catch (Exception e)
            {
                TempData["exception"] = "Failed to update"+e.Message;
            }
            ViewBag.ParentId = new List<SelectListItem>();
            return View("Add");
        }
    }
}