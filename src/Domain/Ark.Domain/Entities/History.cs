using System;
using System.Collections.Generic;
using System.Linq;
using Ark.Core.Entities;

namespace Ark.Domain.Entities
{
    public sealed class History : Entity
    {
        public IReadOnlyCollection<HistoryItem> Items => _items.AsReadOnly();

        private List<HistoryItem> _items;

        public History()
        {
            _items = new List<HistoryItem>();
        }

        protected internal void AddItem(string title, string report)
        {
            _items.Add(new HistoryItem(title, report));
        }

        protected internal void AddItem(string title, string report, DateTime occurrenceDate)
        {
            _items.Add(new HistoryItem(title, report, occurrenceDate));
        }

        protected internal void AddItem(HistoryItem item)
        {
            _items.Add(item);
        }
    }
}