using System.Collections.Generic;
namespace PizzaClasses
{
    public interface IAdministratorDaoPizza
    {
        bool AddNewPizzaToJsonFile(IPizza pizza);
        bool DeletePizzaFromTheCatalog(IPizza pizza);
        IPizza GetPizza(IPizza pizza);
        void LoadPizzaFromFile();
        bool SaveToJsonFile();
        bool UpdatePizza(IPizza pizza);
        List<IPizza> pizzas { get; set; }
    }
}