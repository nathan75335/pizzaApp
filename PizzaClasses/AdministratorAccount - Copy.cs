using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaClasses
{
    public class AdministratorAccount 
    {
        /// <summary>
        /// the id of the Administrator
        /// </summary>
        public string UserId { get; set; } = "Nathan_Musoko";
        /// <summary>
        /// the password of the administrator
        /// </summary>
        public string PassWord { get; set; }="Nathan_Musoko123";
        /// <summary>
        /// the list of user 
        /// </summary>
        public List<User> Users;
    }
}
