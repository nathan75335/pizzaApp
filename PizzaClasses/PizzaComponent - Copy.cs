using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaClasses
{
    public class PizzaComponent
    {
        public PizzaComponent(string name, decimal price, double weigth)
        {
            Name = name;
            Price = price;
            Weigth = weigth;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public double Weigth { get; set; }
    }
}
