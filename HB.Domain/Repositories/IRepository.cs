using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HB.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Add(TEntity entity, CancellationToken cancellationToken);
        Task<TEntity> Update( TEntity entity, CancellationToken cancellationToken);
        Task<TEntity> Delete(Guid id, CancellationToken cancellationToken);
        Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken);
        Task<TEntity> GetById(Guid id, CancellationToken cancellationToken);
        Task<List<TEntity>> GetAll( CancellationToken cancellationToken);
    }
}
