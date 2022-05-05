using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace PizzaClasses
{
    public class UserDao
    {
        public string ConnectionToJsonFile { get; } = @"C:\Users\NATHAN KALENGA\Desktop\User.json";

        public List<User> accounts = null;

        public void LoadDataFromJsonFile()
        {

            if (File.Exists(ConnectionToJsonFile) == true)
            {
                var list = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(ConnectionToJsonFile));

                if (list != null)

                    accounts = list;

                else

                    accounts = new List<User>();

            }
            else
            {
                accounts = new List<User>();
            }
        }

        public bool SaveToJsonFile()
        {
            var json = JsonConvert.SerializeObject(accounts);

            File.WriteAllText(ConnectionToJsonFile, json);

            return true;
        }

        public bool InsertToJsonFile(User user )
        {
            LoadDataFromJsonFile();

            if (accounts == null)

                accounts = new List<User>();

            var test = GetUserById(user);

            if (test == null)
            {
                accounts.Add(user);

                bool saveTest = SaveToJsonFile();

                if (saveTest != true)
                {
                    return (false);
                }
                
                return (true);
            }
            return (false);
        }

        public  bool UpdateUserByAddingPizza(User user )
        {
            LoadDataFromJsonFile();

            if (accounts == null)

                accounts = new List<User>();

            var test = accounts.Where(userPerson => userPerson.UserId == user.UserId).FirstOrDefault();
            
            if (test != null)
            {
                test.pizzas.AddRange(user.pizzas);
                //test.AddAPizzaToTheTrash(user);
                bool rv = SaveToJsonFile();
                if (rv != true)
                    return false;
                return true;    
            }
           
            return false;
        }

        public bool DeletePizzaFromPanel(User user,List<Pizza> pizzaToBeRemoved )
        {
            LoadDataFromJsonFile();

            if (accounts == null)

                accounts = new List<User>();

            var testIfUserExist = GetUserById(user);

            if(testIfUserExist != null)
            {
                foreach (var pizza in pizzaToBeRemoved)

                    testIfUserExist.pizzas.RemoveAll(pizzaDeleted =>pizzaDeleted.Name== pizza.Name);

                bool saveTest = SaveToJsonFile();

                if (saveTest != true)
                {
                    return false;
                }

                return true;
            }

            return false;
        }
        
        public User GetUserById(User user)
        {
            var userLooKed = (from userInList in accounts

                              where userInList.UserId == user.UserId

                              select userInList).FirstOrDefault();

            return userLooKed;
        }

        public User GetUser(User user)
        {
            var userLooKed = (from userInList in accounts

                              where userInList.UserId == user.UserId && userInList.PassWord ==user.PassWord

                              select userInList).FirstOrDefault();

            return userLooKed;
        }
    }
  
}
