using System;

namespace Ark.Core.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; private set;  }

        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public DateTime DeletedAt { get; private set; }


        public Entity()
        {
            this.Id = Guid.NewGuid();
            this.CreatedAt = DateTime.UtcNow;
        }
    }
}