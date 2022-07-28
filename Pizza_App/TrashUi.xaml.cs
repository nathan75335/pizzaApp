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
        /// <summary>
        /// the object of the class userDao
        /// </summary>
        UserDao userDao = new UserDao();
        /// <summary>
        /// the userName of the user we don't need the password to search a user in the file
        /// </summary>
        string username;
        /// <summary>
        /// object of the class OrderDao
        /// </summary>
        OrderDao orderDao = new OrderDao(); 

        public TrashUi(string UserName)
        {
            InitializeComponent();
            username = UserName;
            userDao.LoadDataFromJsonFile();
            //finding the pizza that the user had added to the his trash
            var Pizza = (from person in userDao.accounts
                        where person.UserId == UserName
                        select person.pizzas).FirstOrDefault();

            DataGridDataTrash.DataContext = Pizza;
        }
        
        private void ButtonOrder_Click(object sender, RoutedEventArgs e)
        {
            var pizza = DataGridDataTrash.SelectedItem as IPizza;

            var order = new Order(username, pizza , DateTime.Now);

            MessageBoxResult result = MessageBox.Show("Do You Want To Buy This Pizza ??", "Pizza Home", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes && pizza != null)
            {
                var test = orderDao.InsertNewOrderToJsonFile(order);
                if (test == true)
                {
                    MessageBox.Show("You Successfully bought the Pizza");
                }
                else
                    MessageBox.Show("Couldn't Buy this Pizza ");

            } else
                MessageBox.Show("Oups....");
        }
    }
}
