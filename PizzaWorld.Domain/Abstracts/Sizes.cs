namespace PizzaWorld.Domain.Abstracts
{
    public class Sizes : AEntity
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public Sizes(string name, float price)
        {
            Name = name;
            Price = price;
        }
    }
}