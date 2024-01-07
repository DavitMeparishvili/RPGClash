using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace RPGClash.Infrastucture.Repositories
{
    public abstract class RepositoryBase<T> where T : class
    {
        protected GameDbContext _repositoryContext { get; set; }
        public RepositoryBase(GameDbContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public async Task<List<T>> FindAll(Func<IQueryable<T>, IQueryable<T>> includeFunc = null)
        {
           var query = _repositoryContext.Set<T>().AsNoTracking();

            if (includeFunc != null)
            {
                query = includeFunc(query);
            }

            return await query.ToListAsync();
        }

        public async Task<T?> FindFirstOrDefaultByCondition(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IQueryable<T>> includeFunc = null)
        {
            return await FindByConditionAndIncludes(expression, includeFunc).FirstOrDefaultAsync();
        }

        public async Task<T> Create(T entity)
        {
            await _repositoryContext.Set<T>().AddAsync(entity);
            await _repositoryContext.SaveChangesAsync();
            return entity;
        }

        public async Task Update(T entity) 
        {
            _repositoryContext.Set<T>().Update(entity);
            await _repositoryContext.SaveChangesAsync();
        }
        
        public async Task Delete(T entity)
        {
            _repositoryContext.Set<T>().Remove(entity);
            await _repositoryContext.SaveChangesAsync();
        }

        private IQueryable<T> FindByConditionAndIncludes(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IQueryable<T>> includeFunc = null)
        {
            var query = _repositoryContext.Set<T>().Where(expression).AsNoTracking();

            if (includeFunc != null)
            {
                query = includeFunc(query);
            }

            return query;
        }
    }
}
