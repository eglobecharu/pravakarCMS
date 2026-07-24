using System.Linq.Expressions;
using PRAVAKAR.Domain.Interfaces;
using PRAVAKAR.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace PRAVAKAR.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _set;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
        _set = context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(int id) => await _set.FindAsync(id);

    public async Task<IReadOnlyList<T>> GetAllAsync() => await _set.ToListAsync();

    public async Task<IReadOnlyList<T>> FindAsync(Expression<Func<T, bool>> predicate) =>
        await _set.Where(predicate).ToListAsync();

    public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate) =>
        await _set.FirstOrDefaultAsync(predicate);

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate) => await _set.AnyAsync(predicate);

    public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null) =>
        predicate is null ? await _set.CountAsync() : await _set.CountAsync(predicate);

    public IQueryable<T> Query() => _set.AsQueryable();

    public async Task AddAsync(T entity) => await _set.AddAsync(entity);

    public async Task AddRangeAsync(IEnumerable<T> entities) => await _set.AddRangeAsync(entities);

    public void Update(T entity) => _set.Update(entity);

    public void Remove(T entity) => _set.Remove(entity);

    public void RemoveRange(IEnumerable<T> entities) => _set.RemoveRange(entities);
}
