using contossoPizza.Models;

namespace contossoPizza.Services;

public static class PizzaService
{
    static List<Pizza> Pizzas {get;}
    static int nextId {get; set;}
    static PizzaService() 
    {
        Pizzas = new List<Pizza>
        {
            new Pizza { Id = 1, Name = "Classic Italian", IsGlutenFree = false },
            new Pizza { Id = 2, Name = "Veggie", IsGlutenFree = true }
        };
        nextId = 3;
    }

    public static List<Pizza> GetAll() =>  Pizzas;

    public static Pizza? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);
    public static void Add(Pizza pizza) 
    {
        pizza.Id = nextId++;
        Pizzas.Add(pizza);
    }
    public static void Delete(int id)
    {
        var pizza = Get(id);
        if (pizza is null) 
            return;
        Pizzas.Remove(pizza);
    }
    public static void Update(int id, Pizza pizza) {
        var index = Pizzas.FindIndex(p => p.Id == id);
        if (index == -1)
            return;

        Pizzas[index] = pizza;
    }

}