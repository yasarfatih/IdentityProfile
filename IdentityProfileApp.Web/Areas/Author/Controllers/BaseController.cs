using IdentityProfileApp.Context;
using IdentityProfileApp.Domain.Entities.Models;
using IdentityProfileApp.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityProfileApp.Web.Areas.Author.Controllers
{
    public class BaseController : Controller
    {
        // GET: Author/Base
        protected override void OnException(ExceptionContext filterContext)
        {
            string action = filterContext.RouteData.Values["action"]
                .ToString();
            string controller = filterContext.RouteData.Values["controller"]
                .ToString();
            object model = TempData["model"];


            IdentityProfileAppContext entities = new IdentityProfileAppContext();
            var error = new LogError()
            {
                Id = Guid.NewGuid(),
                Action = action,
                Controller = controller,
                Trace = filterContext.Exception.StackTrace,
                Message = filterContext.Exception.Message
            };
            entities.Errors.Add(error);

            filterContext.ExceptionHandled = true;

            //istek ajax yöntemi ile yapılan bir istek mi
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                //isteğin ajax isteği olduğuna dair bilyiyi set edelim.
                error.IsAjaxRequest = true;
                entities.SaveChanges();
                filterContext.Result = Json(new
                {
                    Status = "error",
                    Message = "İşlem esnasında bir hata oluştu. Hata kayıt altına alındı. <br/>Hata No : " + error.Id
                });
            }
            else //hata normal bir action çağrılırken ortaya çıktı
            {
                entities.SaveChanges();

                //Kullanıcıyı geldiği View'e model ve tempdata ile yolluyoruz.
                var tempDic = new TempDataDictionary();
                tempDic.Add("error", "İşlem esnasında bir hata oluştu. Hata kayıt altına alındı. <br/>Hata No : " + error.Id);

                var viewDic = new ViewDataDictionary();
                viewDic.Model = filterContext.Controller.ViewData.Model;

                filterContext.Result = new ViewResult
                {
                    ViewName = filterContext.RouteData.Values["action"].ToString(),
                    TempData = tempDic,
                    ViewData = viewDic
                };
            }
            //base.OnException(filterContext);
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!ModelState.IsValid)
            {
                var dic = new TempDataDictionary();

                dic.Add("error", ModelState.ParseModelStateErrors());
                IdentityProfileAppContext ctx = new IdentityProfileAppContext();
                var viewDic = new ViewDataDictionary();
                viewDic.Model = filterContext.Controller.ViewData.Model;
                filterContext.Result = new ViewResult
                {
                    ViewName = filterContext.RouteData.Values["action"].ToString(),
                    TempData = dic,
                    ViewData = viewDic
                };
            }
        }
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
    }
}