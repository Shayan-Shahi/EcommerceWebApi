using Microsoft.EntityFrameworkCore;

namespace Ecommerce.DataLayer.Context;

public interface IUnitOfWork : IDisposable
{
    DbSet<TEntity> Set<TEntity>() where TEntity : class;

    void MarkAsDeleted<TEntity>(TEntity entity);

    int SaveChanges();

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
