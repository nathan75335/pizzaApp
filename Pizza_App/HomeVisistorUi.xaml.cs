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
    /// Логика взаимодействия для HomeVisistorUi.xaml
    /// </summary>
    public partial class HomeVisistorUi : Page
    {
        AdministratorDaoPizza pizzaDao = new AdministratorDaoPizza();
        public HomeVisistorUi()
        {
            InitializeComponent();
            pizzaDao.LoadPizzaFromFile();
            PizzaMenu.DataContext = pizzaDao.pizzas;
        }

        private void PizzaMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("Register First !!!");
        }
    }
}
