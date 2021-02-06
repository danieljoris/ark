namespace Ark.Domain.Entities
{
    public sealed class Specie
    {
        public string Description { get; private set; }

        public Specie(string description)
        {
            Description = description;
        }
    }
}