using System.Collections.Generic;

namespace PizzaWorld.Domain.Abstracts
{
    public class Topping : AEntity
    {
        public string  Name { get; set; }
       public Topping(string name)
       {
           Name = name;
           
       }
    }
}