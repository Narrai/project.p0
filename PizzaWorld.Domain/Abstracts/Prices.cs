using System.ComponentModel.DataAnnotations;

namespace PizzaWorld.Domain.Abstracts
{
    public class Prices : AEntity
    {
        public float Price { get; set; }
    }
}