﻿using AppNetServer;
using AppNetServer.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace AppNetServer
{
    public class OfferteController : ApiController
    {
        private AppNetServices service = new AppNetServices();
        // GET: api/auftrag/sortierParameter
        public void Get(int sortParameter, bool published)
        {
            
        }

        // GET: api/auftrag/sortierParameter&published=false&userId
        public void Get(int sortParameter, bool published, int userId)
        {
            
        }

        // POST: api/auftrag
        public HttpResponseMessage Post([FromBody]Auftrag auftrag)
        {
            HttpResponseMessage response = Request.CreateResponse(System.Net.HttpStatusCode.Created);
            //response.Headers.Location = new Uri(Request.RequestUri, String.Format("demo"));
            return response;
        }
    } 
}
