using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaClasses
{
    public abstract class DecoratorPizza : IPizza
    {
        public string Name { get; set; }
        public string DescriptionOfPizza { get; set; }
        public decimal Price { get; set; }
        public string Picture { get; set; }

        protected readonly IPizza Pizza;

        public List<PizzaComponent> Components;

        public DecoratorPizza( IPizza pizza)
        {
            Name = pizza.Name;
            DescriptionOfPizza = pizza.DescriptionOfPizza;
            Price = pizza.Price;
            Picture = pizza.Picture;
            Pizza = pizza;
        }
    }
}
