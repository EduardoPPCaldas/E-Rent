using System.Linq.Expressions;
using Application.Repositories;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly ApplicationDatabase _context;

    public GenericRepository(ApplicationDatabase context)
    {
        _context = context;
    }

    public Task<T> Add(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<T?> Get(Expression<Func<T, bool>> pred)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(pred);
    }

    public Task<IEnumerable<T>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<T?> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<T> Update(T entity)
    {
        throw new NotImplementedException();
    }
}
