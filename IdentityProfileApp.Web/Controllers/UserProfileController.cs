using IdentityProfileApp.Context;
using IdentityProfileApp.Domain.Entities.DTO;
using IdentityProfileApp.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace IdentityProfileApp.Web.Controllers
{
    [Authorize(Roles = "AppUser")]
    public class UserProfileController : BaseController
    {
        // GET: UserProfile
        public ActionResult Result()
        {
            Profile profile = (Profile)TempData["profile"];
            TempData.Keep("profile");
            TempData["profileId"] = profile.Id;
            TempData.Keep("profileId");
            return View(profile);
        }
        //first commit
        [NoCache]
        public ActionResult MyProfile()
        {
            var entities = new IdentityProfileAppContext();
            var userName = GetUserNameByCookie();
            if (string.IsNullOrEmpty(userName))
            {
                TempData["error"] = "Profilinizi görüntülebilmek için öncelikle oturum açmalısınız";
                return RedirectToAction("Index", "Home");
            }
            var user = entities.User.FirstOrDefault(u => u.EmailAdress == userName);
            var userInProfile = entities.UserProfile.Include(p => p.Profile).Include(f => f.Profile.Features).Include(u => u.User).FirstOrDefault(up => up.UserId == user.Id);
            if (userInProfile==null)
                userInProfile = new UserProfile()
                {
                    User = user,
                    Profile = null
                };
            return View(userInProfile);
        }
        User currentUser;
        public ActionResult SaveProfile()
         {
            IdentityProfileAppContext entities = new IdentityProfileAppContext();

            if (!string.IsNullOrEmpty(User.Identity.Name))
            {
                currentUser = entities.User.SingleOrDefault(x => x.EmailAdress == User.Identity.Name);
            }
            else
            {
                TempData["error"] = "Bir hata ile karşılaşıldı";
                return RedirectToAction("Result");
            }
            Guid profileId = Guid.Parse(TempData["profileId"].ToString());
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
                if (entities.UserProfile.FirstOrDefault(x => x.UserId == currentUser.Id) == null)
                {
                    UserProfile userProfile = new UserProfile()
                    {
                        Id = Guid.NewGuid(),
                        ProfileId = profileId,
                        UserId = currentUser.Id,
                        TestTime = DateTime.Now,
                        Stats = string.Join(",", statistics.Select(x => x.Value)),

                    };
                    entities.UserProfile.Add(userProfile);
                    entities.SaveChanges();
                    TempData["success"] = "Profil başarı ile kaydedildi";
                    return RedirectToAction(nameof(MyProfile));
                }
                else
                {
                    var profileForUpdate = entities.UserProfile.FirstOrDefault(up => up.UserId == currentUser.Id);
                    if (profileForUpdate != null)
                    {
                        profileForUpdate.ProfileId = profileId;
                        profileForUpdate.UserId = currentUser.Id;
                        profileForUpdate.TestTime = DateTime.Now;
                        profileForUpdate.Stats = string.Join(",", statistics.Select(x => x.Value));
                        entities.SaveChanges();
                        TempData["success"] = "Profil başarı ile güncellendi";
                        return RedirectToAction(nameof(MyProfile));
                    }
                    else
                    {
                        TempData["danger"] = "Bir hata ile karşılaşıldı";
                        return RedirectToAction("Result");
                    }
                }
            }
            else
            {
                TempData["error"] = "Bir hata ile karşılaşıldı";
                return View(entities.Profile.FirstOrDefault(x=>x.Id==profileId));
            }
        }
    }
}