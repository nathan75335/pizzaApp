using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PizzaClasses
{
    public class OrderDao
    {
        /// <summary>
        /// The list of orders
        /// </summary>
        public List<Order> orders { get; set; }  = null;
        /// <summary>
        /// the path to json file
        /// </summary>
        public string connectionString = @"C:\Users\joyce\OneDrive\Bureau\CoursovaiaRabota\Pizza_App\Order.json";
        /// <summary>
        /// function tha load data in the list from the json file
        /// </summary>
        public void LoadOrderFromFile()
        {
            if (File.Exists(connectionString) == true)
            {
                // adding the settings so that the jsonconverteer class could be able to deserialize all the class that inherited from the interface IPizza
                var settings = new JsonSerializerSettings
                {
                    Converters =
                    {
                        new AbstractConverter<Pizza , IPizza>() ,
                        new AbstractConverter<PizzaWithComponent, IPizza>()
                    },
                };
                var list = JsonConvert.DeserializeObject<List<Order>>(File.ReadAllText(connectionString), settings);

                if (list != null)

                    orders = list;

                else

                    orders = new List<Order>();

            }
            else
            {
                orders = new List<Order>();
            }
        }
        /// <summary>
        /// function to save  data to json file 
        /// </summary>
        /// <returns></returns>
        public bool SaveToJsonFile()
        {

            var json = JsonConvert.SerializeObject(orders);

            File.WriteAllText(connectionString, json);

            return true;
            
        }
        /// <summary>
        /// function to add new order in the json file
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public  bool InsertNewOrderToJsonFile(Order order)
        {
            LoadOrderFromFile();

            if (orders == null)

                orders = new List<Order>();

            
            orders.Add(order);

            bool saveTest = SaveToJsonFile();

            if(saveTest != true)
            {
                 return (false);
            }

            return (true);
            
        }
    }
}
