using Microsoft.Win32;
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
    /// Логика взаимодействия для RedactPizza.xaml
    /// </summary>
    public partial class RedactPizza : Window
    {
        AdministratorDaoPizza Admin = new AdministratorDaoPizza();
        public RedactPizza(Pizza pizza)
        {
            InitializeComponent();
            TextBoxNameOfPizza.Text = pizza.Name;
            TextBoxDescriptionOfPizza.Text = pizza.DescriptionOfPizza;
            TextBoxPrice.Text = pizza.Price.ToString();
            TextBoxPicture.Text = pizza.Picture;
        }

        private void ButtonNext_Click(object sender, RoutedEventArgs e)
        {
            var name = TextBoxNameOfPizza.Text;
            var description = TextBoxDescriptionOfPizza.Text;
            decimal price = 0;
            try
            {
                price = Convert.ToDecimal(TextBoxPrice.Text);
            }
            catch (Exception exp)
            {
                MessageBox.Show("Enter the rigth Number" +exp);
            }
            var picture = TextBoxPicture.Text;

            var pizza = new Pizza(name, description, price, picture);

            if (RadioButtonDelete.IsChecked == true)
            {
                bool testIfDeleted = Admin.DeletePizzaFromTheCatalog(pizza);

                if (testIfDeleted == true)
                    MessageBox.Show($"The Pizza {pizza.Name} Has Successfully Been Deleted.");
                else
                    MessageBox.Show($"The Pizza {pizza.Name} Has Not Been Deleted");
            }
            else if (RadioButtonRedact.IsChecked == true)
            {
                bool testIfUpdated = Admin.UpdatePizza(pizza);

                if (testIfUpdated == true)
                    MessageBox.Show($"The Pizza {pizza.Name} Has Successfully Been Updated.");
                else
                    MessageBox.Show($"The Pizza {pizza.Name} Has Not Been Updated");
            }else if(RadioButtonAdd.IsChecked == true)
            {
                bool testIfAdded = Admin.AddNewPizzaToJsonFile(pizza);

                if (testIfAdded == true)
                {
                    MessageBox.Show($"The Pizza {pizza.Name} Has Successfully Been Updated.");
                    this.Close();
                }
                else
                    MessageBox.Show($"The Pizza {pizza.Name} Has Not Been Updated");
            }
        }

        private void ButtonAddLink_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new  OpenFileDialog();

            dialog.Title = "Open Image";

            dialog.Filter = "Image Files (*.jpg;*.png)|*.JPG;*.PNG"; 

            Nullable <bool> result = dialog.ShowDialog();

            if (result == true)
            {
                TextBoxPicture.Text = dialog.FileName;
            }
            else
                TextBoxPicture.Text = "";

        }
    }
}
