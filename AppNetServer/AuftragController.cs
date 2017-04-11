using AppNetServer;
using AppNetServer.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace AppNetServer
{
    class AuftragController : ApiController
    {
        private AppNetServices service = new AppNetServices();
        // GET: api/demo
        public ArrayList Get()
        {
            return service.getAllOrders();
        }

        // GET: api/demo
        public Auftrag Get(int i)
        {
            Auftrag auftrag = new Auftrag();
            return auftrag;
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
