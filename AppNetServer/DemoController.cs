using AppNetServer;
using AppNetServer.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace AppNetServer
{
    public class DemoController : ApiController
    {
        private AppNetServices service = new AppNetServices();
        // GET: api/demo
        public ArrayList Get()
        {
            return service.getAllOrders();
        }
    
        // POST: api/demo
        public HttpResponseMessage Post([FromBody]Auftrag auftrag)
        {
            service.save(auftrag);
            HttpResponseMessage response = Request.CreateResponse(System.Net.HttpStatusCode.Created);
            //response.Headers.Location = new Uri(Request.RequestUri, String.Format("demo"));
            return response;
        }
    } 
}
