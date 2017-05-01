using AppNetServer;
using AppNetServer.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace AppNetServer
{
    public class AuftragController : ApiController
    {
        private AppNetServices service = new AppNetServices();
        // GET: api/auftrag/sortierParameter
        public ArrayList Get(int sortParameter, bool published)
        {
            return service.getAllOrders(sortParameter, published);
        }

        // GET: api/auftrag/sortierParameter&published=false&userId
        public ArrayList Get(int sortParameter, bool published, int userId)
        {
            return service.getYourOrders(sortParameter, published, userId);
        }

        // POST: api/auftrag
        public HttpResponseMessage Post(int userid,[FromBody]Auftrag auftrag)
        {
            service.addAuftrag(userid, auftrag);
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
