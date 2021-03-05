using System;

namespace ProjectManager.Domain.Common.Entities
{
    public class AuditableEntity : Entity
    {
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        protected AuditableEntity()
        {
            CreatedAt = DateTime.UtcNow;
        }

        public void Updated() => UpdatedAt = DateTime.UtcNow;
    }
}
