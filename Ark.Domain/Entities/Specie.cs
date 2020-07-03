namespace Ark.Domain.Entities
{
    public class Specie
    {
        public Specie(string description)
        {
            Description = description;
        }

        public string Description { get; private set; }
    }
}