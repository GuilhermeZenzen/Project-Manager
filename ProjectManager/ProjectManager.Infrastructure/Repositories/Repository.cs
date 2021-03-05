using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Interfaces;
using ProjectManager.Domain.Common.Entities;
using ProjectManager.Infrastructure.Contexts;
using ProjectManager.Infrastructure.Utility.Sql;

namespace ProjectManager.Infrastructure.Repositories
{
    public abstract class Repository<ET> : IRepository<ET> where ET : Entity, IAggregateRoot, new()
    {
        protected ProjectManagerContext _context;
        protected DbSet<ET> _set;

        public Repository(ProjectManagerContext context)
        {
            _context = context;
            _set = _context.Set<ET>();
        }

        public Type GetEntityType() => typeof(ET);

        public string GetTableName<T>() => _context.Model.FindEntityType(typeof(T)).GetTableName();

        public async Task<ET> Get(Guid id) => await _set.FindAsync(id);

        public async Task<IEnumerable<ET>> GetAll() => await _set.ToListAsync();

        public async Task<ET> Find(Expression<Func<ET, bool>> predicate) => await _set.FirstOrDefaultAsync(predicate);

        public async Task<IEnumerable<ET>> FindAll(Expression<Func<ET, bool>> predicate) => await _set.Where(predicate).ToListAsync();

        public async Task<ET> LoadCollection<TProperty>(ET entity, Expression<Func<ET, IEnumerable<TProperty>>> propertyExpression) where TProperty: class
        {
            await _context.Entry(entity).Collection(propertyExpression).LoadAsync();

            return entity;
        }

        public void Add(ET entity) => _set.Add(entity);

        public void AddRange(IEnumerable<ET> entities) => _set.AddRange(entities);

        public void Update(ET entity) => _set.Update(entity);

        public virtual void RemoveWhere(params FilterCondition[] filters) => RemoveWhere<ET>(filters);
        
        public virtual void RemoveWhere<T>(params FilterCondition[] filters)
        {
            StringBuilder rawSql = new StringBuilder($"DELETE FROM {GetTableName<T>()} WHERE ");
            List<object> inputs = new List<object>();
            int interiorInputsIndex = 0;

            for (int i = 0; i < filters.Length; i++)
            {
                string[] parametersPositions = new string[filters[i].Inputs.Length];

                for (int j = 0; j < filters[i].Inputs.Length; j++)
                {
                    inputs.Add(filters[i].Inputs[j]);
                    parametersPositions[j] = "{" + interiorInputsIndex + "}";
                    interiorInputsIndex++;
                }

                rawSql.Append(string.Format(filters[i].Condition, parametersPositions));
            }

            _context.AddCommand(async () => await _context.Database.ExecuteSqlRawAsync(rawSql.ToString(), inputs));
        }

        public virtual void RemoveById(Guid id)
        {
            RemoveWhere(new FilterCondition("Id = {0}", id));
        }
        
        public virtual void RemoveRangeById(List<Guid> ids)
        {
            RemoveWhere(SqlUtility.BuildInCondition("Id", ids));
        }

        public virtual void Remove(ET entity) => _context.Entry(entity).State = EntityState.Deleted;

        public virtual void RemoveRange(IEnumerable<ET> entities) => RemoveRangeById(Entity.GetIds(entities));
    }
}
