using System;
using System.Linq.Expressions;

namespace Baltazar.Data.Contracts
{
	public interface IBaseRepository<TEntity> where TEntity : class
	{
		Task<TEntity?> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>> predicate);
        Task CreateAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task SaveChangesAsync();
    }
}

