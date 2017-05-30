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
    public class ProfilController : ApiController
    {
        [Authorize]
        [HttpGet]
        [ActionName("getAuftraggeberProfil")]
        public Auftraggeber getAuftraggeberProfil(int userid)
        {
            var profile = new AppNetEntities().Auftraggeber.Where(u => u.Id == userid).SingleOrDefault();
            return profile;
        }

        [Authorize]
        [HttpGet]
        [ActionName("getAuftragnehmerProfil")]
        public Auftragnehmer getAuftragnehmerProfil(int userid)
        {
            return new AppNetEntities().Auftragnehmer.Where(u => u.userid == userid).SingleOrDefault();
        }
    } 
}
