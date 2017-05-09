using AppNetServer;
using AppNetServer.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppNetServer
{
    public class AuftragController : ApiController
    {
        private AppNetServices service = new AppNetServices();

        [HttpGet]
        //[ActionName("allOrders")]
        public ArrayList Get()
        {
            return service.getAllOrders();
        }

        // GET: api/auftrag/sortBy&userId
        public ArrayList Get(string sortBy, int userId)
        {
            return service.getYourOrders(sortBy, userId);
        }

        // POST: api/auftrag
        public HttpResponseMessage Post([FromBody]Auftrag auftrag)
        {
            service.addAuftrag(auftrag);
            HttpResponseMessage response = Request.CreateResponse(System.Net.HttpStatusCode.Created);
            //response.Headers.Location = new Uri(Request.RequestUri, String.Format("demo"));
            return response;
        }
        // DELETE: api/auftrag/5
        public HttpResponseMessage Delete(int auftragsNummer)
        {
            bool recordExisted = service.deleteAuftrag(auftragsNummer);
            if (recordExisted){
                HttpResponseMessage response = Request.CreateResponse(System.Net.HttpStatusCode.NoContent);
                return response;

            }
            else
            {
                HttpResponseMessage response = Request.CreateResponse(System.Net.HttpStatusCode.NotFound);
                return response;
            }
        }

        // PUT: api/auftrag/5
        public HttpResponseMessage Put(int auftragsNummer, [FromBody]Auftrag auftrag)
        {
            bool recordExisted = service.updateAuftrag(auftragsNummer, auftrag);
            HttpResponseMessage response;
            if (recordExisted)
            {
                response = Request.CreateResponse(System.Net.HttpStatusCode.NoContent);
            }
            else
            {
                response = Request.CreateResponse(System.Net.HttpStatusCode.NotFound);
            }
            return response;
        }
    } 
}
