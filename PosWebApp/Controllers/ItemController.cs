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
    public class ItemController : Controller
    {
        ItemVM itemVm = new ItemVM();
        ItemManager itemBll = new ItemManager();
        ImageManager imageData = new ImageManager();
        Item itemEn = new Item();

        // GET: Item
        public ActionResult Index()
        {
            itemVm.Items = itemBll.GetItemList().OrderByDescending(x => x.Date).ToList();
            return View(itemVm.Items);
        }

        public ActionResult Create()
        {
            itemVm.SelectList = itemBll.GetItemSelectList();
            return View(itemVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ItemVM itemVm, HttpPostedFileBase ItemCategoryFile)
        {
            itemVm.Date = DateTime.Now;
            itemVm.Image = imageData.ImageConvertToByte(ItemCategoryFile);

            Item item = Mapper.Map<Item>(itemVm);

            if (ModelState.IsValid)
            {
                if (itemBll.IsItemSaved(item))
                {
                    return RedirectToAction("Index");
                }
            }

            itemVm.SelectList = itemBll.GetItemSelectList();
            return View(itemVm);
        }



        public ActionResult Details(long id)
        {
            Item item = itemBll.FindItem(id);

            ItemVM itemVm = Mapper.Map<ItemVM>(item);
            return PartialView("_Details", itemVm);
        }

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            itemEn = itemBll.FindItem(id);
            ItemVM itemVm = Mapper.Map<ItemVM>(itemEn);

            if (itemVm == null)
            {
                return HttpNotFound();
            }

            itemVm.SelectList = itemBll.GetItemSelectList();
            return View(itemVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ItemVM itemVm)
        {
            Item item = Mapper.Map<Item>(itemVm);
            if (ModelState.IsValid)
            {
                if (itemBll.IsItemUpdated(item))
                {
                    return RedirectToAction("Index");
                }
            }

            return View(itemVm);
        }

        public ActionResult Delete(long id)
        {
            var isDeleted = itemBll.IsItemDeleted(id);

            return Json(isDeleted, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetItemFullCode(long id)
        {
            var preCode = itemBll.GetItemCategoryCode(id);
            var code = itemBll.GetItemCode(id);
            return Json(new { preCode, code }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult IsUniqueName(string Name, string initialName)
        {
            var isUnique = itemBll.IsUniqueName(Name, initialName);
            return Json(isUnique, JsonRequestBehavior.AllowGet);
        }

        public ActionResult IsUniqueCode(string PreCode, string Code, string initialPreCode, string initialCode)
        {
            var isUnique = itemBll.IsUniqueCode(PreCode, Code, initialPreCode, initialCode);
            return Json(isUnique, JsonRequestBehavior.AllowGet);
        }

    }
}