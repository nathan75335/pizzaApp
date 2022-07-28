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
        /// <summary>
        /// verify if there is such a user in the json file
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool VerificationUserAlreadyExist(User user )
        {
            dao.LoadDataFromJsonFile();

            var userPersonne = dao.GetUser(user);

            if (userPersonne != null)

                return true;

            else

                return false;
        }
        /// <summary>
        /// For the field of the form,help to verify that the user entered some values in the field
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="passWord"></param>
        /// <param name="Notify">delegate that will show message to the screen</param>
        /// <returns></returns>
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
        /// <summary>
        /// verify the data for the acccount of the administrator
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public bool VerificationAdministratorAccount(string userId, string passWord)
        {
            if (admin.UserId == userId && admin.PassWord == passWord)
                return true;
            else
                return false;

        }
    }
}
