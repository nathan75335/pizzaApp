
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaClasses
{
    public class Order
    {
        public string UserId { get; set; }
        public IPizza pizza { get; set; }
        
        public DateTime TimeOfOrder { get; set; }
        public Order (string userId , IPizza pizza , DateTime  timeOfOrder)
        {
            UserId = userId;

            this.pizza = pizza;

            TimeOfOrder = timeOfOrder;
        }

    }
}
