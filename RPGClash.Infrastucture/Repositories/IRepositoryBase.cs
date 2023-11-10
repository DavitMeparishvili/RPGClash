using System.Linq.Expressions;

namespace RPGClash.Infrastucture.Repositories
{
    public interface IRepositoryBase<TEntity>
    {
        IQueryable<TEntity> FindAll(Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc = null);
        IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc = null);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
