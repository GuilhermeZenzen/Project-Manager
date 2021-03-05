using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Interfaces;
using ProjectManager.Domain.Aggregates.UserAggregate;
using ProjectManager.Domain.Common.Entities;
using ProjectManager.Infrastructure.Contexts;
using ProjectManager.Infrastructure.Utility.Sql;

namespace ProjectManager.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ProjectManagerContext context) : base(context) { }

        public UserAdministration AddedAdministration(UserAdministration administration)
        {
            _context.Entry(administration).State = EntityState.Added;

            return administration;
        }

        public UserAdministration RemovedAdministration(UserAdministration administration)
        {
            _context.Entry(administration).State = EntityState.Deleted;

            return administration;
        }

        public async Task<User> GetWithPersonnel(Guid id) => await _set.Include(u => u.Personnel).SingleOrDefaultAsync(u => u.Id.Equals(id));

        public async Task<User> GetWithAdministrators(Guid id) => await _set.Include(u => u.Administrators).SingleOrDefaultAsync(u => u.Id.Equals(id));

        public async Task<User> FindWithPersonnel(Expression<Func<User, bool>> predicate) => await _set.Include(u => u.Personnel).FirstAsync(predicate);

        public async Task<User> FindWithAdministrators(Expression<Func<User, bool>> predicate) => await _set.Include(u => u.Administrators).FirstAsync(predicate);

        public override void RemoveById(Guid id)
        {
            RemoveAdministratorRelationships(id);
            base.RemoveById(id);
        }

        public override void Remove(User entity)
        {
            RemoveAdministratorRelationships(entity.Id);
            base.Remove(entity);
        }

        public override void RemoveRange(IEnumerable<User> entities)
        {
            RemoveAdministratorsRelationships(Entity.GetIds(entities));
            base.RemoveRange(entities);
        }

        private void RemoveAdministratorRelationships(Guid administratorId) => RemoveWhere<UserAdministration>(new FilterCondition("AdministratorId = {0}", administratorId));

        private void RemoveAdministratorsRelationships(List<Guid> administratorsId)
        {
            RemoveWhere<UserAdministration>(SqlUtility.BuildInCondition("AdministratorId", administratorsId));
        }
    }
}
