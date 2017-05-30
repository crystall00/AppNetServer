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

#pragma warning disable 1591

namespace AppNetServer
{
    public class RegistrationController : ApiController
    {
        [AllowAnonymous]
        [HttpPost]
        [ActionName("RegisterAuftraggeber")]
        public HttpResponseMessage RegisterAuftraggeber([FromBody] Auftraggeber auftraggeber)
        {
            using (var context = new AppNetEntities())
            {
                try { 
                    context.Auftraggeber.Add(auftraggeber);
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

        [AllowAnonymous]
        [HttpPost]
        [ActionName("RegisterAuftragnehmer")]
        public HttpResponseMessage RegisterAuftragnehmer([FromBody] Auftragnehmer auftragnehmer)
        {
            using (var context = new AppNetEntities())
            {
                try
                {
                    context.Auftragnehmer.Add(auftragnehmer);
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
    } 
}
