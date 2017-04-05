using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using AppNetServer;

namespace AppNetTests
{
    [TestClass]
    public class ControllerTests
    {
        [TestMethod]
        public void Get()
        {
            DemoController controller = new DemoController();
        }
    }
}
