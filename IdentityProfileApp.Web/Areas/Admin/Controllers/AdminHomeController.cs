using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace IdentityProfileApp.Web.Areas.Admin.Controllers
{
    public class AdminHomeController : BaseController
    {
        // GET: Admin/Home
        //[Authorize(Roles = "admin")]
        //todo 
        public ActionResult Index()
        {
            return View();
        }

    }
}