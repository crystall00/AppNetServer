using AppNetServer;
using AppNetServer.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

#pragma warning disable 1591

namespace AppNetServer
{
    public class DataController : ApiController
    {
        private AppNetServices service = new AppNetServices();
        

        [AllowAnonymous]
        [HttpGet]
        [ActionName("forall")]
        public IHttpActionResult Get()
        {
            return Ok("Current Server Time is:" + DateTime.Now.ToString());
        }

        [Authorize]
        [HttpGet]
        [ActionName("authenticate")]
        public IHttpActionResult GetForAuthorizedUser()
        {
            var identity = (ClaimsIdentity)User.Identity;
            return Ok("Hello " + identity.Name);
        }
        [Authorize(Roles ="admin")]
        [HttpGet]
        [ActionName("authorize")]
        public IHttpActionResult GetForAdmin()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims
                        .Where(c => c.Type == ClaimTypes.Role)
                        .Select(c => c.Value);
            return Ok("Hello " + identity.Name + " Role: " + string.Join(",", roles.ToList()));
        }
    } 
}
