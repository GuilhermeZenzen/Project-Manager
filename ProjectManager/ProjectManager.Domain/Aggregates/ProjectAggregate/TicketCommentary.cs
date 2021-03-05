using ProjectManager.Domain.Common.Entities;
using System;

namespace ProjectManager.Domain.Aggregates.ProjectAggregate
{
    public class TicketCommentary : AuditableEntity
    {
        public string AuthorName { get; private set; }
        public string Body { get; private set; }
        public Guid TicketId { get; private set; }

        public Ticket Ticket { get; private set; }

        public TicketCommentary(string authorName, string body, Guid ticketId)
        {
            AuthorName = authorName;
            Body = body;
            TicketId = ticketId;
        }

        public void ChangeBody(string newBody)
        {
            Body = newBody;
            Updated();
        }
    }
}
