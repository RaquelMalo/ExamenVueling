using System.Web.Http;
using System.Web.Mvc;
using NLog;
using ExceptionContext = System.Web.Mvc.ExceptionContext;

namespace ApiBusinessMen.Controllers
{
    public class BaseController : Controller
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        protected override void OnException(ExceptionContext context)
        {
            // Catch invalid operation exception
            //if (!(context.Exception is InvalidOperationException)) return;
            var controllerName = context.RouteData.Values["controller"].ToString();
            var actionName = context.RouteData.Values["action"].ToString();
            var model = new HandleErrorInfo(context.Exception, controllerName, actionName);
            var result = new ViewResult
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                //Save pass the current Temp Data to the Error view, because it often contains
                //diagnostic information
                TempData = context.Controller.TempData
            };
            Logger.Error(context.Exception.InnerException, context.Exception.Message);
            context.Result = result;
        }
    }
}