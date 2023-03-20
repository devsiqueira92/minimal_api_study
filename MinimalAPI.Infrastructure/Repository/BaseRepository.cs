using Microsoft.EntityFrameworkCore;
using MinimalAPI.Domain.RepositoryInterface;
using MinimalAPI.Infrastructure.Context;
using System.Linq.Expressions;

namespace MinimalAPI.Infrastructure.Repository;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly UserContext _db;
    internal DbSet<T> dbSet;
    public BaseRepository(UserContext db)
    {
        _db = db;
        dbSet = _db.Set<T>();
    }

    public async Task<T> AddAsync(T entity)
    {
        await dbSet.AddAsync(entity);
        await SaveAsync();

        return entity;
    }

    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, string includes = null)
    {
        IQueryable<T> query = dbSet;

        if (includes is not null)
        {
            var includeTable = includes.Split(',', StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in includeTable)
            {
                query = query.Include(item.Trim());
            }
        }

        if (filter != null)
        {
            query = query.Where(filter);
        }

        return await query.ToListAsync();
    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true, string includes = null)
    {
        IQueryable<T> query = dbSet;

        if (includes is not null)
        {
            var includeTable = includes.Split(',');
            foreach (var item in includeTable)
            {
                query = query.Include(item.Trim());
            }
        }

        if (!tracked)
        {
            query = query.AsNoTracking();
        }
        if (filter != null)
        {
            query = query.Where(filter);
        }

        return await query.SingleOrDefaultAsync();
    }

    public async Task<T> UpdateAsync(T entity)
    {
        dbSet.Update(entity);
        await SaveAsync();
        return entity;
    }

    private async Task SaveAsync()
    {
        await _db.SaveChangesAsync();
    }

}
