﻿using AppNetServer;
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

namespace AppNetServer
{
    public class AuftragController : ApiController
    {
        private AppNetServices service = new AppNetServices();

        [HttpGet]
        [ActionName("test")]
        public IEnumerable<Auftrag> Get()
        {
            using (AppNetEntities2 entities = new AppNetEntities2())
            {
                return entities.Auftrag.ToList();
            }
        }

        [Authorize]
        [HttpGet]
        [ActionName("YourOrders")]
        // GET: api/auftrag/sortBy&userId
        public ArrayList Get(string sortBy, int userId)
        {
            return service.getYourOrders(sortBy, userId);
        }

        [Authorize]
        [HttpGet]
        [ActionName("YourPublishedOrders")]
        // GET: api/ausschreibung?sortBy&userId
        public ArrayList GetYourPublishedOrders(string sortBy, int userId)
        {
            return service.getYourPublishedOrders(sortBy, userId);
        }

        [Authorize]
        [HttpPost]
        [ActionName("PostOrder")]
        // POST: api/auftrag
        public HttpResponseMessage Post([FromBody]Auftrag auftrag)
        {
            using (var context = new AppNetEntities2())
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
