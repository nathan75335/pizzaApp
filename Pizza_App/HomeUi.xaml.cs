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
    /// Логика взаимодействия для HomeUi.xaml
    /// </summary>
    public partial class HomeUi : Page
    {
        AdministratorDaoPizza pizzaDao = new AdministratorDaoPizza();
        UserDao userDao = new UserDao();
        private string UserId { get; set; }

        public HomeUi(string userId)
        {
            InitializeComponent();
            pizzaDao.LoadPizzaFromFile();
            PizzaMenu.DataContext = pizzaDao.pizzas;
            UserId = userId;
           
        }
       
        private void PizzaMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var pizza = PizzaMenu.SelectedItem as Pizza;
            if (CheckerUpdater.IsChecked == false)
            {   
                pizza.CreatedDate = DateTime.Now;
                var user = new User(UserId, null);
                user.pizzas.Add(pizza);
                bool test = userDao.UpdateUserByAddingPizza(user);
                if (test == true)
                    MessageBox.Show("Success", $"You Bougth {pizza.Name}");
            }else
            {
                var updateUI = new UpdateDescriptionUserUi(pizza);
                updateUI.Show();
            }
        }
    }
}
