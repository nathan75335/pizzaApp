using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PizzaClasses
{
    public class PizzaDaoComponents : IPizzaDaoComponents
    {
        public List<PizzaComponent> pizzaComponents { get; set; } = null;

        public string conncetionToJsonFile { get; set; } = @"C:\Users\joyce\OneDrive\Bureau\CoursovaiaRabota\Pizza_App\PizzaComponent.json";

        public void LoadDataFromFile()
        {
            if(File.Exists(conncetionToJsonFile))
            {
                var list = JsonConvert.DeserializeObject<List<PizzaComponent>>(File.ReadAllText(conncetionToJsonFile));

                if (list == null)
                {
                    pizzaComponents = new List<PizzaComponent>();
                }else
                {
                    pizzaComponents = list;
                }
            }
        }
        public bool SaveToJSonFile()
        {
            var json = JsonConvert.SerializeObject(pizzaComponents);

            File.WriteAllText(conncetionToJsonFile, json);

            return true;
        }
        public bool InsertANewIngredients(PizzaComponent pizzaComponent)
        {
            LoadDataFromFile();

            if (pizzaComponents == null)

                pizzaComponents = new List<PizzaComponent>();
            
            var test  = (from pizzaCompo in pizzaComponents
                        where pizzaCompo.Name ==  pizzaComponent.Name
                        select pizzaCompo).FirstOrDefault();
            if(test == null)
            {
                pizzaComponents.Add(pizzaComponent);
                var saveTest = SaveToJSonFile();
                if (saveTest == true)
                    return true;
                return false;
            }
            return false;
        }

        public bool UpdatePizzaComponentInFIle(PizzaComponent pizzaComponent)
        {
            LoadDataFromFile();

            if (pizzaComponents == null)

                pizzaComponents = new List<PizzaComponent>();

            var test = (from pizzaCompo in pizzaComponents
                        where pizzaCompo.Name == pizzaComponent.Name
                        select pizzaCompo).FirstOrDefault();
            if (test != null)
            {
                test.Price = pizzaComponent.Price;

                test.Weigth = pizzaComponent.Weigth;

                var saveTest = SaveToJSonFile();

                if (saveTest == true)

                    return true;

                return false;
            }
            return false;
        }

        public bool DeletePizzaComponentFromFile(PizzaComponent pizzaComponent)
        {
            LoadDataFromFile();

            if (pizzaComponents == null)

                pizzaComponents = new List<PizzaComponent>();

            var test = (from pizzaCompo in pizzaComponents
                        where pizzaCompo.Name == pizzaComponent.Name
                        select pizzaCompo).FirstOrDefault();
            if (test != null)
            {
                pizzaComponents.Remove(pizzaComponent); 

                var saveTest = SaveToJSonFile();

                if (saveTest == true)

                    return true;

                return false;
            }
            return false;
        }
    }
}
