using System;

namespace ProjectManager.Domain.Common.Entities
{
    public abstract class EnumEntity<T> where T: Enum
    {
        public T Id { get; private set; }
        public string Name { get; private set; }

        public void Set(T id, string name) => (Id, Name) = (id, name);
    }
}
