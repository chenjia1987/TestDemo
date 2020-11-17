using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsService1;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Service1 service1 = new Service1();
        }
    }
}
