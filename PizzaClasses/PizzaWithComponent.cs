using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaClasses
{
    public class PizzaWithComponent : DecoratorPizza
    {
        public PizzaWithComponent(IPizza pizza , List<PizzaComponent> components) : base(pizza)
        {
           this.Components = components;

            this.Price = pizza.Price + (from compo in Components
                                       select compo.Price).Sum();
        }


        //public PizzaWithComponent(IPizza pizza , List<PizzaComponent> Components) : base(pizza)
        //{
        //    this.Components = Components;
        //    this.Price = (from component in Components
        //                  select component.Price).Sum();
        //}
    }
}
