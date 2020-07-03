using System;
using Ark.Shared;

namespace Ark.Domain.Entities
{
    public class AnimalHistoryItem : Entity
    {
        public string Title { get; private set; }
        public string Report { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdateAt { get; private set; }

        public AnimalHistoryItem(string title, string report)
        {
            this.Title = title;
            this.Report = report;
            this.CreatedAt = DateTime.Now;
        }

        public void UpdateItem(string title, string report)
        {
            this.Title = title;
            this.Report = report;
            this.UpdateAt = DateTime.Now;
        }
    }
}