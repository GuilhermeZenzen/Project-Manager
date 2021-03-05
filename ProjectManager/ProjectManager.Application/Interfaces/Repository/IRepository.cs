using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ProjectManager.Domain.Common.Entities;

namespace ProjectManager.Application.Interfaces
{
    public interface IRepository<ET> : IRepositoryBase where ET: Entity, IAggregateRoot
    {
        Task<IEnumerable<ET>> GetAll();
        Task<ET> Get(Guid id);

        Task<IEnumerable<ET>> FindAll(Expression<Func<ET, bool>> predicate);
        Task<ET> Find(Expression<Func<ET, bool>> predicate);

        void Add(ET entity);
        void AddRange(IEnumerable<ET> entities);

        void Update(ET entity);

        void RemoveById(Guid id);
        void Remove(ET entity);
        void RemoveRange(IEnumerable<ET> entities);
    }
}
