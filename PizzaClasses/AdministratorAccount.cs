using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaClasses
{
    public class AdministratorAccount 
    {
        public string UserId { get; set; } = "Nathan_Musoko";

        public string PassWord { get; set; }="Nathan_Musoko123";

        public List<User> Users;
    }
}
