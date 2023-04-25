using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using IdentityProfileApp.Context;
using IdentityProfileApp.Utils;
using IdentityProfileApp.Utils.AppGlobalization.Helper;
using IdentityProfileApp.Web.BLL;
using IdentityProfileApp.Web.StaticClasses;

namespace IdentityProfileApp.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            IdentityProfileAppContext entities = new IdentityProfileAppContext();
            if (entities.Database.CreateIfNotExists())
            {
                IdentityProfileSeeder.Seed(entities);
                CityDistrictStatics.FillCityDistricts();
            }
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ModelBinders.Binders.DefaultBinder = new CustomModelBinder();
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.Cookies["Language"] == null)
            {
                HttpCookie lang = new HttpCookie("Language", GlobalHelper.CurrentCulture);
                lang.Expires = DateTime.Now.AddYears(1);

                HttpContext.Current.Response.Cookies.Add(lang);
            }
            UICultureBLL.SetLanguageFromCode(HttpContext.Current.Request.Cookies.Get("Language").Value);
            UICultureBLL.SetResourcesFromCode(HttpContext.Current.Request.Cookies.Get("Language").Value);
        }
    }
}
