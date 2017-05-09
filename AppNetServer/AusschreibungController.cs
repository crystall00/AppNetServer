using AppNetServer;
using AppNetServer.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace AppNetServer
{
    public class AusschreibungController : ApiController
    {
        private AppNetServices service = new AppNetServices();

        [Authorize]
        [HttpGet]
        [ActionName("published")]
        // GET: api/ausschreibung?sortBy&userId
        public ArrayList Get(string sortBy, int userId)
        {
            return service.getYourPublishedOrders(sortBy, userId);
        }

    } 
}
