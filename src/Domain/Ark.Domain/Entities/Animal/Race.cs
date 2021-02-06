using Ark.Core.Entities;

namespace Ark.Domain.Entities
{
    public sealed class Race : Entity
    {
        public string Description { get; private set; }
        public Specie Specie { get; private set; }

        public Race(string description, Specie specie)
        {
            this.Description = description;
            this.Specie = specie;
        }
    }
}