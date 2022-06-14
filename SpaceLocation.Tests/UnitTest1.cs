using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SpaceLocation.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var response = Repos.Apis.LocationApi.GetCurrentLocation();
            Assert.IsNotNull(response);

        }
    }
}
