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
        /// <summary>
        /// list of components read from the file PizzaComponent that will be shown so that the user can choose
        /// </summary>
        public List<PizzaComponent> ComponentsOne { get; set; }
        /// <summary>
        /// the pizza passed by the constructor from the HomeUi interface
        /// </summary>
        IPizza userPizza { get; set; }
        /// <summary>
        /// the user passed by the constuctor from the HOmeUi interface
        /// </summary>
        User UserOne { get; set; }
        /// <summary>
        /// the object from the class Dao that will be user to update the user in the json file
        /// </summary>
        IUserDao dao = FactoryMethods.GetUserDaoObject();

        IPizzaDaoComponents pizzaDaoComponent = FactoryMethods.GetPizzaDaoComponentsObject();

        List<PizzaComponent> Components = new List<PizzaComponent>();
        public UpdateDescriptionUserUi(User user , IPizza pizza)
        {
            InitializeComponent();

            userPizza = pizza;

            UserOne = user;

            pizzaDaoComponent.LoadDataFromFile();

            ComponentsOne = pizzaDaoComponent.pizzaComponents;

            ComboBoxComponentPizza.DataContext = this;
        }

        private void ButtonNext_Click(object sender, RoutedEventArgs e)
        {
            var priceComponent = (from compo in Components
                                  select compo.Price).Sum();
            if (Components.Count != 0)
            {
                //calculating the price of the ingredients the will be shown to the user
                var pizzaWithComponents = new PizzaWithComponent( userPizza, Components);

                //pizzaWithComponents.Price = userPizza.Price + pizzaWithComponents.Price;

                //pizzaWithComponents.Name = userPizza.Name;

                //pizzaWithComponents.Picture = userPizza.Picture;

                //pizzaWithComponents.DescriptionOfPizza = userPizza.DescriptionOfPizza; 

                //pizzaWithComponents.CreatedDate = DateTime.Now; 

                //Pizza pizza = new PizzaWithComponent(userPizza, Components);
                //var user = new User("dsfdsf", "sfgsdf");

                //user.pizzas.Add(pizzaWithComponents);

                //dao.InsertToJsonFile(user);

                UserOne.pizzas.Add(pizzaWithComponents);

                MessageBoxResult result =MessageBox.Show($"The Components cost {priceComponent} , The new Price of The Pizza is {pizzaWithComponents.Price} $ ","MyHouse Pizza" , MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    dao.UpdateUserByAddingPizza(UserOne);
                    MessageBox.Show("You Added the Pizza");
                    this.Close();
                }
                else
                    MessageBox.Show("OUps ....");

                
            }
            else
                MessageBox.Show("Choose At Least One Component");


        }

        private void ButtonAddNewComponent_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxComponentPizza.SelectedItem != null)
            {
                var component = ComboBoxComponentPizza.SelectedItem as PizzaComponent;

                Components.Add(component);

                ComboBoxComponentPizza.SelectedItem = null;
            }
            else
                MessageBox.Show("Choose An Ingredient");
        }
    }
}
