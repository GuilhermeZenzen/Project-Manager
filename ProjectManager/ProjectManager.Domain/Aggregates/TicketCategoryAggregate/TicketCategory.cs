using ProjectManager.Domain.Common.Entities;

namespace ProjectManager.Domain.Aggregates.TicketCategoryAggregate
{
    public class TicketCategory : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public TicketCategory(string name, string description)
        {
            ChangeName(name);
            Description = description;
        }

        public void ChangeName(string newName)
        {
            if (string.IsNullOrEmpty(newName))
            {
                AddValidationError("Invalid Name", "The name can't be empty");
                return;
            }

            Name = newName;
        }
    }
}
