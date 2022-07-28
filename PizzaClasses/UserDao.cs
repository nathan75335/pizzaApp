using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace PizzaClasses
{
    public class UserDao : IUserDao
    {
        /// <summary>
        /// link to json file user.json
        /// </summary>
        public string ConnectionToJsonFile { get; set;} = @"C:\Users\joyce\OneDrive\Bureau\CoursovaiaRabota\Pizza_App\User.json";
        /// <summary>
        /// list of user with the pizza that they bought
        /// </summary>
        public List<User> accounts { get; set; } = null;
        /// <summary>
        /// read and put user accounts into the list accounts
        /// </summary>
        public void LoadDataFromJsonFile()
        {

            if (File.Exists(ConnectionToJsonFile) == true)
            {
                var settings = new JsonSerializerSettings
                {
                    Converters =
                    {
                        new AbstractConverter<Pizza , IPizza>() ,
                        new AbstractConverter<PizzaWithComponent, IPizza>()
                    },
                };
                var list = JsonConvert.DeserializeObject<List<User>>( File.ReadAllText(ConnectionToJsonFile) ,settings);

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
        /// <summary>
        /// function to save data to the jsonfile user
        /// </summary>
        /// <returns></returns>
        public bool SaveToJsonFile()
        {
            var json = JsonConvert.SerializeObject(accounts);

            File.WriteAllText(ConnectionToJsonFile, json);

            return true;
        }
        /// <summary>
        /// add a user to json file , verify first if the user Exist 
        /// </summary>
        /// <param name="user">the user to be added</param>
        /// <returns>true if the user has been added or false in the other case</returns>
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
         /// <summary>
         /// update a user by adding pizza to his list of pizza
         /// </summary>
         /// <param name="user">the user to be updated</param>
         /// <returns>return true if the user has been updated or false in the other case</returns>
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
        /// <summary>
        /// delete pizza from a list of a certain user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pizzaToBeRemoved"></param>
        /// <returns> true if the user has been deleted or false in the other case</returns>
        public bool DeletePizzaFromPanel(User user,IPizza pizzaToBeRemoved )
        {
            LoadDataFromJsonFile();

            if (accounts == null)

                accounts = new List<User>();

            var testIfUserExist = GetUserById(user);

            if(testIfUserExist != null)
            {
                testIfUserExist.pizzas.Remove( pizzaToBeRemoved);

                bool saveTest = SaveToJsonFile();

                if (saveTest != true)
                {
                    return false;
                }

                return true;
            }

            return false;
        }
        /// <summary>
        /// find the user by his id
        /// </summary>
        /// <param name="user">the user that we want to seek</param>
        /// <returns> the user or null if there is not such a user</returns>
        public User GetUserById(User user)
        {
            var userLooKed = (from userInList in accounts

                              where userInList.UserId == user.UserId

                              select userInList).FirstOrDefault();

            return userLooKed;
        }
        /// <summary>
        /// Find the user by his id and his password function that will help after for the data validation
        /// </summary>
        /// <param name="user">the looked user</param>
        /// <returns>the user if there is such a user of null if there is not</returns>
        public User GetUser(User user)
        {
            var userLooKed = (from userInList in accounts

                              where userInList.UserId == user.UserId && userInList.PassWord ==user.PassWord

                              select userInList).FirstOrDefault();

            return userLooKed;
        }
    }
  
}
