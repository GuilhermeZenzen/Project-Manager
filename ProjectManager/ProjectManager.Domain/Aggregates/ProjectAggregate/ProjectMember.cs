using ProjectManager.Domain.Aggregates.UserAggregate;
using ProjectManager.Domain.Common.Entities;
using System;

namespace ProjectManager.Domain.Aggregates.ProjectAggregate
{
    public class ProjectMember : Entity
    {
        public Guid ProjectId { get; private set; }
        public Project Project { get; private set; }

        public Guid MemberId { get; private set; }
        public User Member { get; private set; }

        public ProjectMember() { }

        public ProjectMember(Guid projectId, Guid memberId) => (ProjectId, MemberId) = (projectId, memberId);
    }
}
