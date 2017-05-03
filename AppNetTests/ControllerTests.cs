using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using AppNetServer;
using AppNetServer.Services;
using System.Net.Http;
using System.Web.Http.Hosting;
using Newtonsoft.Json;
using System.Net;
using NUnit.Framework;

namespace AppNetTests
{
    [TestFixture]  
    public class ControllerTests
    {
        private AppNetServices appnetServices;
        private List<Auftrag> auftraege;
        private HttpClient client;
        private HttpResponseMessage response;
        private const string ServiceBaseURL = "http://appnet.hsr.ch:40000";


        [OneTimeSetUp]
        public void Setup()
        {
            auftraege = SetUpOrders();
            appnetServices = new AppNetServices();
            client = new HttpClient { BaseAddress = new Uri(ServiceBaseURL) };
        }


        [Test]
        public void GetYourOrdersTest()
        {
            var auftragController = new AuftragController(appnetServices)
            {
                Request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(ServiceBaseURL + "api/auftrag/")
                }
            };

            auftragController.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());

            response = auftragController.Get();

            var responseResult = JsonConvert.DeserializeObject<List<Auftrag>>(response.Content.ReadAsStringAsync().Result);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            Assert.AreEqual(responseResult.Any(), true);
            var comparer = new AuftragComparer();
            CollectionAssert.AreEqual(
            responseResult.OrderBy(auftrag => auftrag, comparer),
            auftraege.OrderBy(auftrag => auftrag, comparer), comparer);
        }

    
        private List<Auftrag> SetUpOrders()
        {
            int auftragsNummer = 4;
            var auftragsListe = InitializeDummyOrders();
            foreach (Auftrag auftrag in auftragsListe)
                auftrag.auftragsNummer = ++auftragsNummer;
            return auftragsListe;
        }

        private List<Auftrag> InitializeDummyOrders()
        {
            var auftragListe = new List<Auftrag>
            {
                new Auftrag() {erstelldatum = Convert.ToDateTime("01.05.2017 20:30:55"), titel = "iPad Game", beschreibung = "Hello World. lorem Impusm", ort = "Schmerikon", userid = 0, ausgeschrieben = false, ausschreibungsende = null},
                new Auftrag() {erstelldatum = Convert.ToDateTime("01.05.2017 21:22:01"), titel = "Mobile App", beschreibung = "This is a Test. lorem Impusm", ort = "Rapperswil", userid = 0, ausgeschrieben = false, ausschreibungsende = null},
                new Auftrag() {erstelldatum = Convert.ToDateTime("02.05.2017 08:20:22"), titel = "Microsoft Game", beschreibung = "lorem Impusm. I request an App", ort = "Zuerich", userid = 0, ausgeschrieben = false, ausschreibungsende = null},
                new Auftrag() {erstelldatum = Convert.ToDateTime("02.05.2017 11:55:30"), titel = "Android App", beschreibung = "lorem Impusm", ort = "Bern", userid = 0, ausgeschrieben = false, ausschreibungsende = null},
                new Auftrag() {erstelldatum = Convert.ToDateTime("03.05.2017 06:21:33"), titel = "Security App", beschreibung = "ABC. lorem Impusm", ort = "Luzern", userid = 0, ausgeschrieben = false, ausschreibungsende = null}
            };

            return auftragListe;
        }
    }
}
