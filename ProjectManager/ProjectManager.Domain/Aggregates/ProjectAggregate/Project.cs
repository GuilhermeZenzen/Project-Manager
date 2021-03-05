using ProjectManager.Domain.Aggregates.UserAggregate;
using ProjectManager.Domain.Common.Entities;
using System;
using System.Collections.Generic;

namespace ProjectManager.Domain.Aggregates.ProjectAggregate
{
    public class Project : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Guid CreatorId { get; private set; }

        public virtual User Creator { get; private set; }

        public virtual IList<ProjectMember> Members { get; private set; } = new List<ProjectMember>();
        public virtual IList<ProjectTicketCategory> TicketCategories { get; private set; } = new List<ProjectTicketCategory>();
        public virtual IList<Ticket> Tickets { get; private set; } = new List<Ticket>();

        public Project() { }

        public Project(string name, string description, User creator)
        {
            ChangeName(name);
            Description = description;
            CreatorId = creator.Id;
            Creator = creator;
        }

        public void ChangeName(string newName)
        {
            if (string.IsNullOrEmpty(newName))
                AddValidationError("Invalid Name", "The name can't be empty");

            Name = newName;
        }

        public ProjectMember AddMember(Guid memberId)
        {
            ProjectMember projectMember = new ProjectMember(Id, memberId);
            Members.Add(projectMember);

            return projectMember;
        }

        public ProjectTicketCategory AddTicketCategory(Guid ticketCategoryId)
        {
            ProjectTicketCategory projectTicketCategory = new ProjectTicketCategory(Id, ticketCategoryId);
            TicketCategories.Add(projectTicketCategory);

            return projectTicketCategory;
        }

        public Ticket AddTicket(string name, string description, Guid submitterId, Guid projectTicketCategoryId)
        {
            Ticket ticket = new Ticket(name, description, submitterId, projectTicketCategoryId, Id);

            if (ticket.IsValid())
            {
                Tickets.Add(ticket);

                return ticket;
            }

            return null;
        }
    }
}
