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
        // GET: api/ausschreibung?sortierParameter&userId
        public ArrayList Get(int sortParameter, int userId)
        {
            return service.getYourPublishedOrders(sortParameter, userId);
        }

    } 
}
