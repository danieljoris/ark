using System;
using Ark.Core.Entities;

namespace Ark.Domain.Entities
{
    public sealed class HistoryItem : Entity
    {
        public string Title { get; private set; }
        public string Text { get; private set; }
        public DateTime OccurrenceDate { get; private set; }

        public HistoryItem(string title, string text)
        {
            this.Title = title;
            this.Text = text;
            this.OccurrenceDate = DateTime.UtcNow;
        }

        public HistoryItem(string title, string text, DateTime occurrenceDate)
        {
            this.Title = title;
            this.Text = text;
            this.OccurrenceDate = occurrenceDate;
        }
    }
}