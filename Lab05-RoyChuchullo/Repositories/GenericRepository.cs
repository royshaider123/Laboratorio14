using Lab05_RoyChuchullo.Interfaces;
using Lab05_RoyChuchullo.Models;
using Microsoft.EntityFrameworkCore;
namespace Lab05_RoyChuchullo.Repositories;
public class GenericRepository<T> : IGenericRepository<T> where T : class {
    protected readonly DbContextLab04DB _context;
    protected readonly DbSet<T> _dbSet;
    public GenericRepository(DbContextLab04DB context) {
        _context = context;
        _dbSet = context.Set<T>();
    }
    public async Task<T> GetByIdAsync(int id) => await _dbSet.FindAsync(id);
    public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();
    public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);
    public async Task AddRangeAsync(IEnumerable<T> entities) => await _dbSet.AddRangeAsync(entities);
    public void Update(T entity) => _dbSet.Update(entity);
    public void Remove(T entity) => _dbSet.Remove(entity);
    public void RemoveRange(IEnumerable<T> entities) => _dbSet.RemoveRange(entities);
}