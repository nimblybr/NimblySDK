using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using NimblySDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimblySDK.Tests
{
    [TestClass()]
    public class NimblyClientTests
    {
        [TestMethod()]
        public void GetTest()
        {
            NimblyClient nimblyClient = new NimblyClient()
            {
                CN = "Tatico"
            };

            Console.Write(JsonConvert.SerializeObject(nimblyClient.Get("api/ping")));
        }
    }
}