using AppNetServer;
using AppNetServer.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace AppNetServer
{
    public class RegistrationController : ApiController
    {
        private AppNetServices service = new AppNetServices();
        // GET: api/registration
        public void Get()
        {
           
        }

        // POST: api/registration/id
        public void Post(int id, [FromBody]Object user)
        {
            if(id == 0)
            {
                Auftraggeber auftraggeber = (Auftraggeber)user;

            }
            else if (id == 1)
            {
                Auftragnehmer auftragnehmer = (Auftragnehmer)user;
            }
        }

        //POST: api/registration
        public void Post([FromBody]Auftragnehmer auftragnehmer)
        {

        }
    }
}
