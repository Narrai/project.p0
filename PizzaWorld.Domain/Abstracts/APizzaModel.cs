using System.Collections.Generic;



namespace PizzaWorld.Domain.Abstracts
{
    public class APizzaModel : AEntity
    {
        public string  Name { get; set; }
        public Crusts Crust { get; set; }
        public Sizes Size { get; set; }
        public PizzaToppings Toppings { get; set;}

        public APizzaModel()
        {
            AddCrust();
            AddSize();
            AddToppings();
        }

        protected virtual void AddCrust(){}
        protected virtual void AddSize(){}
        protected virtual void AddToppings(){}

    }
}