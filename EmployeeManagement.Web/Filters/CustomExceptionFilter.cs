using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace MyWebAPI.Filters
{
    public class CustomExceptionFilter : FilterAttribute, IExceptionFilter
    {

        public void OnException(System.Web.Mvc.ExceptionContext filterContext)
        {
            //throw new NotImplementedException();
            if (!filterContext.ExceptionHandled && filterContext.Exception is NullReferenceException)
            {
                filterContext.Result = new RedirectResult("Error");
                filterContext.ExceptionHandled = true;
            }
        }
    }
}