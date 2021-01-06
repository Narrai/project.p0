using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaWorld.Domain.Abstracts
{
    public class PizzaToppings : AEntity
    {
        public APizzaModel Pizza { get; set; }
        public Toppings Topping { get; set; }

    }
}