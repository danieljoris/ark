using System;

namespace Ark.Domain.Entities
{
    public class Animal
    {
        public string Name { get; private set; }
        public Specie Specie { get; private set; }
        public Race Race { get; private set; }
        public DateTime Birthday { get; private set; }
        public string ApproximateAge { get; private set; }
        public bool Castrated { get; private set; }
        public bool Dead { get; private set; } = false;
        public AnimalHistory AnimalHistory { get; private set; }

        public void Castrate(DateTime procedureDate, string observation)
        {
            this.Castrated = true;
            UpdateAnimalHistoryItem(Guid.NewGuid(), "Castrado", observation);
        }

        public bool UpdateAnimalHistoryItem(Guid id, string title, string report)
        {
            return this.AnimalHistory.UpdateItem(id, title, report);
        }
    }
}