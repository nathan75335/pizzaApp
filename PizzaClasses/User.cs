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
        public string UserId { get; set; }

        public string PassWord { get; set; }

        public List<Pizza> pizzas { get; set; } 

        public User(string userId, string password)
        {
            UserId = userId;
            PassWord = password;
            pizzas = new List<Pizza>();
        }
       
    }
}
