using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaClasses
{
    
    public class User
    {
        /// <summary>
        /// the id of the user 
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// the password of the user
        /// </summary>
        public string PassWord { get; set; }
        /// <summary>
        /// the list of pizza that the user has paid
        /// </summary>
        public List<IPizza> pizzas { get; set; } 
        /// <summary>
        /// constructor to initialise the user with his id and his password
        /// </summary>
        /// <param name="userId">id of the user</param>
        /// <param name="password">password of the user</param>
        public User(string userId, string password)
        {
            UserId = userId;
            PassWord = password;
            pizzas = new List<IPizza>();
        }
       
    }
}
