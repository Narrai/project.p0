using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PizzaWorld.Domain.Models;

namespace PizzaWorld.Domain.Abstracts
{
    public class APizzaModel : AEntity
    {

        public string OrderName { get; set; }
        public string  Name { get; set; }
        public string Crust { get; set; }
        public string Size { get; set; }
        public float Price { get; set; }
        public  string Topping { get; set;}

        public APizzaModel()
        {
            AddCrust();
            AddSize();
            AddTopping();
            AddPrice();
        }

        protected virtual void AddCrust(){}
        protected virtual void AddSize(){}
        protected virtual void AddTopping(){}
        protected virtual void AddPrice(){}

    }
}