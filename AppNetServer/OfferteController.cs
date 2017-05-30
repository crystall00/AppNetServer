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
    public class OfferteController : ApiController
    {

        [Authorize]
        [HttpGet]
        [ActionName("YourOffers")]
        public IEnumerable<Offerte> GetYourOffers(string sortBy, int userId)
        {
            try
            {
                var context = new AppNetEntities();

                var result = context.Offerte
                            .Where(a => a.userid == userId)
                            .OrderBy(sortBy + " ASC")
                            .Select(a => a);

                return result.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        [Authorize]
        [HttpGet]
        [ActionName("ReceivedOffers")]
        public IEnumerable<Offerte> GetReceivedOffers(string sortBy, int auftragsnummer)
        {
            try
            {
                var context = new AppNetEntities();

                var result = context.Offerte
                            .Where(a => a.auftragsNummer == auftragsnummer)
                            .OrderBy(sortBy + " ASC")
                            .Select(a => a);

                return result.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [Authorize]
        [HttpPost]
        [ActionName("PostOffer")]
        public HttpResponseMessage PostYourOffer([FromBody] Offerte offerte)
        {
            using (var context = new AppNetEntities())
            {
                try
                {
                    context.Offerte.Add(offerte);
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
