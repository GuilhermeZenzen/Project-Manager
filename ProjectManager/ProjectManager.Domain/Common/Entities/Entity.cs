using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace ProjectManager.Domain.Common.Entities
{
    public abstract class Entity : ValidableObject
    {
        public Guid Id { get; protected set; }
        
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public void SetId(Guid id) => Id = id;

        public static List<Guid> GetIds(IEnumerable<Entity> entities)
        {
            List<Guid> ids = new List<Guid>();

            foreach (Entity entity in entities)
            {
                ids.Add(entity.Id);
            }

            return ids;
        }

        public override bool Equals(object obj)
        {
            Entity compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo)) return true;

            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b) => !(a == b);

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 1039) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GetType().Name} (Id: {Id})";
        }
    }
}
