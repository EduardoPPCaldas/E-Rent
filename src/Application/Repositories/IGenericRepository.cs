using System.Linq.Expressions;

namespace Application.Repositories;

public interface IGenericRepository<T>
{
    Task<IEnumerable<T>> GetAll();
    Task<T?> GetById(Guid id);
    Task<T?> Get(Expression<Func<T, bool>> pred);
    Task<T> Add(T entity);
    Task<T> Update(T entity);
    Task<bool> Delete(Guid id);
}
