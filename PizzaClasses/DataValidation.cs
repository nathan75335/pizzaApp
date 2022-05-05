using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaClasses
{
    public class DataValidation
    {
        UserDao dao = new UserDao();
        AdministratorAccount admin = new AdministratorAccount();
        public bool VerificationUserAlreadyExist(User user )
        {
            dao.LoadDataFromJsonFile();

            var userPersonne = dao.GetUser(user);

            if (userPersonne != null)

                return true;

            else

                return false;
        }
        public bool VerificationOfLengthOfString(string userId , string passWord , Action<string> Notify)
        {
            if (userId == String.Empty)
            {
                Notify("You didn't Fill the UserId Field !\n Try Again");
                return false;
            }
            else if (passWord == String.Empty)
            {
                Notify("You didn't Fill the Password Field !\n Try Again");
                return false;
            }
            else if (userId == String.Empty && passWord == String.Empty)
            {
                Notify("Fill The Field !!!");
                return false;
            }
            else
                return true;


        }

        public bool VerificationAdministratorAccount(string userId, string passWord)
        {
            if (admin.UserId == userId && admin.PassWord == passWord)
                return true;
            else
                return false;

        }
    }
}
