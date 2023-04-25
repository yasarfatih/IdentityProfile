using IdentityProfileApp.Context;
using IdentityProfileApp.Domain.Entities.Enums;
using IdentityProfileApp.Domain.Entities.Models;
using IdentityProfileApp.Domain.Entities.ViewModels;
using IdentityProfileApp.Utils;
using IdentityProfileApp.Utils.Extensions;
using IdentityProfileApp.Web.StaticClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityProfileApp.Web.Areas.Admin.Controllers
{

    public class ProfileController : BaseController
    {
        // GET: Admin/Profile
        public ActionResult List()
        {
            IdentityProfileAppContext entities = new IdentityProfileAppContext();
            ViewBag.Title = "Kullanıcı Liste";
            return View(entities.Profile.ToList());
        }
        public ActionResult Create()
        {
            ProfileFeatureVM profileFeatureVM = new ProfileFeatureVM();
            return View(profileFeatureVM);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(ProfileFeatureVM model)
        {
            model.Profile.Id = Guid.NewGuid();
            var entities = new IdentityProfileAppContext();
            entities.Profile.Add(model.Profile);
            List<Feature> features = new List<Feature>();
            foreach (FeatureVM item in model.Features)
            {
                features.Add(new Feature() { Body = item.Body, Characteristic = item.Characteristic, ProfileId = model.Profile.Id, Title = item.Characteristic.GetDisplayName(), Order = (int)item.Order });
            }
            entities.Feature.AddRange(features);
            entities.SaveChanges();
            TempData["success"] = "Profil başarı ile kaydedildi";
            return RedirectToAction("List");
        }

        public ActionResult Update(Guid id)
        {
            var entities = new IdentityProfileAppContext();
            var profileFromDB = entities.Profile.Include(p => p.Features).SingleOrDefault(p => p.Id == id);
            return View(profileFromDB);
        }

        [ValidateInput(false), HttpPost]
        public ActionResult Update(Profile profile)
        {
            var entities = new IdentityProfileAppContext();
            var profileInDb = entities.Profile.Include(f => f.Features).SingleOrDefault(u => u.Id == profile.Id);
            if (profileInDb == null)
            {
                TempData["error"] = "Belirtilen kriterlere uygun bir profil bulunamadı";
                return RedirectToAction("List");
            }
            profileInDb.Part1 = profile.Part1;
            profileInDb.Part2 = profile.Part2;
            profileInDb.Part3 = profile.Part3;
            profileInDb.Part4 = profile.Part4;
            profileInDb.Title = profile.Title;
            profileInDb.Name = profile.Name;
            profileInDb.LastUpdate = DateTime.Now;
            foreach (var feature in profileInDb.Features)
            {
                feature.Body = profile.Features.SingleOrDefault(x => x.Id == feature.Id).Body;
            }
            entities.SaveChanges();
            TempData["success"] = "Profil Başarı ile güncellendi";
            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            IdentityProfileAppContext entities = new IdentityProfileAppContext();
            var profileInDb = entities.Profile.SingleOrDefault(c => c.Id == id);
            if (profileInDb == null)
            {
                return Json(new
                {
                    Status = "error",
                    Message = "Belirtilen kriterlere uygun bir profil bulunamadı."
                });
            }
            entities.Profile.Remove(profileInDb);
            entities.SaveChanges();
            return Json(new
            {
                Status = "ok",
                Message = "Profil başarıyla silindi"
            });
        }


    }
}