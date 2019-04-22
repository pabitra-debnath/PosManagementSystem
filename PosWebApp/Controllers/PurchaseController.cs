using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POS.BLL.Operation;
using POS.BLL.Setup;
using POS.Models.Operation;

namespace PosWebApp.Controllers
{
    public class PurchaseController : Controller
    {
        //ItemManager _itemManager = new ItemManager();
        //PurchaseManager _purchaseManager = new PurchaseManager();

        //public JsonResult GetAllItem()
        //{
        //    var items = _itemManager.GetItemList();
        //    return Json(items, JsonRequestBehavior.AllowGet);
        //}

        //public JsonResult GetItemById(int itemId)
        //{
        //    if (itemId > 0)
        //    {
        //        return Json(_itemManager.FindItem(itemId), JsonRequestBehavior.AllowGet);
        //    }
        //    return null;
        //}

        //public ActionResult NewPurchase()
        //{
        //    ViewBag.ItemId = new List<SelectListItem>();
        //    ViewBag.OrganizationId = new List<SelectListItem>();
        //    ViewBag.BranchId = new List<SelectListItem>();
        //    ViewBag.EmployeeId = new List<SelectListItem>();
        //    ViewBag.PartyId = new List<SelectListItem>();
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult NewPurchase(Purchase purchase)
        //{
        //    if (ModelState.IsValid && purchase.PurchaseDetailses != null && purchase.PurchaseDetailses.Count > 0)
        //    {
        //        bool isAdded = _purchaseManager.Add(purchase);
        //        if (isAdded)
        //        {
        //            return View(purchase);
        //        }
        //    }
        //    return View();
        //}
       
    }
}