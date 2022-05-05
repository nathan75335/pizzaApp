using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaClasses
{
    public interface IPizza
    {
        string Name { get; set; }

        string DescriptionOfPizza { get; set; }

        decimal Price { get; set; }

        string Picture { get; set; }

        DateTime CreatedDate { get; set; }
    }
}
