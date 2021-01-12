using System.Collections.Generic;

namespace PizzaWorld.Domain.Abstracts
{
    public class Sizes : AEntity
    {
        public string Name { get; set; }

        public Prices Price { get; set; }
        public List<APizzaModel> Pizzas { get; set; }
    }
}