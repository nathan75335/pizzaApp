using System.Collections.Generic;
namespace PizzaClasses
{
    public interface IPizzaDaoComponents
    {
        bool DeletePizzaComponentFromFile(PizzaComponent pizzaComponent);
        bool InsertANewIngredients(PizzaComponent pizzaComponent);
        void LoadDataFromFile();
        bool SaveToJSonFile();
        bool UpdatePizzaComponentInFIle(PizzaComponent pizzaComponent);
        List<PizzaComponent> pizzaComponents { get; set; }
    }
}