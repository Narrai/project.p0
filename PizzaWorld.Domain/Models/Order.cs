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

        public APizzaModel MakePizza(string userName, string PizzaType, string Curst, string Size, string Topping, float Price)
        {
            if(PizzaType.ToLower().Equals("meat pizza"))
            {
               return MakeMeatPizza(userName, PizzaType, Curst, Size, Topping, Price);
            }
            else if(PizzaType.ToLower().Equals("vege pizza"))
            {
                return MakeVegePizza(userName, PizzaType, Curst, Size, Topping, Price);
            }
            return null;
        }
        public MeatPizza MakeMeatPizza(string userName, string type, string crust, string size, string topping, float price)
        {
           MeatPizza meatPizza = _pizzaFactory.Make<MeatPizza>();
           meatPizza.Name = type;
           meatPizza.Crust = crust;
           meatPizza.Size = size;
           meatPizza.Topping = topping;
           meatPizza.Price = price;
           meatPizza.OrderName = userName;
           return meatPizza;
        }


        public VegePizza MakeVegePizza(string userName, string type, string crust, string size, string topping, float price)
        {
           VegePizza vegePizza =  _pizzaFactory.Make<VegePizza>();
           vegePizza.Name = type;
           vegePizza.Crust = crust;
           vegePizza.Size = size;
           vegePizza.Topping = topping;
           vegePizza.Price = price;
           vegePizza.OrderName = userName;
           return vegePizza;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}