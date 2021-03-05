using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Interfaces;
using ProjectManager.Infrastructure.Contexts;
using ProjectManager.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        public ProjectManagerContext Context { get; private set; }

        public IUserRepository UserRepository { get; }

        private Dictionary<Type, IRepositoryBase> _repositories = new Dictionary<Type, IRepositoryBase>();

        public UnitOfWork(ProjectManagerContext context)
        {
            Context = context;

            UserRepository = new UserRepository(Context);
        }

        public RepositoryType GetRepository<RepositoryType>() where RepositoryType : IRepositoryBase
        {
            Type repositoryType = typeof(RepositoryType);

            if (_repositories.ContainsKey(repositoryType))
                return (RepositoryType)_repositories[repositoryType];

            RepositoryType repository = (RepositoryType)Activator.CreateInstance(repositoryType, Context);
            _repositories.Add(repositoryType, repository);

            return repository;
        }

        public async Task<int> Commit() => await Context.SaveChangesAsync();
    }
}
