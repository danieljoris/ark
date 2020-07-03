using System;

namespace Ark.Shared
{
    public class Entity
    {
        public Guid Id { get; }

        public Entity()
        {
            this.Id = Guid.NewGuid();
        }
    }
}