namespace PizzaWorld.Domain.Abstracts
{
    public class Crusts : AEntity
    {
        public string Name { get; set; }

        public Crusts(string name)
        {
            Name = name;
        }
    }
}