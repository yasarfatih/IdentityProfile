using IdentityProfileApp.Context;
using IdentityProfileApp.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityProfileApp.Web.Areas.Admin.Controllers
{
    public class DutyController : BaseController
    {
        // GET: Admin/Duty
        public ActionResult Create()
        {
            IdentityProfileAppContext entities = new IdentityProfileAppContext();
            TempData["DutyProfiles"] = entities.Profile.Select(c => new SelectListItem
            {
                Text = c.Name + "/" + c.Title,
                Value = c.Id.ToString()
            });
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Duty model)
        {
            IdentityProfileAppContext entities = new IdentityProfileAppContext();
            model.Id = Guid.NewGuid();
            entities.Duty.Add(model);
            TempData["success"] = "Kaydetme işlemi başarı ile gerçekleşti";
            return View(model);
        }

        public ActionResult List()
        {
            IdentityProfileAppContext entities = new IdentityProfileAppContext();
            return View(entities.Duty.ToList());
        }

        public ActionResult Update(Guid id)
        {
            IdentityProfileAppContext entities = new IdentityProfileAppContext();
            var dutyForUpdate = entities.Duty.FirstOrDefault(d => d.Id == id);
            if (dutyForUpdate == null)
            {
                TempData["error"] = "Belirtilen kriterlere ait bir görev bulunamadı";
                return View();
            }

            return View(dutyForUpdate);
        }

        public ActionResult Update(Duty model)
        {
            IdentityProfileAppContext entities = new IdentityProfileAppContext();
            if (entities.Entry(model).State == EntityState.Detached)
                entities.Duty.Attach(model);
            entities.Entry(model).State = EntityState.Modified;
            entities.SaveChanges();
            TempData["success"] = "Görev başarıyla güncellendi.";
            return RedirectToAction("List");
        }

        public ActionResult Delete(Guid id)
        {
            IdentityProfileAppContext entities = new IdentityProfileAppContext();
            var questionInDb = entities.Question.SingleOrDefault(c => c.Id == id);
            if (questionInDb == null)
            {
                return Json(new
                {
                    Status = "error",
                    Message = "Belirtilen kriterlere uygun bir soru bulunamadı."
                });
            }
            entities.Question.Remove(questionInDb);
            entities.SaveChanges();
            return Json(new
            {
                Status = "ok",
                Message = "Soru ve cevapları başarıyla silindi"
            });
        }

        public JsonResult GetProfileList(string searchTerm)
        {
            IdentityProfileAppContext entites = new IdentityProfileAppContext();
            var profileList = entites.Profile.ToList();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                profileList = profileList.Where(x => x.Title.Contains(searchTerm) || x.Title.Contains(searchTerm)).ToList();
            }
            var data = profileList.Select(x => new
            {
                id = x.Id,
                text = string.Format("{0}/{1}", x.Name, x.Title)
            });
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}