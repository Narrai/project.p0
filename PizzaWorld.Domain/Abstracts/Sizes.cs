using System.ComponentModel.DataAnnotations;

namespace PizzaWorld.Domain.Abstracts
{
    public class Sizes : AEntity
    {
        public string Name { get; set; }
    }
}