using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaClasses;

namespace UnitTestPizzaProject
{
    [TestClass]
    public class UserDaoTest
    {
        static UserDao dao = new UserDao();
      
        [TestMethod]
        public void TestInsertMethod()
        {
            dao.ConnectionToJsonFile = @"C:\Users\joyce\OneDrive\Bureau\Test IsonFIles\UserTest.json";
            User user = new User("Nathanods", "Kokine124");
            var result = dao.InsertToJsonFile(user);
            Assert.AreEqual(true,result);
        }
        [TestMethod]
        public void TestUpdateMethod()
        {
            dao.ConnectionToJsonFile = @"C:\Users\joyce\OneDrive\Bureau\Test IsonFIles\UserTest.json";
            User user = new User("Nathanods", "Kokine124");
            var result = dao.UpdateUserByAddingPizza(user);
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void TestDeleteMethod()
        {
            dao.ConnectionToJsonFile = @"C:\Users\joyce\OneDrive\Bureau\Test IsonFIles\UserTest.json";
            User user = new User("Nathanods", "Kokine124");
            Pizza pizza = new Pizza("Pepperoni" , "fsgrrfger" , 45 ,@"C:\ " );
            user.pizzas.Add(pizza);
            var result = dao.DeletePizzaFromPanel(user , pizza);
            Assert.AreEqual(true, result);
        }
        
        [TestMethod]
        public void TestVerificationOfFile()
        {
            dao.ConnectionToJsonFile = @"C:\Users\joyce\OneDrive\Bureau\Test IsonFIles\UserTest.json";
            Assert.IsTrue(File.Exists(dao.ConnectionToJsonFile));
        }
        [TestMethod]
        public void LoadDataFromFileTest()
        {
            dao.ConnectionToJsonFile = @"C:\Users\joyce\OneDrive\Bureau\Test IsonFIles\UserTest.json";
            dao.LoadDataFromJsonFile();
            Assert.IsNotNull(dao.accounts);
        }
    }
}
