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
    public class OrganizationController : Controller
    {
        OrganizationManager _organizationManager = new OrganizationManager();
        // GET: Organization
        public ActionResult Add()
        {
            OrganizationVM organizationVm = new OrganizationVM();
            organizationVm.Organizations = _organizationManager.GetAll();
            return View(organizationVm);
        }

        [HttpPost]
        public ActionResult Add(OrganizationVM organizationVm)
        {
            if (organizationVm.ImageFile != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(organizationVm.ImageFile.FileName);
                string extension = Path.GetExtension(organizationVm.ImageFile.FileName);
                organizationVm.ImagePath = fileName + extension;
                fileName = Path.Combine(Server.MapPath("~/images/"), organizationVm.ImagePath);
                organizationVm.ImageFile.SaveAs(fileName);
            }

            Organization organization = Mapper.Map<Organization>(organizationVm);
            if (ModelState.IsValid)
            {
                try
                {
                    if (_organizationManager.Add(organization))
                    {
                        TempData["success"] = "Add successfully!";
                        return RedirectToAction("Add");
                    }
                }
                catch (Exception e)
                {
                    TempData["exception"] = "Failed to add!"+e.Message;
                }
               
            }
            OrganizationVM org = new OrganizationVM()
            {
                Organizations = _organizationManager.GetAll()
            };
            return View(org);
        }

        public JsonResult GetCode(string nameValue)
        {
            if (nameValue.Length > 2)
            {
                return Json(_organizationManager.GenerateCode(nameValue), JsonRequestBehavior.AllowGet);
            }
            return null;
        }

        public JsonResult GetAll()
        {
            return Json(_organizationManager.GetAll(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int CategoryId)
        {
            _organizationManager.Delete(CategoryId);
            return null;
        }

        public JsonResult Edit(int categoryId)
        {
            return Json(_organizationManager.GetById(categoryId), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update(OrganizationVM organizationVm)
        {
            string prevName = organizationVm.PrevName;
            string prevCode = organizationVm.PrevCode;
            string prevContactNo = organizationVm.PrevContactNo;

            if (organizationVm.ImageFile != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(organizationVm.ImageFile.FileName);
                string extension = Path.GetExtension(organizationVm.ImageFile.FileName);
                organizationVm.ImagePath = fileName + extension;
                fileName = Path.Combine(Server.MapPath("~/images/"), organizationVm.ImagePath);
                organizationVm.ImageFile.SaveAs(fileName);
            }

            Organization organization = Mapper.Map<Organization>(organizationVm);
            if (ModelState.IsValid)
            {
                try
                {
                    _organizationManager.Update(organization, prevName, prevCode, prevContactNo);
                    TempData["success"] = "Updated successfully";
                    return RedirectToAction("Add");
                }
                catch (Exception e)
                {
                    TempData["exception"] = e.Message;
                }
            }
            TempData["failed"] = "Failed to Update";
            return View("Add");
        }
    }
}