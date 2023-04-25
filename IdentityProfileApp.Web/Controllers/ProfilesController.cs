using IdentityProfileApp.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityProfileApp.Web.Controllers
{
    [Authorize(Roles = "AppUser")]
    public class ProfilesController : BaseController
    {
        public ActionResult Get(Guid id)
        {
            IdentityProfileAppContext entities = new IdentityProfileAppContext();
            var profile = entities.Profile.Include("Features").FirstOrDefault(x => x.Id == id);
            return View(profile);
        }

        public ActionResult Index()
        {
            IdentityProfileAppContext entities = new IdentityProfileAppContext();
            return View(entities.Profile.ToList());
        }
    }
}