using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PizzaClasses
{
    public class Pizza : IPizza
    {
        public string Name { get; set; }

        public string DescriptionOfPizza { get; set; }

        public decimal Price { get; set; }

        public string Picture { get; set; }

        public DateTime CreatedDate { get; set; }

        public Pizza(string name, string descriptionOfPizza, decimal price, string picture , DateTime createdDate)
        {
            Name = name;
            DescriptionOfPizza = descriptionOfPizza;
            Price = price;
            Picture = picture;
            CreatedDate = createdDate;
        }

        [JsonConstructor]
        public Pizza(string name  , string descriptionOfPizza  , decimal price  , string picture )
        {
            Name = name;
            DescriptionOfPizza = descriptionOfPizza;
            Price = price;
            Picture = picture;
        }

    }
}
