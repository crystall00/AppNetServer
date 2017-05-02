using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using AppNetServer;
using AppNetServer.Services;
using System.Net.Http;

namespace AppNetTests
{
    [TestClass]
    public class ControllerTests
    {
        private AppNetServices _productService;

        private HttpClient _client;

        private HttpResponseMessage _response;

        private const string ServiceBaseURL = "http://appnet.hsr.ch:40000";
        [TestMethod]
        public void Get()
        {
        }
    }
}
