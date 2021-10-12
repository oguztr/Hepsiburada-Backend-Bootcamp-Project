using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HB.Domain.Repositories;
using HB.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace HB.Infrastructure.Repositories
{
    public  class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly HbContext _dbContext;
        protected DbSet<TEntity> _dbSet;
        public Repository(HbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }
    
        public virtual async Task<TEntity> Add(TEntity entity,CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(entity,cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<TEntity> Delete(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _dbSet.FindAsync(new object[] { id }, cancellationToken);
            if (entity == null) return null;
             _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public  Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken)
        {
            return  _dbSet.Where(filter).ToListAsync(cancellationToken);
        }

        public Task<List<TEntity>> GetAll( CancellationToken cancellationToken)
        {
            return _dbSet.ToListAsync(cancellationToken);
        }

        public async Task<TEntity> GetById(Guid id, CancellationToken cancellationToken)
        {
            return await _dbSet.FindAsync( new object[]{ id }, cancellationToken);
        }

        public async Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return await Task.FromResult(entity);

        }
    }
}
