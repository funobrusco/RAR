using Microsoft.EntityFrameworkCore;
using RAR.DAL.Model.Tabella;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RAR.DAL.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class, new()
    {
        protected RARContext RepositoryContext { get; set; }

        public RepositoryBase(RARContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }

        public IQueryable<T> FindAll()
        {
            return this.RepositoryContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

        public async Task<T> FindByIdAsync(Expression<Func<T, bool>> expression)
        {
            return await FindAll().Where(expression).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await FindAll().ToListAsync();
        }

        public void Create(T entity)
        {
            this.RepositoryContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.RepositoryContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.RepositoryContext.Set<T>().Remove(entity);
        }

        public async Task<T> GetByIdAsync(Expression<Func<T, bool>> expression)
        {
            return await FindByCondition(expression)
                .DefaultIfEmpty(new T())
                .SingleAsync();
        }

        public async void CreateAsync(T entity)
        {
            await this.RepositoryContext.Set<T>().AddAsync(entity);
        }
    }
}
