using System.Collections.Generic;
using PizzaWorld.Domain.Abstracts;
using PizzaWorld.Domain.Factories;
using System;

namespace PizzaWorld.Domain.Models
{
    public class Order : AEntity
    {
        public string StoreName { get; set; }  // to print orderlist by store

        public float TotalPrice { get; set; } // 

        public DateTime OrderDate { get; set; }

        public string Name { get; set; } // to print pizzaList by order
        public List<APizzaModel> Pizzas { get; set; }

        private GenericPizzaFactory _pizzaFactory = new GenericPizzaFactory();

        public Order()
        {
            Pizzas = new List<APizzaModel>();
        }

        public APizzaModel MakePizza(string userName, string PizzaType, string Curst, string Size, float Price)
        {
            return Pizza(userName, PizzaType, Curst, Size, Price);
        }
        
        public Pizza Pizza(string userName, string type, string crust, string size, float price)
        {
           Pizza pizza = _pizzaFactory.Make<Pizza>();
           pizza.Name = type;
           pizza.Crust = crust;
           pizza.Size = size;
           pizza.Price = price;
           pizza.OrderName = userName;
           return pizza;
        }


        public override string ToString()
        {
            return $"{Name}";
        }
    }
}