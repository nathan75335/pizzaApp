using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaClasses
{
    public class AdministratorDaoPizza
    {
        public string Connection = @"C:\Users\NATHAN KALENGA\Desktop\Pizza.json";

        public List<Pizza> pizzas = null;
        
        public void LoadPizzaFromFile()
        {
            var list = new List<Pizza>();
            if (File.Exists(Connection) == true)
            {
                try
                {
                    list = JsonConvert.DeserializeObject<List<Pizza>>(File.ReadAllText(Connection));
                }
                catch (Exception e)
                {
                    throw e;
                }

                if (list != null)

                    pizzas = list;
                else
                    pizzas = new List<Pizza>();
            }
            else
                pizzas = new List<Pizza>();
        }

        public bool SaveToJsonFile()
        {
            var json = JsonConvert.SerializeObject(pizzas);

            File.WriteAllText(Connection, json);

            return true;
        }

        public bool AddNewPizzaToJsonFile(Pizza pizza  )
        {
            LoadPizzaFromFile();

            var testIfPizzaExist = GetPizza(pizza);

            if (testIfPizzaExist == null)
            {
                pizzas.Add(pizza);

                bool saveTest = SaveToJsonFile();

                if (saveTest != true)
                {
                    return false;
                }
                    
                return true;
            }
            return false;
        }

        public bool UpdatePizza(Pizza pizza)
        {
            LoadPizzaFromFile();

            if (pizzas == null)

                pizzas = new List<Pizza>();

            var testIfPizzaExist = (from pizzaUpdate in pizzas

                                   where pizzaUpdate.Name == pizza.Name

                                   select pizzaUpdate).FirstOrDefault();

            if (testIfPizzaExist != null)
            {
                testIfPizzaExist.DescriptionOfPizza = pizza.DescriptionOfPizza;

                testIfPizzaExist.Price = pizza.Price;

                testIfPizzaExist.Picture = pizza.Picture;

                bool save = SaveToJsonFile();

                if (save != true)

                    return false;

                return true;
                     
            }

            return false;      
        }

        public bool DeletePizzaFromTheCatalog(Pizza pizza)
        {
            LoadPizzaFromFile();

            if (pizzas == null)
                pizzas = new List<Pizza>();

            var testIfPizzaExist = GetPizza(pizza);

            if(testIfPizzaExist != null)
            {
                pizzas.RemoveAll(pizzaDeleted => pizzaDeleted.Name ==pizza.Name);

                bool save = SaveToJsonFile();

                if (save != true)

                    return false;

                return true;
            }

            return false;
        }

        public Pizza GetPizza(Pizza pizza)
        {
            var pizzaLooked = (from pizzaListed in pizzas

                              where pizzaListed.Name == pizza.Name

                              select pizzaListed ).FirstOrDefault();

            return pizzaLooked;
        }

       public bool UpdateDescritptionUser(string description , Pizza pizza)
       {
            LoadPizzaFromFile();

            if (pizzas == null)
                pizzas = new List<Pizza>();

            var testPizza = GetPizza(pizza);

            if(testPizza != null)
            {
                testPizza.DescriptionOfPizza +=  " "+description;

                bool saveTest = SaveToJsonFile();

                if (saveTest != true)
                    return false;

                return true;
            }
            return false;
       }
    }
}
