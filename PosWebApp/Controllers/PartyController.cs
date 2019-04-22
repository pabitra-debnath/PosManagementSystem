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
    public class PartyController : Controller
    {
        Party partyEn = new Party();
        PartyVM partyVm = new PartyVM();
        PartyManager _partyBll = new PartyManager();
        ImageManager imageData = new ImageManager();

        // GET: Party
        public ActionResult Index()
        {
            partyVm.Parties = _partyBll.GetPartyList().OrderByDescending(x => x.Date).ToList();
            return View(partyVm.Parties);
        }

        public ActionResult Create()
        {
            partyVm.PreCode = _partyBll.GetPartyPreCode();
            partyVm.Code = _partyBll.GetPartyCode();
            return View(partyVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PartyVM partyVm, HttpPostedFileBase ItemCategoryFile)
        {
            partyVm.Date = DateTime.Now;
            partyVm.Image = imageData.ImageConvertToByte(ItemCategoryFile);

            Party party = Mapper.Map<Party>(partyVm);
            if (ModelState.IsValid)
            {
                if (_partyBll.IsPartySaved(party))
                {
                    return RedirectToAction("Index");
                }
            }

            partyVm.PreCode = _partyBll.GetPartyPreCode();
            partyVm.Code = _partyBll.GetPartyCode();
            return View(partyVm);
        }


        public ActionResult Details(long id)
        {
            Party party = _partyBll.FindParty(id);

            PartyVM partyVm = Mapper.Map<PartyVM>(party);
            return PartialView("_Details", partyVm);
        }

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            partyEn = _partyBll.FindParty(id);
            PartyVM partyVm = Mapper.Map<PartyVM>(partyEn);

            if (partyVm == null)
            {
                return HttpNotFound();
            }

            return View(partyVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PartyVM partyVm)
        {
            Party party = Mapper.Map<Party>(partyVm);
            if (ModelState.IsValid)
            {
                if (_partyBll.IsPartyUpdated(party))
                {
                    return RedirectToAction("Index");
                }
            }

            return View(partyVm);
        }

        public ActionResult Delete(long id)
        {
            var isDeleted = _partyBll.IsPartyDeleted(id);

            return Json(isDeleted, JsonRequestBehavior.AllowGet);
        }

        public ActionResult IsUniqueName(string Name, string initialName)
        {
            var isUnique = _partyBll.IsUniqueName(Name, initialName);
            return Json(isUnique, JsonRequestBehavior.AllowGet);
        }

        public ActionResult IsUniqueCode(string PreCode, string Code, string initialPreCode, string initialCode)
        {
            var isUnique = _partyBll.IsUniqueCode(PreCode, Code, initialPreCode, initialCode);
            return Json(isUnique, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAll()
        {
            return Json(_partyBll.GetPartyList(), JsonRequestBehavior.AllowGet);
        }
    }
}