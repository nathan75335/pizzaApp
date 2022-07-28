using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaClasses;

namespace UnitTestPizzaProject
{
    [TestClass]
    public class PizzaComponentTest
    {
        PizzaDaoComponents dao = new PizzaDaoComponents();
        [TestMethod]
        public void InsertANewCompoTest()
        {
            dao.conncetionToJsonFile = @"C:\Users\joyce\OneDrive\Bureau\Test IsonFIles\PizzaComponentTest.json";
            Assert.IsTrue(dao.InsertANewIngredients(new PizzaComponent("sfsdf", 45, 44)));
        }
        [TestMethod]
        public void UpdateTheCompoTest()
        {
            Assert.IsTrue(dao.UpdatePizzaComponentInFIle(new PizzaComponent("sfsdf", 45, 46)));
        }
        [TestMethod]
        public void DeleteTheCompoTest()
        {
            Assert.IsTrue(dao.DeletePizzaComponentFromFile(new PizzaComponent("sfsdf", 45, 46)));
        }
        [TestMethod]
        public void LoadDataFromFileTest()
        {
            dao.LoadDataFromFile();
            Assert.IsNotNull(dao.pizzaComponents);
        }
    }
}
