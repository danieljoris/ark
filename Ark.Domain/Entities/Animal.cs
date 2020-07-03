using System;
using Ark.Shared;

namespace Ark.Domain.Entities
{
    public class Animal : Entity
    {
        public Animal(string name, string approximateAge, bool castrated)
        {
            Name = name;
            ApproximateAge = approximateAge;
            Castrated = castrated;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public string Name { get; private set; }
        public Specie Specie { get; private set; }
        public Race Race { get; private set; }
        public DateTime? Birthday { get; private set; }
        public bool IsBirthday => Birthday.HasValue ? BirthdayIsToday() : false;
        public string ApproximateAge { get; private set; }
        public bool Castrated { get; private set; }
        public bool Dead { get; private set; } = false;
        public AnimalHistory AnimalHistory { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public void UpdateApproximateAge(string approximateAge)
        {
            this.ApproximateAge = ApproximateAge;
        }

        public void Castrate(DateTime procedureDate, string observation)
        {
            this.Castrated = true;
            AddAnimalHistoryItem("Castrado", observation);
        }

        public void AnimalDied(DateTime date, string cause)
        {
            this.Dead = true;
            AddAnimalHistoryItem("Morreu", cause);
        }

        public void AddAnimalHistoryItem(string title, string report)
        {
            AnimalHistory.AddItem(title, report);
        }

        private bool BirthdayIsToday()
        {
            return this.Birthday.Value.Date == DateTime.Today.Date;
        }
    }
}