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
        IAdministratorDaoPizza pizzaDao = FactoryMethods.GetAdministratorDaoObject();
        IUserDao userDao = FactoryMethods.GetUserDaoObject();
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
            var pizza = PizzaMenu.SelectedItem as IPizza;

            MessageBoxResult result = MessageBox.Show("Do You Want To Add this Pizza To The Trash ? " , "Pizza Buy" , MessageBoxButton.YesNo);

            switch (result)
            {
                case MessageBoxResult.No:
                    MessageBox.Show("Oups ....", "Pizza Buy");
                    break;
                case MessageBoxResult.Yes:
                    MessageBoxResult resultAddIng = MessageBox.Show("Do You Want Add Ingredients ?", "Pizza Buy", MessageBoxButton.YesNo);
                    switch (resultAddIng)
                    {
                        case MessageBoxResult.Yes:
                            //Ajouter le user
                            var updateDescriptionUser = new UpdateDescriptionUserUi(new User(UserId , null) , pizza);

                            updateDescriptionUser.Show();

                            break;

                        case MessageBoxResult.No:

                            var user = new User(UserId, null); 

                            user.pizzas.Add(pizza);

                            var test = userDao.UpdateUserByAddingPizza(user);

                            if (test == true)
                            {
                                MessageBox.Show("Successfully Added");
                                userDao.DeletePizzaFromPanel(user, pizza);
                                var window = Application.Current.MainWindow as MainWindow;
                                window.MainFrame.Refresh();
                            }

                            else

                                MessageBox.Show("Oups This Couldn't be Added to Your Trash !!!");

                            break;

                    }
                    break;
            }
        }
    }
}
