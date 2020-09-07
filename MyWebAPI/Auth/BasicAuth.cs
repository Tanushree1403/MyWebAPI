using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace MyWebAPI.Auth
{
    public class BasicAuthAttribute: AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization != null)
            {
                var param= actionContext.Request.Headers.Authorization.Parameter;
                var decodeParam = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(param));
                string[] credential = decodeParam.Split(':');
                if (credential.Length >= 2)
                {
                    if (IsAuthorisedUser(credential[0].ToString(), credential[1].ToString()))
                    {
                        // setting current principle  
                        Thread.CurrentPrincipal = new GenericPrincipal(
                        new GenericIdentity(credential[0]), null);
                    }
                    else
                    {
                        actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                    }
                }
                else
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);

            }
            else
                actionContext.Response= actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
        }

        public static bool IsAuthorisedUser(string userName, string Password)
        {
            return (userName == "tanu" && Password == "12345")? true: false;
        }
    }
}