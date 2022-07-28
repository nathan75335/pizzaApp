using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaClasses
{
    public class FactoryMethods
    {
        public static  IAdministratorDaoPizza GetAdministratorDaoObject()
        {
            return new AdministratorDaoPizza();
        }
        
        public static IUserDao GetUserDaoObject()
        {
            return new UserDao();
        }

        public static IPizzaDaoComponents GetPizzaDaoComponentsObject()
        {
            return new PizzaDaoComponents();
        }
        public static IPizza GetPizzaObject()
        {
            return new Pizza();
        }
    }
}
