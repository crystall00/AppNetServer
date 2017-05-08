using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Threading;
using System.Net.Http;
using Microsoft.AspNet.Identity;

namespace AppNetServer
{
    class AuthorizeAttribute : System.Web.Http.AuthorizeAttribute
    {
       /*
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
 
                if (!HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    base.HandleUnauthorizedRequest(actionContext);
                }
                else
                {
                    actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
                }
        }*/
    }
}
