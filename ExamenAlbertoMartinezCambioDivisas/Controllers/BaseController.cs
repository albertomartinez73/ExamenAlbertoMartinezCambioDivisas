using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExamenAlbertoMartinezCambioDivisas.Services.Log;

namespace ExamenAlbertoMartinezCambioDivisas.Controllers
{
    public class BaseController : Controller
    {
        private ILog log;
        protected override void OnException(ExceptionContext filterContext)
        {
            this.log = new LogFichero();

            if (filterContext.ExceptionHandled)
            {
                return;

            }

            this.log.EscribirLog(filterContext.Exception.Message);

            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Shared/Error.cshtml"
            };
        }
    }
}