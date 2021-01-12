using System.Collections.Generic;


namespace PizzaWorld.Domain.Abstracts
{
    public class Crusts : AEntity
    {
        public string Name { get; set; }
        public IList<APizzaModel> Pizzas { get; set; }
    }
}