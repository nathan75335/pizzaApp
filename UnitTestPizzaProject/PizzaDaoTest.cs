using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaClasses;

namespace UnitTestPizzaProject
{
    [TestClass]
    public class PizzaDaoTest
    {
        AdministratorDaoPizza pizzaDao = new AdministratorDaoPizza();
        [TestMethod]
        public void AddNewPizzaText()
        {
            pizzaDao.Connection = @"C:\Users\joyce\OneDrive\Bureau\Test IsonFIles\PizzaTest.json";
            var pizza = new Pizza("Numerinon", "dscripyion", 423, @"fgeg");
            var result = pizzaDao.AddNewPizzaToJsonFile(pizza);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void UpdateAPizzaTest()
        {
            IPizza pizza = new Pizza("Numerinon", "dscripyionfwf", 425, @"fsfsdf");
            var result = pizzaDao.UpdatePizza(pizza);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void DeleteAPizza()
        {
            var pizza = new Pizza("Numerinon", "dscripyionfwf", 423, @"nhtr");
            var result = pizzaDao.DeletePizzaFromTheCatalog(pizza);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void VerificationOfFileTest()
        {
            Assert.IsTrue(File.Exists(pizzaDao.Connection));
        }
        [TestMethod]
        public void LoadFromFileTest()
        {
            pizzaDao.LoadPizzaFromFile();
            Assert.IsNotNull(pizzaDao.pizzas);
        }
    }
}
