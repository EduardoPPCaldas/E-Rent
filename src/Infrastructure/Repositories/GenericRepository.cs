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

    public async Task<T> Add(T entity, CancellationToken cancellationToken)
    {
        await _context.Set<T>().AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<bool> Delete(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _context.Set<T>().FindAsync(new object?[] { id }, cancellationToken: cancellationToken);
        if (entity is null) return false;

        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<T?> Get(Expression<Func<T, bool>> pred, CancellationToken cancellationToken)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(pred, cancellationToken: cancellationToken);
    }

    public async Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken)
    {
        return await _context.Set<T>().ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<T?> GetById(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Set<T>().FindAsync(new object?[] { id }, cancellationToken: cancellationToken);
    }

    public async Task<T> Update(T entity, Guid id, CancellationToken cancellationToken)
    {
        var dbEntity = await _context.Set<T>().FindAsync(new object?[] { id }, cancellationToken: cancellationToken)
            ?? throw new EntityNotFoundException();

        _context.Entry(dbEntity).CurrentValues.SetValues(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }
}
