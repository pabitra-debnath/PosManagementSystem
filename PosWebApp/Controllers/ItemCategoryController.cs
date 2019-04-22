using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using POS.BLL.Setup;
using POS.Models.Setup;
using POS.Models.ViewModel;

namespace PosWebApp.Controllers
{
    public class ItemCategoryController : Controller
    {

        ItemCategoryManager _categoryManager = new ItemCategoryManager();
        // GET: ItemCategory
        public ActionResult Add()
        {
            ItemCategoryVM categoryVM = new ItemCategoryVM();

            categoryVM.CategoryList = _categoryManager.GetAll();
            //var DropDown = new List<SelectListItem>();
            //DropDown.AddRange(categoryVM.CategoryList.Select(c=>new SelectListItem {Value=c.Id.ToString(), Text = c.Name.ToString()}));
            //categoryVM.CategoryDropDown = DropDown;
            ViewBag.ParentId = new List<SelectListItem>();
            return View(categoryVM);
        }
        
        [HttpPost]
        public ActionResult Add(ItemCategoryVM categoryVM)
        {
            try
            {
                if (categoryVM.ImageFile != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(categoryVM.ImageFile.FileName);
                    string extension = Path.GetExtension(categoryVM.ImageFile.FileName);
                    categoryVM.ImagePath = fileName + extension;
                    fileName = Path.Combine(Server.MapPath("~/images/"), categoryVM.ImagePath);
                    categoryVM.ImageFile.SaveAs(fileName);
                }

                ItemCategory category = Mapper.Map<ItemCategory>(categoryVM);
                if (ModelState.IsValid)
                {
                    if (_categoryManager.Add(category))
                     {
                       TempData["success"] = "Added Sussessfully";
                        return RedirectToAction("Add");
                     }
                }
            }
            
            catch (Exception e)
            {
                TempData["exception"] ="Failed to Add. "+ e.Message;
            }
            return Add();
        }

        public JsonResult GetAll()
        {
            return Json(_categoryManager.GetAll(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCode(string nameValue)
        {
            if (nameValue.Length > 2)
            {
                return Json(_categoryManager.GenerateCode(nameValue), JsonRequestBehavior.AllowGet);
            }
            return null;
        }

        public JsonResult Delete(int categoryId)
        {
            _categoryManager.Delete(categoryId);
            return null;
        }

        public JsonResult Edit(int categoryId)
        {
            return Json(_categoryManager.GetById(categoryId), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update(ItemCategoryVM categoryVM)
        {
            try
            {
                if (categoryVM.ImageFile != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(categoryVM.ImageFile.FileName);
                    string extension = Path.GetExtension(categoryVM.ImageFile.FileName);
                    categoryVM.ImagePath = fileName + extension;
                    fileName = Path.Combine(Server.MapPath("~/images/"), categoryVM.ImagePath);
                    categoryVM.ImageFile.SaveAs(fileName);
                }
                ItemCategory category = Mapper.Map<ItemCategory>(categoryVM);
                ;
                bool isUpdate = _categoryManager.Update(category, categoryVM.PrevName, categoryVM.PrevCode);
                if (isUpdate)
                {
                    TempData["success"] = "Updated successfully";
                    return RedirectToAction("Add");
                }
            }
            catch (Exception e)
            {
                TempData["exception"] ="Failed to Update. "+ e.Message;
            }
            return View("Add");
        }
   }
}