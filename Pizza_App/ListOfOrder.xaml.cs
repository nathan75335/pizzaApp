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
    /// Логика взаимодействия для ListOfOrder.xaml
    /// </summary>
    public partial class ListOfOrder : Page
    {
        UserDao adminDao = new UserDao();
        public ListOfOrder()
        {
            InitializeComponent();
            adminDao.LoadDataFromJsonFile();
            var users = (from user in adminDao.accounts
                        from pizza in user.pizzas
                        orderby pizza.CreatedDate.Date 
                        orderby pizza.Price
                        select pizza).ToList();

            /*var pizzas = (from user in users
                         select user.pizzas).ToList();*/
                         
            DataGridListOfOrder.ItemsSource = users;
        }
    }
}
