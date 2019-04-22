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
    public class BranchController : Controller
    {
        Branch branchEn = new Branch();
        BranchVM branchVm = new BranchVM();
        BranchManager _branchBll = new BranchManager();

        // GET: Branch
        public ActionResult Index()
        {
            branchVm.Branches = _branchBll.GetBranchList().OrderByDescending(x => x.Date).ToList();
            return View(branchVm.Branches);
        }

        public ActionResult Create()
        {
            branchVm.SelectList = _branchBll.GetBranchSelectList();
            branchVm.Code = _branchBll.GetBranchCode();
            return View(branchVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BranchVM branchVM)
        {
            branchVM.Date = DateTime.Now;
            Branch branch = Mapper.Map<Branch>(branchVM);
            if (ModelState.IsValid)
            {
                if (_branchBll.IsBranchSaved(branch))
                {
                    return RedirectToAction("Index");
                }
            }

            branchVm.SelectList = _branchBll.GetBranchSelectList();
            branchVm.Code = _branchBll.GetBranchCode();
            return View(branchVm);
        }



        public ActionResult Details(long id)
        {
            Branch branch = _branchBll.FindBranch(id);
            BranchVM branchVm = Mapper.Map<BranchVM>(branch);
            return PartialView("_Details", branchVm);
        }

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            branchEn = _branchBll.FindBranch(id);
            BranchVM bnchVm = Mapper.Map<BranchVM>(branchEn);

            if (bnchVm == null)
            {
                return HttpNotFound();
            }

            bnchVm.SelectList = _branchBll.GetBranchSelectList();
            return View(bnchVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BranchVM bnchVm)
        {
            Branch branch = Mapper.Map<Branch>(bnchVm);
            if (ModelState.IsValid)
            {
                if (_branchBll.IsBranchUpdated(branch))
                {
                    return RedirectToAction("Index");
                }
            }

            return View(bnchVm);
        }

        public ActionResult Delete(long id)
        {
            var isDeleted = _branchBll.IsBranchDeleted(id);

            return Json(isDeleted, JsonRequestBehavior.AllowGet);
        }

        public ActionResult IsUniqueCode(string Code, string initialCode)
        {
            var isUnique = _branchBll.IsUniqueCode(Code, initialCode);
            return Json(isUnique, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAll()
        {
            return Json(_branchBll.GetBranchList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetByOrganization(int organizationId)
        {
            return Json(_branchBll.GetByOrgId(organizationId), JsonRequestBehavior.AllowGet);
        }
    }
}