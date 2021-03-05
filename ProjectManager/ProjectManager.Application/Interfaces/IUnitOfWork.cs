using System.Threading.Tasks;

namespace ProjectManager.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }

        RepositoryType GetRepository<RepositoryType>() where RepositoryType: IRepositoryBase;

        Task<int> Commit();
    }
}
