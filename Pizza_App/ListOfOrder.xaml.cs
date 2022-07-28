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
        OrderDao orderDao = new OrderDao();
        public ListOfOrder()
        {
            InitializeComponent();
            orderDao.LoadOrderFromFile();
            var orders = (from order in orderDao.orders
                        orderby order.TimeOfOrder
                        orderby order.pizza.Price
                        select order).ToList();

            DataGridListOfOrder.DataContext = orders;
        }
    }
}
