namespace Lab05_RoyChuchullo.Interfaces;

public interface IUnitOfWork : IDisposable {
    IGenericRepository<T> Repository<T>() where T : class;
    Task<int> CompleteAsync();
}