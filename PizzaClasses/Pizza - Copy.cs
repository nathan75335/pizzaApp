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
        /// <summary>
        /// The Name of Pizza
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// the Description of the ingredients of the pizza
        /// </summary>
        public string DescriptionOfPizza { get; set; }
        /// <summary>
        /// the price of pizza
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// the link of the picture
        /// </summary>
        public string Picture { get; set; }
        /// <summary>
        /// the time when the user buy the pizza
        /// </summary>
        public DateTime CreatedDate { get; set; }

        [JsonConstructor]
        public Pizza(string name  , string descriptionOfPizza  , decimal price  , string picture )
        {
            Name = name;
            DescriptionOfPizza = descriptionOfPizza;
            Price = price;
            Picture = picture;
        }
        public Pizza()
        {

        }

    }
}
