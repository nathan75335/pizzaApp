using System.Collections.Generic;

namespace PizzaClasses
{
    public interface IUserDao
    {
        string ConnectionToJsonFile { get; }

        bool DeletePizzaFromPanel(User user, IPizza pizzaToBeRemoved);
        User GetUser(User user);
        User GetUserById(User user);
        bool InsertToJsonFile(User user);
        void LoadDataFromJsonFile();
        bool SaveToJsonFile();
        bool UpdateUserByAddingPizza(User user);
        List<User> accounts { get; set; }
    }
}