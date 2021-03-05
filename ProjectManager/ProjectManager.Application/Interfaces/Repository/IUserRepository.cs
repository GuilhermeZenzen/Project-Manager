using ProjectManager.Domain.Aggregates.UserAggregate;
using System;
using System.Threading.Tasks;

namespace ProjectManager.Application.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetWithPersonnel(Guid id);
    }
}
