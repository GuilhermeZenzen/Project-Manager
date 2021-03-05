using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.Threading;
using ProjectManager.Application.Identity;

namespace ProjectManager.Infrastructure.Contexts
{
    public class ProjectManagerContext : IdentityUserContext<UserIdentity, Guid>
    {
        private List<Func<Task<int>>> _commandsOnSave = new List<Func<Task<int>>>();

        public ProjectManagerContext(DbContextOptions<ProjectManagerContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public void AddCommand(Func<Task<int>> command) => _commandsOnSave.Add(command);

        public async override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            int rowsAffected = 0;

            foreach (Func<Task<int>> command in _commandsOnSave)
                rowsAffected += await command();

            _commandsOnSave.Clear();

            return (await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken)) + rowsAffected;
        }

        public override void Dispose()
        {
            _commandsOnSave = null;

            base.Dispose();
        }

        public override ValueTask DisposeAsync()
        {
            _commandsOnSave = null;

            return base.DisposeAsync();
        }
    }
}
