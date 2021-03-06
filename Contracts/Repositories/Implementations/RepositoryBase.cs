using Infrastructure.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected AppDbContext AppDbContext;
        public RepositoryBase(AppDbContext appDbContext)
        {
            AppDbContext = appDbContext;
        }

        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ?
              AppDbContext.Set<T>()
                .AsNoTracking() :
              AppDbContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,
        bool trackChanges) =>
            !trackChanges ?
              AppDbContext.Set<T>()
                .Where(expression)
                .AsNoTracking() :
              AppDbContext.Set<T>()
                .Where(expression);

        public void Create(T entity) => AppDbContext.Set<T>().Add(entity);
        public void Update(T entity) => AppDbContext.Set<T>().Update(entity);
        public void Delete(T entity) => AppDbContext.Set<T>().Remove(entity);
            
            
    }
}
