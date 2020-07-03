using System;
using System.Collections.Generic;
using System.Linq;
using Ark.Shared;

namespace Ark.Domain.Entities
{
    public class AnimalHistory : Entity
    {
        private IList<AnimalHistoryItem> _animalHistoryItems;

        public AnimalHistory()
        {
            _animalHistoryItems = new List<AnimalHistoryItem>();
        }

        public IReadOnlyCollection<AnimalHistoryItem> AnimalHistoryItems => _animalHistoryItems.ToList().AsReadOnly();


        protected internal void AddItem(string title, string report)
        {
            _animalHistoryItems.Add(new AnimalHistoryItem(title, report));
        }

        protected internal void AddItem(AnimalHistoryItem item)
        {
            _animalHistoryItems.Add(item);
        }

        protected internal bool UpdateItem(Guid id, string title, string report)
        {
            var result = _animalHistoryItems.First(x => x.Id == id);

            if (result != null)
            {
                result.UpdateItem(title, report);
                return true;
            }
            else
                return false;
        }
    }
}