namespace PizzaStore.DB;

public record Pizza
{
    public int Id { get; set; }
    public string? Name { get; set; }
}

public class PizzaDB
{
    private static List<Pizza> _pizzas = new()
    {
        new() { Id=1, Name="Cheese" },
        new() { Id=2, Name="Pepperoni" },
        new() { Id=3, Name="Pineapple extravaganza" }
    };

    public static List<Pizza> GetPizzas() => _pizzas;

    public static Pizza? GetPizza(int id) =>
        _pizzas.SingleOrDefault(pizza => pizza.Id == id);

    public static Pizza CreatePizza(Pizza pizza)
    {
        _pizzas.Add(pizza);
        return pizza;
    }

    public static Pizza UpdatePizza(Pizza update)
    {
        _pizzas = _pizzas.Select(pizza =>
        {
            if (pizza.Id == update.Id)
            {
                pizza.Name = update.Name;
            }
            return pizza;
        }).ToList();
        return update;
    }

    public static void RemovePizza(int id) =>
        _pizzas = _pizzas.FindAll(pizza => pizza.Id != id).ToList();
}
