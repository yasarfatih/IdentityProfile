using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IdentityProfileApp.Context;
using IdentityProfileApp.Domain.Entities.Models;
using IdentityProfileApp.Domain.Entities.ViewModels;
using IdentityProfileApp.Utils;


namespace IdentityProfileApp.Web.Areas.Admin.Controllers
{

    public class QuestionController : BaseController
    {
        // GET: Admin/Question
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Question model)
        {
            IdentityProfileAppContext entities = new IdentityProfileAppContext();
            model.Id = Guid.NewGuid();
            entities.Question.Add(model);
            entities.SaveChanges();
            TempData["success"] = "Soru başarıyla eklendi. Yeni soru girebilirsiniz.";
            return RedirectToAction("Create", "Question");
        }

        public ActionResult List()
        {
            IdentityProfileAppContext entities = new IdentityProfileAppContext();
            var questions = entities.Question.ToList();
            return View(questions);
        }

        [HttpPost]
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

        public ActionResult Update(Guid id)
        {
            IdentityProfileAppContext entities = new IdentityProfileAppContext();
            var question = entities.Question.SingleOrDefault(q => q.Id == id);
            if (question == null)
            {
                TempData["error"] = "Belirtilen kriterlere ait bir soru bulunamadı";
                return View();
            }
            return View(question);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(Question model)
        {
            var entities = new IdentityProfileAppContext();
            var questionInDb = entities.Question.SingleOrDefault(q => q.Id == model.Id);
            if (questionInDb == null)
            {
                TempData["error"] = "Belirtilen kriterlere uygun bir kullanıcı bulunamadı";
                return RedirectToAction("List");
            }
            questionInDb.Body = model.Body;
            //to do
            questionInDb.AgreePart = model.AgreePart;
            questionInDb.DisagreePart = model.DisagreePart;
            entities.SaveChanges();
            return RedirectToAction("List");
        }
    }
}