using System.Linq.Expressions;

namespace Application.Repositories;

public interface IGenericRepository<T>
{
    Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken);
    Task<T?> GetById(Guid id, CancellationToken cancellationToken);
    Task<T?> Get(Expression<Func<T, bool>> pred, CancellationToken cancellationToken);
    Task<T> Add(T entity, CancellationToken cancellationToken);
    Task<T> Update(T entity, Guid id, CancellationToken cancellationToken);
    Task<bool> Delete(Guid id, CancellationToken cancellationToken);
}
