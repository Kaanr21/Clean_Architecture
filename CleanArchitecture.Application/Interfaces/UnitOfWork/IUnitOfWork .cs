using CleanArchitecture.Application.Interfaces.Services;

namespace CleanArchitecture.Application.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : class;
        Task<int> SaveChangesAsync();
    }

}
