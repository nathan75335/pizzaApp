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
    /// Логика взаимодействия для RedactPizzaComponent.xaml
    /// </summary>
    public partial class RedactPizzaComponent : Page
    {
        IPizzaDaoComponents dao = FactoryMethods.GetPizzaDaoComponentsObject();
        public RedactPizzaComponent()
        {
            InitializeComponent();

            dao.LoadDataFromFile();

            ComboBoxReadactAdmin.ItemsSource = dao.pizzaComponents;
        }

        private void ButtonAddComponent_Click(object sender, RoutedEventArgs e)
        {
            var redactComponent = new RedactComponentAdmin(); 

            redactComponent.Show();
        }

        private void ButtonDeletePizzaComponent_Click(object sender, RoutedEventArgs e)
        {
            if(ComboBoxReadactAdmin.SelectedItem != null)
            {
                var Component = ComboBoxReadactAdmin.SelectedItem as PizzaComponent ;

                var test  = dao.DeletePizzaComponentFromFile(Component);

                if (test == true)
                {
                    MessageBox.Show("Successfully Deleted");
                }
                else
                    MessageBox.Show("An Error Happened When You Deleted The Component");
            }
        }

        private void ButtonRedactPizzaComponent_Click(object sender, RoutedEventArgs e)
        {
            var Component = ComboBoxReadactAdmin.SelectedItem as PizzaComponent;

            var windowRedact = new RedactComponentAdmin(Component);

            windowRedact.Show();
        }
    }
}
