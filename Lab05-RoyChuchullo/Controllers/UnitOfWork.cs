using System.Collections;
using Lab05_RoyChuchullo.Interfaces;
using Lab05_RoyChuchullo.Models;
using Lab05_RoyChuchullo.Repositories;
namespace Lab05_RoyChuchullo.Controllers;

public class UnitOfWork : IUnitOfWork {
    private readonly DbContextLab04DB _context;
    private Hashtable _repositories;
    public UnitOfWork(DbContextLab04DB context) {
        _context = context;
    }
    public IGenericRepository<T> Repository<T>() where T : class {
        if (_repositories == null)
            _repositories = new Hashtable();
        var type = typeof(T).Name;
        if (!_repositories.ContainsKey(type)) {
            var repositoryType = typeof(GenericRepository<>);
            var repositoryInstance = Activator.CreateInstance(
                repositoryType.MakeGenericType(typeof(T)), _context);

            _repositories.Add(type, repositoryInstance);
        }
        return (IGenericRepository<T>)_repositories[type];
    }
    public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();
    public void Dispose() => _context.Dispose();
}