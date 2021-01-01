
using PizzaWorld.Domain.Abstracts;


namespace PizzaWorld.Domain.Models
{
    public class MeatPizza : APizzaModel
    {
        public MeatPizza()
        {
            Name = "MeatPizza";
        }
        protected override void AddCrust()
        {
            Crust = new Crusts("stuffed");
        }
        protected override void AddSize()
        {
            Size = new Sizes("Small", 10.99f);
        }

        PizzaToppings pizzaToppings = new PizzaToppings();
        
        protected override void AddToppings()
        {   
            pizzaToppings.toppings.Add(new Topping("Hem"));
            pizzaToppings.toppings.Add(new Topping("Onion"));
            pizzaToppings.toppings.Add(new Topping("Tomato"));
            pizzaToppings.toppings.Add(new Topping("Jalapeno"));

            Toppings = pizzaToppings;
        }
    }
}