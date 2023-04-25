using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using IdentityProfileApp.Context;
using IdentityProfileApp.Domain.Entities.DTO;
using IdentityProfileApp.Domain.Entities.Models;
using IdentityProfileApp.Domain.Entities.ViewModels;
using IdentityProfileApp.Utils;
using IdentityProfileApp.Utils.Helpers;
using IdentityProfileApp.Web.BLL;
using IdentityProfileApp.Web.StaticClasses;

namespace IdentityProfileApp.Web.Controllers
{
    public class AccountController : BaseController
    {
        #region Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginVM model)
        {
            var user = ActiveUserBLL.GetUserByEmail(model.Email);

            if (user.Count > 0)
            {
                var getUser = user.Where(x => x.EmailAdress == model.Email && x.Password.Decrypt("Identity") == model.Password).FirstOrDefault();
                if (getUser != null)
                {
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, model.Email, DateTime.Now, DateTime.Now.AddDays(1), model.RememberMe,"",FormsAuthentication.FormsCookiePath);
                    string hash = FormsAuthentication.Encrypt(ticket);
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);

                    if (ticket.IsPersistent)
                    {
                        cookie.Expires = ticket.Expiration;
                    }

                    Response.Cookies.Add(cookie);

                    if (Request.QueryString["ReturnUrl"] != null)
                    {
                        return Redirect(Request.QueryString["ReturnUrl"]);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    TempData["error"] = "Şifre Hatalı";
                    model.Password = "";
                    return View(model);
                }
            }
            else
            {
                TempData["error"] = "Bu mail adresine ait bir kayıt bulunmadı";
                model.Password = "";
                return View(model);
            }
        }
        #endregion


        #region Register
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Register(RegisterVM model)
        {
            if (!ModelState.IsValid)
            {
                TempData.Keep("profileId");
                return View(model);
            }
            Guid profileId = TempData["profileId"] == null ? Guid.Empty : Guid.Parse(TempData["profileId"].ToString());

            IdentityProfileAppContext entities = new IdentityProfileAppContext();

            model.User.Id = Guid.NewGuid();
            model.User.Password = model.User.Password.Encrypt("Identity");

            var userInDb = entities.User.FirstOrDefault(m => m.EmailAdress == model.User.EmailAdress);

            if (userInDb != null)
            {
                TempData["error"] = "Bu mail adresine ait bir kayıt bulunmaktadır.";
                return View();
            }
            else
            {
                entities.User.Add(model.User);
                entities.UserInRoles.Add(new UserInRole() { UserId = model.User.Id, RoleId = entities.Roles.FirstOrDefault(x => x.Name == "AppUser").Id });
                entities.SaveChanges();
                TempData["success"] = "Kayıt başarıyla oluşturuldu bu kullanıcı adı ve şifresiyle giriş yapabilirsiniz";
            }
            if (profileId != Guid.Empty)
            {
                List<StatisticResult> statistics = (List<StatisticResult>)TempData["statistics"];
                foreach (var stat in statistics)
                {
                    if (stat.Value < 50)
                    {
                        stat.Value = 100 - stat.Value;
                    }
                }
                if (entities.Profile.SingleOrDefault(p => p.Id == profileId) != null)
                {
                    UserProfile userProfile = new UserProfile()
                    {
                        Id = Guid.NewGuid(),
                        ProfileId = profileId,
                        UserId = model.User.Id,
                        TestTime = DateTime.Now,
                        Stats = string.Join(",", statistics.Select(x => x.Value)),

                    };
                    entities.UserProfile.Add(userProfile);
                    entities.SaveChanges();
                    return RedirectToAction("Login", "Account", new { lang = HttpContext.Request.Cookies.Get("Language").Value });

                }
                else
                {
                    TempData["error"] = "Bir hata ile karşılaşıldı";
                    return View(model);
                }

            }
            else
            {
                return View();
            }


        }
        public JsonResult GetDistricts(int id)
        {
            return Json(CityDistrictStatics.GetDistrictsByCityId(id), JsonRequestBehavior.AllowGet);
        }
        #endregion


        #region ForgotPassword
        protected string RenderPartialViewToString(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.RouteData.GetRequiredString("action");

            ViewData.Model = model;

            using (StringWriter sw = new StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                ViewContext viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }

        public JsonResult RecoveryPassword(string email)
        {
            IdentityProfileAppContext entities = new IdentityProfileAppContext();

            if (entities.User.FirstOrDefault(e => e.EmailAdress == email) != null)
            {
                MailSender mailSender = new MailSender();
                string body = RenderPartialViewToString("~/Areas/Admin/Views/Shared/_ForgotPassword.cshtml", null);
                mailSender.EmailSender(email, "Şifre Değiştir", body);
                return Json(new
                {
                    Status = "ok",
                    Html = RenderPartialViewToString("~/Views/Shared/_RecoveryPasswordOk.cshtml", null)
                }, JsonRequestBehavior.AllowGet); ;
            }
            else
            {
                return Json(new
                {
                    Status = "notfound",
                    Message = "Bu emaile ait bir hesap yok"
                }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult ResetPassword()
        {
            return View();
        }
        #endregion


        #region Logout
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        #endregion
    }
}