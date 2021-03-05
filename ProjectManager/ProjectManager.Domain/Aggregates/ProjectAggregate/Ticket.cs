using ProjectManager.Domain.Aggregates.TicketCategoryAggregate;
using ProjectManager.Domain.Aggregates.UserAggregate;
using ProjectManager.Domain.Common.Entities;
using ProjectManager.Domain.Enums;
using ProjectManager.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Domain.Aggregates.ProjectAggregate
{
    public class Ticket : AuditableEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public TicketPriorityEnum PriorityId { get; private set; }
        public TicketStatusEnum StatusId { get; private set; }
        public Guid SubmitterId { get; private set; }
        public Guid ProjectTicketCategoryId { get; private set; }
        public Guid ProjectId { get; private set; }

        public TicketPriority Priority { get; private set; }
        public TicketStatus Status { get; private set; }
        public IList<TicketCommentary> Commentaries { get; private set; } = new List<TicketCommentary>();
        public ProjectMember Submitter { get; private set; }
        public ProjectTicketCategory ProjectTicketCategory { get; private set; }
        public Project Project { get; private set; }
        public IList<TicketChange> Changes { get; private set; } = new List<TicketChange>();

        public Ticket(string name, string description, Guid submitterId, Guid projectTicketCategoryId, Guid projectId)
        {
            ChangeName(name);
            Description = description;
            SubmitterId = submitterId;
            ChangeCategory(projectTicketCategoryId);
            ProjectId = projectId;
        }

        public void ChangeName(string newName)
        {
            if (string.IsNullOrEmpty(newName))
                AddValidationError("Invalid Name", "The name can't be empty");

            Name = newName;
        }

        public void ChangeDescription(string newDescription) => Description = newDescription;

        public void ChangeCategory(Guid newCategoryId) => ProjectTicketCategoryId = newCategoryId;
    }
}
