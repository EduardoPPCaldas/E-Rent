using System.Linq.Expressions;
using Application.Repositories;
using Infrastructure.Database;
using Infrastructure.Repositories.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly ApplicationDatabase _context;

    public GenericRepository(ApplicationDatabase context)
    {
        _context = context;
    }

    public async Task<T> Add(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Delete(Guid id)
    {
        var entity = await _context.Set<T>().FindAsync(id);
        if (entity is null) return false;

        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<T?> Get(Expression<Func<T, bool>> pred)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(pred);
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T?> GetById(Guid id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<T> Update(T entity, Guid id)
    {
        var dbEntity = await _context.Set<T>().FindAsync(id)
            ?? throw new EntityNotFoundException();

        _context.Entry(dbEntity).CurrentValues.SetValues(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}
