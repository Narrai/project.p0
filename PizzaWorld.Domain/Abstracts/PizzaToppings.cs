using System.Collections.Generic;

namespace PizzaWorld.Domain.Abstracts
{
    public class PizzaToppings : AEntity
    {
        public ICollection<Topping> toppings { get; set; }
        public PizzaToppings()
        {
            toppings = new List<Topping>();
        }
    }
}