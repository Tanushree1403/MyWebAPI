using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyWebAPI.Filters
{
    public class LoginFilter: System.Web.Http.Filters.ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            Log("OnActionExecuted", actionExecutedContext.ActionContext);
        }

        private void Log(string methodName, System.Web.Http.Controllers.HttpActionContext routeData)
        {
            var controllerName = routeData.ControllerContext.ControllerDescriptor.ControllerName;
            var actionName = routeData.ActionDescriptor.ActionName;
            var message = String.Format("{0} controller:{1} action:{2} Time:{3} /n", methodName, controllerName, actionName,DateTime.Now);
            string Filepath = @"C:/Users/iumh/source/repos/MyWebAPI/MyWebAPI/LogFile.txt";
            using (StreamWriter sw = File.AppendText(Filepath))
            {
                sw.WriteLine(message);
            }
       
        }
    }
}