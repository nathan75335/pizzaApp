using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaClasses
{
    public class AdministratorDaoPizza : IAdministratorDaoPizza
    {
        /// <summary>
        /// the path to the pizza file json
        /// </summary>
        public string Connection { get; set; } = @"C:\Users\joyce\OneDrive\Bureau\CoursovaiaRabota\Pizza_App\Pizza.json";
        /// <summary>
        /// the list of pizza loaded from the file
        /// </summary>
        public List<IPizza> pizzas { get; set; } = null;
        /// <summary>
        /// load pizza from the file pizza.json
        /// </summary>
        public void LoadPizzaFromFile()
        {
            var list = new List<IPizza>();
            if (File.Exists(Connection) == true)
            {
                var settings = new JsonSerializerSettings
                {
                    Converters =
                    {
                        new AbstractConverter<Pizza ,IPizza>() ,
                        new AbstractConverter<PizzaWithComponent,IPizza>()
                    },
                };
                try
                {
                    list = JsonConvert.DeserializeObject<List<IPizza>>(File.ReadAllText(Connection) , settings);
                }
                catch (Exception e)
                {
                    throw e;
                }

                if (list != null)

                    pizzas = list;
                else
                    pizzas = new List<IPizza>();
            }
            else
                pizzas = new List<IPizza>();
        }

        public bool SaveToJsonFile() 
        {
            var settings = new JsonSerializerSettings
            {
                Converters =
                    {
                        new AbstractConverter<Pizza ,IPizza>() ,
                        new AbstractConverter<PizzaWithComponent,IPizza>()
                    },
            };
            var json = JsonConvert.SerializeObject(pizzas , settings);

            File.WriteAllText(Connection, json);

            return true;
        }
        /// <summary>
        /// Add a new pizza to the file if there is not such a pizza
        /// </summary>
        /// <param name="pizza">new pizza to be added</param>
        /// <returns>true if the pizza has been added or false in the other case</returns>
        public bool AddNewPizzaToJsonFile(IPizza pizza  )
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
        /// <summary>
        /// changing the price , the description or the picture of pizza
        /// </summary>
        /// <param name="pizza">the pizza to be updated</param>
        /// <returns>true if the pizza has been updated or false in the other case</returns>
        public bool UpdatePizza(IPizza pizza)
        {
            LoadPizzaFromFile();

            if (pizzas == null)

                pizzas = new List<IPizza>();

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
        /// <summary>
        /// Delete the pizza from the catalog of the pizza
        /// </summary>
        /// <param name="pizza">to pizza to be deleted</param>
        /// <returns>true if the pizza has been deleted or false in the other case</returns>
        public bool DeletePizzaFromTheCatalog(IPizza pizza)
        {
            LoadPizzaFromFile();

            if (pizzas == null)
                pizzas = new List<IPizza>();

            var testIfPizzaExist = GetPizza(pizza);

            if(testIfPizzaExist != null)
            {
                pizzas.Remove(testIfPizzaExist);

                bool save = SaveToJsonFile();

                if (save != true)

                    return false;

                return true;
            }

            return false;
        }
        /// <summary>
        /// Find the pizza by the name of the pizza
        /// </summary>
        /// <param name="pizza"></param>
        /// <returns></returns>
        public IPizza GetPizza(IPizza pizza)
        {
            var pizzaLooked = (from pizzaListed in pizzas

                              where pizzaListed.Name == pizza.Name

                              select pizzaListed ).FirstOrDefault();

            return pizzaLooked;
        }
       
    }
}
