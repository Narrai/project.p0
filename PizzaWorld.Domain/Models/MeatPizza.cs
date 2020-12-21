using PizzaWorld.Domain.Abstracts;
using System.Collections.Generic;


namespace PizzaWorld.Domain.Models
{
    public class MeatPizza : APizzaModel
    {
        protected override void AddCrust()
        {
            Crust = "regular";
        }

        protected override void AddSize()
        {
            Size = "small";
        }

        protected override void AddToppings()
        {
            Toppings = new List<string>(){"cheese", "tomato", "mushroom"};
        }
    }
}