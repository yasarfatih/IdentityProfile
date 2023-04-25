using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IdentityProfileApp.Utils;
using IdentityProfileApp.Context;
using IdentityProfileApp.Domain.Entities.Models;
using System.Data.Entity;
using IdentityProfileApp.Utils.Helpers;
using IdentityProfileApp.Domain.Entities.ViewModels;

namespace IdentityProfileApp.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Create()
        {
            
            var entities = new IdentityProfileAppContext();
            UserVM model = new UserVM();
            model.UserRoles = entities.Roles.Select(r => new RoleCheckBoxModel
            {
                RoleId = r.Id,
                RoleName = r.Name,
                IsChecked = false
            }).ToList();
            return View(model);
        }


        [HttpPost]
        public ActionResult Create(UserVM model)
        {
            model.User.Id = Guid.NewGuid();
            model.User.Password = model.User.Password.Encrypt("Identity");
            MailSender mailSender = new MailSender();

            string ret = RenderPartialViewToString("~/Areas/Admin/Views/Shared/_Welcome.cshtml", null);
            mailSender.EmailSender(model.User.EmailAdress, "Hoşgeldiniz", ret);
            IdentityProfileAppContext entities = new IdentityProfileAppContext();
            foreach (var role in model.UserRoles.Where(r => r.IsChecked))
            {
                model.User.UserRoles.Add(new UserInRole { UserId = model.User.Id, RoleId = role.RoleId });
            }
            entities.User.Add(model.User);
            entities.SaveChanges();
            TempData["success"] = "Kullanıcı başarıyla eklendi.";
            return View(model);
        }


        public ActionResult List()
        {
            IdentityProfileAppContext entities = new IdentityProfileAppContext();
            return View(entities.User.ToList());
        }

        public ActionResult Update(Guid id)
        {
            var entities = new IdentityProfileAppContext();
            var userFromDB = entities.User.SingleOrDefault(m => m.Id == id);
            if (userFromDB == null)
            {
                TempData["error"] = "Belirtilen kriterlere uygun bir kullanıcı bulunamadı.";
                return RedirectToAction("List");
            }
            UserVM model = new UserVM();
            model.User = userFromDB;
            //bu kullanıcının içerisinde bulunduğu rollerin id değerlerini elde edelim.
            var rolesForUser = entities.UserInRoles.Where(ur => ur.UserId == userFromDB.Id).Select(ur => ur.RoleId);
            model.UserRoles = entities.Roles.Select(r => new RoleCheckBoxModel
            {
                RoleId = r.Id,
                RoleName = r.Name,
                IsChecked = rolesForUser.Contains(r.Id) ? true : false
            }).ToList();
            return View(model);
        }


        [HttpPost]
        public ActionResult Update(UserVM model)
        {
            var entities = new IdentityProfileAppContext();
            var userInDb = entities.User.SingleOrDefault(u => u.Id == model.User.Id);
            if (entities==null)
            {
                TempData["error"] = "Belirtilen kriterlere uygun bir kullanıcı bulunamadı";
                return RedirectToAction("List");
            }
            userInDb.Name = model.User.Name;
            userInDb.Surname = model.User.Surname;
            //userInDb.UserName = user.UserName;
            userInDb.MobileTelNo = model.User.MobileTelNo;
            userInDb.EmailAdress = model.User.EmailAdress;
            userInDb.Gender = model.User.Gender;
            userInDb.LastUpdate = DateTime.Now;

            //kullanıcının şu an içerisinde bulunduğu tüm rollerden kullanıcıyı çıkaralım.
            entities.UserInRoles.RemoveRange(entities.UserInRoles.Where(ur => ur.UserId == model.User.Id));
            //modelden gelen rollere kullanıcıyı ekleyelim.
            foreach (var role in model.UserRoles.Where(r => r.IsChecked))
            {
                model.User.UserRoles.Add(new UserInRole { UserId = model.User.Id, RoleId = role.RoleId });
            }
            entities.UserInRoles.AddRange(model.User.UserRoles);
            entities.SaveChanges();
            return RedirectToAction(nameof(List));
        }
        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            IdentityProfileAppContext entities = new IdentityProfileAppContext();
            var userInDb = entities.User.SingleOrDefault(c => c.Id == id);
            if (userInDb == null)
            {
                return Json(new
                {
                    Status = "error",
                    Message = "Belirtilen kriterlere uygun bir kullanıcı bulunamadı."
                });
            }
            entities.User.Remove(userInDb);
            entities.SaveChanges();
            return Json(new
            {
                Status = "ok",
                Message = "Kullanıcı başarıyla silindi"
            });
        }

      
    }
}