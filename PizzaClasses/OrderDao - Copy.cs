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
        public List<Order> orders { get; set; }  = null;

        string connectionString = @"C:\Users\user\Desktop\CoursovaiaRabota\Pizza_App\Order.json";

        public void LoadOrderFromFile()
        {
            if (File.Exists(connectionString) == true)
            {
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

        public bool SaveToJsonFile()
        {
           
            var json = JsonConvert.SerializeObject(orders);

            File.WriteAllText(connectionString, json);

            return true;
            
        }
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
