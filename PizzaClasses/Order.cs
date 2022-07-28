
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaClasses
{
    public class Order
    {
        /// <summary>
        /// the Identificator of the user
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// the Pizza that the user wants to buy
        /// </summary>
        public IPizza pizza { get; set; }
        /// <summary>
        /// the time of the order
        /// </summary>
        public DateTime TimeOfOrder { get; set; }
        public Order (string userId , IPizza pizza , DateTime  timeOfOrder)
        {
            UserId = userId;

            this.pizza = pizza;

            TimeOfOrder = timeOfOrder;
        }

    }
}
