using System.Collections.Generic;
using PizzaWorld.Domain.Abstracts;
using PizzaWorld.Domain.Factories;

namespace PizzaWorld.Domain.Models
{
    public class Order : AEntity
    {
        public static string  OrderName { get; set; }
        public List<APizzaModel> Pizzas { get; set; }

        private GenericPizzaFactory _pizzaFactory = new GenericPizzaFactory();

        int count = 0;
        public Order()
        {
            OrderName = "Order " + count++.ToString();
            Pizzas = new List<APizzaModel>();
        }
        public void MakeMeatPizza()
        {
            Pizzas.Add(_pizzaFactory.Make<MeatPizza>());
        }
    }
}