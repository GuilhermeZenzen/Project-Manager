using System;
using System.Collections.Generic;
using ProjectManager.Domain.Aggregates.TicketCategoryAggregate;
using ProjectManager.Domain.Common.Entities;

namespace ProjectManager.Domain.Aggregates.ProjectAggregate
{
    public class ProjectTicketCategory : Entity
    {
        public Guid ProjectId { get; private set; }
        public Project Project { get; private set; }

        public Guid TicketCategoryId { get; private set; }
        public TicketCategory TicketCategory { get; private set; }

        public IList<Ticket> Tickets { get; private set; } = new List<Ticket>();

        public ProjectTicketCategory(Guid projectId, Guid ticketCategoryId) => (ProjectId, TicketCategoryId) = (projectId, ticketCategoryId);
    }
}
