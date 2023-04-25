using IdentityProfileApp.Context;
using IdentityProfileApp.Domain.Entities.Models;
using IdentityProfileApp.Domain.Entities.ViewModels;
using IdentityProfileApp.Utils.Extensions;
using System;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityProfileApp.Web.Controllers
{
    public class SettingsController : BaseController
    {
        // GET: Settings
        public ActionResult ProfileSettings(Guid Id, HttpPostedFileBase file)
        {
            IdentityProfileAppContext entities = new IdentityProfileAppContext();
            SettingsVM userVM = new SettingsVM();
            var user = entities.User.FirstOrDefault(x => x.Id == Id);
            if (user == null)
            {
                TempData["error"] = "Yanlış id";
                return RedirectToAction("Index", "Home");
            }
            if (user.EmailAdress != User.Identity.Name)
            {
                TempData["error"] = "Yetkisiz";
                return RedirectToAction("Index", "Home");
            }
            userVM.User = user;
            return View(userVM);
        }

        [HttpPost]
        public ActionResult Update(SettingsVM model)
        {
            return View("ProfileSettings", model);
        }
        [HttpPost]
        public ActionResult UploadUserImage(string id, HttpPostedFileBase file)
        {
            var image = file.CropImage(50, 50);
            var path = Server.MapPath("~/Content/User/Avatar/" + id + ".jpg");
            image.Save(path, ImageFormat.Jpeg);

            return View("index");
        }


    }
}