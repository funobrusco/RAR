﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RAR.DAL.Repository
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();
        Task<IEnumerable<T>> FindAllAsync();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T> GetByIdAsync(Expression<Func<T, bool>> expression);
        void CreateAsync(T entity);
    }
}
