using IdentityProfileApp.Context;
using IdentityProfileApp.Domain.Entities.Models;
using IdentityProfileApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityProfileApp.Web.Areas.Admin.Controllers
{
    public class PackageController : BaseController
    {
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(PaymentPackage package)
        {
            package.Id = Guid.NewGuid();
            IdentityProfileAppContext entities = new IdentityProfileAppContext();
            entities.PaymentPackage.Add(package);
            entities.SaveChanges();
            TempData["success"] = "Paket başarıyla eklendi.";
            return View();
        }

        public ActionResult List()
        {
            IdentityProfileAppContext entities = new IdentityProfileAppContext();
            ViewBag.Title = "Paket Liste";
            return View(entities.PaymentPackage.ToList());
        }

        public ActionResult Update(Guid id)
        {
            var entities = new IdentityProfileAppContext();
            var packageFromDB = entities.PaymentPackage.SingleOrDefault(m => m.Id == id);
            return View(packageFromDB);
        }


        [HttpPost]
        public ActionResult Update(PaymentPackage package)
        {
            var entities = new IdentityProfileAppContext();
            var userInDb = entities.PaymentPackage.SingleOrDefault(u => u.Id == package.Id);
            if (entities == null)
            {
                TempData["error"] = "Belirtilen kriterlere uygun bir kullanıcı bulunamadı";
                return RedirectToAction("List");
            }
            userInDb.Name = package.Name;
            userInDb.Price = package.Price;
            userInDb.PaymentType = package.PaymentType;
            entities.SaveChanges();
            return RedirectToAction(nameof(List));
        }
        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            IdentityProfileAppContext entities = new IdentityProfileAppContext();
            var packageInDb = entities.PaymentPackage.SingleOrDefault(c => c.Id == id);
            if (packageInDb == null)
            {
                return Json(new
                {
                    Status = "error",
                    Message = "Belirtilen kriterlere uygun bir paket bulunamadı."
                });
            }
            entities.PaymentPackage.Remove(packageInDb);
            entities.SaveChanges();
            return Json(new
            {
                Status = "ok",
                Message = "Kullanıcı başarıyla silindi"
            });
        }
    }
}