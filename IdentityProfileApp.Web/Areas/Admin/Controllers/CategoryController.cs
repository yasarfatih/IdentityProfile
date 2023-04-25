using IdentityProfileApp.Context;
using IdentityProfileApp.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace IdentityProfileApp.Web.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Admin/Category
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            var entities = new IdentityProfileAppContext();
            category.Id = Guid.NewGuid();
            entities.Category.Add(category);
            entities.SaveChanges();
            TempData["success"] = "Kategori başarıyla eklendi";
            return RedirectToAction("List");
        }
        public ActionResult Update(Guid id)
        {
            var entities = new IdentityProfileAppContext();
            var categoryInDb = entities.Category.Where(c => c.Id == id).SingleOrDefault();
            return View(categoryInDb);
        }
        [HttpPost]
        public ActionResult Update(Category model)
        {
            var entities = new IdentityProfileAppContext();
            var categoryInDb = entities.Category.Where(c => c.Id == model.Id).SingleOrDefault();
            if (categoryInDb == null)
            {
                TempData["error"] = "bu kriterlere uygu bir kategori bukunamadı lütfen verilerin doğruluğunu teyit ediniz";
                return View(model);
            }
            categoryInDb.CategoryName = model.CategoryName;
            categoryInDb.LastUpdate = DateTime.Now;
            entities.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            var entities = new IdentityProfileAppContext();
            var categories = entities.Category.ToList();
            return View(categories);
        }

        public ActionResult Delete(Guid id)
        {
            var entities = new IdentityProfileAppContext();
            var categoryInDb = entities.Category.Where(c => c.Id == id).SingleOrDefault();
            if (categoryInDb == null)
            {
                return Json(new
                {
                    Status = "error",
                    Message = "bu kriterlere uygun bir kategori bulunamadı lütfen verilerin doğruluğunu teyit ediniz"
                }); ;
            }
            entities.Category.Remove(categoryInDb);
            entities.SaveChanges();
            return Json(new
            {
                Status = "ok",
                Message = "Kategori başarıyla silindi"
            });
        }

    }
}