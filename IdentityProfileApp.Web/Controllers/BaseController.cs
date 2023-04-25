using IdentityProfileApp.Context;
using IdentityProfileApp.Domain.Entities.Models;
using IdentityProfileApp.Utils.AppGlobalization.Helper;
using IdentityProfileApp.Utils.Extensions;
using IdentityProfileApp.Web.BLL;
using System;
using System.Data.Entity.Validation;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace IdentityProfileApp.Web.Controllers
{
    public class BaseController : Controller
    {
        private static string _cookieLangName = "Language";
        protected override void OnException(ExceptionContext filterContext)
        {
            string action = filterContext.RouteData.Values["action"]
                .ToString();
            string controller = filterContext.RouteData.Values["controller"]
                .ToString();
            object model = TempData["model"];
            IdentityProfileAppContext ctx = new IdentityProfileAppContext();
            ctx.Errors.Add(new LogError()
            {
                Id = Guid.NewGuid(),
                Action = action,
                Controller = controller,
                Trace = filterContext.Exception.StackTrace,
                Message = filterContext.Exception.Message
            });
            ctx.SaveChanges();

            filterContext.ExceptionHandled = true;

            string message = "";

            if (filterContext.Exception is DbEntityValidationException)
            {
                DbEntityValidationException validationExceptions = filterContext.Exception as DbEntityValidationException;
                message = validationExceptions.ParseDbValidationErrors();
            }
            else
            {
                message = filterContext.Exception.Message;
            }

            filterContext.Result = new ViewResult
            {
                ViewName = action,
                ViewData = new ViewDataDictionary
                {
                    Model = model
                },
                TempData = new TempDataDictionary
                {
                   {"error",message }
                }
            };
            base.OnException(filterContext);
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            #region ValidationError
            if (!ModelState.IsValid)
            {
                TempDataDictionary dic = new TempDataDictionary();
                dic.Add("error", ModelState.ParseModelStateErrors());
                filterContext.Result = new ViewResult
                {
                    ViewName = filterContext.RouteData.Values["action"].ToString(),
                    TempData = dic
                };
            }
            #endregion

            #region Culture
            string cultureOnCookie = GetCultureOnCookie(filterContext.HttpContext.Request);
            string cultureOnURL = filterContext.RouteData.Values.ContainsKey("lang") ? filterContext.RouteData.Values["lang"].ToString() : GlobalHelper.CurrentCulture;

            string culture = string.IsNullOrEmpty(cultureOnCookie) ? GlobalHelper.CurrentCulture : cultureOnCookie;
            if (cultureOnURL != culture)
            {
                if (filterContext.RouteData.Values.ContainsKey("id"))
                {
                    string idOnUrl = filterContext.RouteData.Values["id"].ToString();
                    filterContext.HttpContext.Response.RedirectToRoute("LocalizedDefault", new { id = idOnUrl, lang = culture, controller = filterContext.RouteData.Values["controller"], action = filterContext.RouteData.Values["action"] });
                }
                else if (filterContext.RouteData.Values.ContainsKey("page"))
                {
                    string pageOnUrl = filterContext.RouteData.Values["page"].ToString();
                    filterContext.HttpContext.Response.RedirectToRoute("LocalizedDefault", new { page = pageOnUrl, lang = culture, controller = filterContext.RouteData.Values["controller"], action = filterContext.RouteData.Values["action"] });
                }
                else
                {
                    filterContext.HttpContext.Response.RedirectToRoute("LocalizedDefault", new { lang = cultureOnURL, controller = filterContext.RouteData.Values["controller"], action = filterContext.RouteData.Values["action"] });
                }

                SetCultureOnCookie(filterContext.HttpContext.Response, cultureOnURL);
                //This method set language from resource code
                UICultureBLL.SetLanguageFromCode(cultureOnURL);
                UICultureBLL.SetResourcesFromCode(cultureOnURL);
                return;
            }
            #endregion

            base.OnActionExecuting(filterContext);
        }

        private static string culture = string.Empty;
        public static string GetCultureOnCookie(HttpRequestBase request)
        {
            HttpCookie cookie = request.Cookies[_cookieLangName];

            if (cookie != null)
            {
                culture = cookie.Value;
            }
            else
            {
                culture = GlobalHelper.CurrentCulture;
            }
            return culture;
        }

        public void SetCultureOnCookie(HttpResponseBase request, string langcookie)
        {
            string cookie = request.Cookies[_cookieLangName].Value;
            request.Cookies.Remove(_cookieLangName);
            request.Cookies.Add(new HttpCookie(_cookieLangName, langcookie));
        }

        public string GetUserNameByCookie()
        {
            string cookieName = FormsAuthentication.FormsCookieName;
            HttpCookie authCookie = HttpContext.Request.Cookies[cookieName]; //Get the cookie by it's name
            if (authCookie == null)
            {
                return "";
            }

            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value); //Decrypt it
            return ticket.Name;

        }
    }
}