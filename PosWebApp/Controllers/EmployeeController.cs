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
    public class EmployeeController : Controller
    {
        EmployeeManager _employeeManager = new EmployeeManager();
        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.OrganizationId = new List<SelectListItem>();
            ViewBag.BranchId = new List<SelectListItem>();
            ViewBag.ReferenceId = new List<SelectListItem>();
            EmployeeVM employeeVm = new EmployeeVM
            {
                Employees = _employeeManager.GetAll()
            };
            return View(employeeVm);
        }

        [HttpPost]
        public ActionResult Add(EmployeeVM employeeVm)
        {
            try
            {
                if (employeeVm.ImageFile != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(employeeVm.ImageFile.FileName);
                    string extension = Path.GetExtension(employeeVm.ImageFile.FileName);
                    employeeVm.ImagePath = fileName + extension;
                    fileName = Path.Combine(Server.MapPath("~/images/"), employeeVm.ImagePath);
                    employeeVm.ImageFile.SaveAs(fileName);
                }
                Employee employee = Mapper.Map<Employee>(employeeVm);
                if (ModelState.IsValid)
                {
                    _employeeManager.Add(employee);
                    TempData["success"] = "Employee added succesfully";
                   return RedirectToAction("Add");
                }
            }
            catch (Exception e)
            {
                TempData["exception"] ="Failed to Add. "+ e.Message;
            }
            TempData["failed"] = "Failed to add new employee. ";
            ViewBag.OrganizationId = new List<SelectListItem>();
            ViewBag.BranchId = new List<SelectListItem>();
            ViewBag.ReferenceId = new List<SelectListItem>();
            EmployeeVM allEmp = new EmployeeVM()
            {
                Employees = _employeeManager.GetAll()
            };
            return View(allEmp);
        }

        public JsonResult GetAll()
        {
            return Json(_employeeManager.GetAll(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult All()
        {
            List<Employee> employees = new List<Employee>() ;
            employees = _employeeManager.GetAll();
            return View(employees);
        }

        public JsonResult GetCode(string nameValue)
        {
            if (nameValue.Length > 2)
            {
                return Json(_employeeManager.GetCode(nameValue), JsonRequestBehavior.AllowGet);
            }
            return null;
        }

        public ActionResult Profile(int employeeId)
        {
            var employee = _employeeManager.GetById(employeeId);

            EmployeeVM employeeVm = Mapper.Map<EmployeeVM>(employee);
            employeeVm.Employees = _employeeManager.GetAll();

            BranchManager branchManager = new BranchManager();
            employeeVm.BranchList = branchManager.GetBranchList();
            return View(employeeVm);
        }

        public JsonResult Delete(int employeeId)
        {
            return Json(_employeeManager.Delete(employeeId), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(int employeeId)
        {
            var employee = _employeeManager.GetById(employeeId);
            ViewBag.OrganizationId = new List<SelectListItem>();
            ViewBag.BranchId = new List<SelectListItem>();
            ViewBag.ReferenceId = new List<SelectListItem>();
            return View(employee);
        }

        public ActionResult Update(EmployeeVM employeeVm)
        {
            try
            {
                employeeVm.ImagePath = employeeVm.PrevImg;
                  if (employeeVm.ImageFile != null)
                  {
                      string fileName = Path.GetFileNameWithoutExtension(employeeVm.ImageFile.FileName);
                      string extension = Path.GetExtension(employeeVm.ImageFile.FileName);
                      employeeVm.ImagePath = fileName + extension;
                      fileName = Path.Combine(Server.MapPath("~/images/"), employeeVm.ImagePath);
                      employeeVm.ImageFile.SaveAs(fileName);
                  }
                  Employee employee = Mapper.Map<Employee>(employeeVm);
                  if (ModelState.IsValid)
                  {
                      _employeeManager.Update(employee);
                      //TempData["success"] = "Employee Updated succesfully";
                      return RedirectToAction("All");
                  }
                }
                catch (Exception e)
                {
                    TempData["exception"] = "Failed to Add. " + e.Message;
                }
                TempData["failed"] = "Failed to Update employee. ";
                ViewBag.OrganizationId = new List<SelectListItem>();
                ViewBag.BranchId = new List<SelectListItem>();
                ViewBag.ReferenceId = new List<SelectListItem>();
            
                return View(employeeVm);
            }
    }
}