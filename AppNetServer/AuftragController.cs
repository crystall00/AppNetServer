using AppNetServer;
using AppNetServer.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Linq;
using Newtonsoft.Json;
using System.Data.Entity;
using System.Linq.Dynamic;

#pragma warning disable 1591

namespace AppNetServer
{
    public class AuftragController : ApiController
    {
        private AppNetServices service = new AppNetServices();

        [HttpGet]
        [ActionName("test")]
        public IEnumerable<Auftrag> Get()
        {
            var dbContext = new AppNetEntities();
            return dbContext.Auftrag.ToList();
        }

        [Authorize]
        [HttpGet]
        [ActionName("YourOrders")]
        // GET: api/auftrag/sortBy&userId
        public IEnumerable<Auftrag> Get(string sortBy, int userId)
        {
            try
            {
                var context = new AppNetEntities();

                var result = context.Auftrag
                            .Where(a => a.Id == userId)
                            .OrderBy(sortBy + " ASC")
                            .Select(a => a);

                return result.ToList();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [Authorize]
        [HttpGet]
        [ActionName("YourPublishedOrders")]
        // GET: api/ausschreibung?sortBy&userId
        public IEnumerable<Auftrag> GetYourPublishedOrders(string sortBy, int userId)
        {
            try
            {
                var context = new AppNetEntities();

                var result = context.Auftrag
                            .Where(a => a.Id == userId)
                            .Where(a => a.ausgeschrieben == true)
                            .OrderBy(sortBy + " ASC")
                            .Select(a => a);

                return result.ToList();
            }
            catch (Exception ex)
            {
                //test
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [Authorize]
        [HttpPost]
        [ActionName("PostOrder")]
        // POST: api/auftrag
        public HttpResponseMessage Post([FromBody]Auftrag auftrag)
        {
            using (var context = new AppNetEntities())
            {
                try { 
                    context.Auftrag.Add(auftrag);
                    context.SaveChanges();
                    HttpResponseMessage response = Request.CreateResponse(System.Net.HttpStatusCode.Created);
                    return response;
                }
                catch (Exception ex)
                {
                    HttpResponseMessage response = Request.CreateResponse(System.Net.HttpStatusCode.NotFound);
                    Console.WriteLine(ex.Message);
                    return response;
                }
            } 
        }

        [Authorize]
        [HttpDelete]
        [ActionName("DeleteOrder")]
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

        [Authorize]
        [HttpPut]
        [ActionName("UpdateOrder")]
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
