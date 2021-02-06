using System;
using Ark.Core.Entities;
using Ark.Domain.Enums;

namespace Ark.Domain.Entities
{
    public sealed class Animal : Entity
    {
        public Animal(
            string name, 
            string approximateAge, 
            bool castrated,
            Gender gender,
            Size size)
        {
            Name = name;
            ApproximateAge = approximateAge;
            Castrated = castrated;
        }

        public Animal(
            string name,
            DateTime birthday,
            bool castrated,
            Gender gender,
            Size size)
        {
            Name = name;
            Birthday = birthday;
            ApproximateAge = birthday.ToString();
            Castrated = castrated;
        }

        public string Name { get; private set; }
        public Specie Specie { get; private set; }
        public Race Race { get; private set; }
        public Gender Gender { get; private set; }
        public Size Size { get; private set; }
        public DateTime? Birthday { get; private set; }
        public bool IsBirthday => Birthday.HasValue ? BirthdayIsToday() : false;
        public string ApproximateAge { get; private set; }
        public bool Castrated { get; private set; }
        public bool Dead { get; private set; } = false;
        public History History { get; private set; }
        
        public void ChangeGender(Gender gender)
        {
            this.Gender = gender;
        }

        public void ChangeApproximateAge(string approximateAge)
        {
            this.ApproximateAge = ApproximateAge;
        }

        public void Castrate(DateTime procedureDate, string observation)
        {
            this.Castrated = true;
            AddAnimalHistoryItem("Castração", observation);
        }

        public void AnimalDied(DateTime date, string cause)
        {
            this.Dead = true;
            AddAnimalHistoryItem("Morte", cause);
        }

        public void AddAnimalHistoryItem(string title, string report)
        {
            AnimalHistory.AddItem(title, report);
        }

        private bool BirthdayIsToday()
        {
            return this.Birthday.Value.Date == DateTime.UtcNow.Date;
        }
    }
}