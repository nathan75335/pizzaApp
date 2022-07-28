using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaClasses;

namespace UnitTestPizzaProject
{
    [TestClass]
    public class OrderDaoTest
    {
        OrderDao orderDao = new OrderDao();
        [TestMethod]
        public void InsertAnOrderTest()
        {
            orderDao.connectionString = @"C:\Users\joyce\OneDrive\Bureau\Test IsonFIles\OrderTest.json";
            Assert.IsTrue(orderDao.InsertNewOrderToJsonFile(new Order("teure", null, DateTime.Now)));
        }
        [TestMethod]
        public void VerificationOfFile()
        {
            Assert.IsTrue(File.Exists(orderDao.connectionString));
        }

    }
}
