using PizzaClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pizza_App
{
    /// <summary>
    /// Логика взаимодействия для TrashUi.xaml
    /// </summary>
    public partial class TrashUi : Page
    {
        UserDao userDao = new UserDao();
        string username;
        public TrashUi(string UserName)
        {
            InitializeComponent();
            username = UserName;
            userDao.LoadDataFromJsonFile();
            var Pizza = (from person in userDao.accounts
                        where person.UserId == UserName
                        select person.pizzas).FirstOrDefault();
            var PizzaOrdered = from pizza in Pizza
                               orderby pizza.CreatedDate.Day orderby pizza.CreatedDate.Hour orderby pizza.CreatedDate.Minute
                               select pizza;
            DataGridDataTrash.DataContext = PizzaOrdered;
        }
    }
}
