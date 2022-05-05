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
using System.Windows.Shapes;

namespace Pizza_App
{
    /// <summary>
    /// Логика взаимодействия для UpdateDescriptionUserUi.xaml
    /// </summary>
    public partial class UpdateDescriptionUserUi : Window
    {
        Pizza userPizza { get; set; }
        AdministratorDaoPizza admin = new AdministratorDaoPizza();
        public UpdateDescriptionUserUi(Pizza pizza)
        {
            InitializeComponent();
            userPizza = pizza;
        }

        private void ButtonNext_Click(object sender, RoutedEventArgs e)
        {
            bool test = admin.UpdateDescritptionUser(TextBoxUpdateDescription.Text, userPizza);
            if (test == true)
            {
                MessageBox.Show("Success", "Your Description Has Been added");
                this.Close();
            }
            else
                MessageBox.Show("Failed !");
        }
    }
}
