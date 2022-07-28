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
    /// Логика взаимодействия для RedactComponent.xaml
    /// </summary>
    public partial class RedactComponentAdmin : Window
    {
        IPizzaDaoComponents components = FactoryMethods.GetPizzaDaoComponentsObject();
        PizzaComponent pizzaComponent { get; set; }
        public RedactComponentAdmin(PizzaComponent pizzaComponent)
        {
            InitializeComponent();

            this.pizzaComponent = pizzaComponent;

            TextBoxNameOfComponent.Text = pizzaComponent.Name;

            TextBoxPriceOfComponent.Text = pizzaComponent.Price.ToString();

            TextBoxWeightComponent.Text = pizzaComponent.Weigth.ToString();

        }
        public RedactComponentAdmin()
        {
            InitializeComponent();
        }

        private void ButtonNext_Click(object sender, RoutedEventArgs e)
        {
            var nameOfComponent = TextBoxNameOfComponent.Text;

            decimal priceOfComponent = 0;

            int weight = 0;

            try
            {
                priceOfComponent = Decimal.Parse(TextBoxPriceOfComponent.Text);

                weight = int.Parse(TextBoxWeightComponent.Text);

            }catch(Exception ex)
            {
                MessageBox.Show("Enter a decimal Number" + ex);
            }

            var component = new  PizzaComponent(nameOfComponent , priceOfComponent , weight);

            if (RadioButtonAdd.IsChecked == true)
            {
                var test = components.InsertANewIngredients(component);

                if (test == true)
                {
                    MessageBox.Show("The Component Has Successfully Been Added");
                }
                else
                    MessageBox.Show("An Error Happened When You Added The Component");
            }
            else if (RadioButtonRedact.IsChecked == true)
            {
                var test = components.UpdatePizzaComponentInFIle(component);

                if (test == true)
                {
                    MessageBox.Show("The Component Has Successfully Been Updated");

                }
                else
                    MessageBox.Show("An Error Happened When You Updated The Component");
            }
            else
                MessageBox.Show("Select Add or Redact !!!");
        }

        
    }
}
