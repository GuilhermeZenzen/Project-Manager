using ProjectManager.Domain.Common.Entities;
using System;

namespace ProjectManager.Domain.Aggregates.ProjectAggregate
{
    public class TicketChange : AuditableEntity
    {
        public string PropertyName { get; private set; }
        public string OldValue { get; private set; }
        public string NewValue { get; private set; }
        public string AuthorName { get; private set; }
        public Guid TicketId { get; private set; }

        public Ticket Ticket { get; private set; }

        public TicketChange(string propertyName, string oldValue, string newValue, string authorName, Guid ticketId)
        {
            PropertyName = propertyName;
            OldValue = oldValue;
            NewValue = newValue;
            AuthorName = authorName;
            TicketId = ticketId;
        }
    }
}
