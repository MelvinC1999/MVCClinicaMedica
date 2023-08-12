﻿using Microsoft.EntityFrameworkCore;
using MVCClinicaMedica.DBContext;
//using static MVCClinicaMedica.Repository.GenericRepository;
using System.Linq.Expressions;

namespace MVCClinicaMedica.Repository
{
    
        internal class GenericRepository<T> : IGenericRepository<T> where T : class
        {
            private readonly BaseEFContext _context;
            private readonly DbSet<T> dbSet;

            public GenericRepository()
            {
                _context = new BaseEFContext(); ;
                dbSet = _context.Set<T>();
            }

            public virtual EntityState Add(T entity)
            {
                return dbSet.Add(entity).State;
            }

            public T Get<TKey>(TKey id)
            {
                return dbSet.Find(id);
            }

            public async Task<T> GetAsync<TKey>(TKey id)
            {
                return await dbSet.FindAsync(id);
            }

            public T Get(params object[] keyValues)
            {
                return dbSet.Find(keyValues);
            }

            public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
            {
                return dbSet.Where(predicate);
            }

            public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate, string include)
            {
                return FindBy(predicate).Include(include);
            }

            public IQueryable<T> GetAll()
            {
                return dbSet;
            }

            public IQueryable<T> GetAll(int page, int pageCount)
            {
                var pageSize = (page - 1) * pageCount;

                return dbSet.Skip(pageSize).Take(pageCount);
            }

            public IQueryable<T> GetAll(string include)
            {
                return dbSet.Include(include);
            }

            public IQueryable<T> RawSql(string query, params object[] parameters)
            {
                return dbSet.FromSqlRaw(query, parameters);
            }

            public IQueryable<T> GetAll(string include, string include2)
            {
                return dbSet.Include(include).Include(include2);
            }

            public bool Exists(Expression<Func<T, bool>> predicate)
            {
                return dbSet.Any(predicate);
            }

            public virtual EntityState SoftDelete(T entity)
            {
                entity.GetType().GetProperty("IsActive")?.SetValue(entity, false);
                return dbSet.Update(entity).State;
            }

            public virtual EntityState HardDelete(T entity)
            {
                return dbSet.Remove(entity).State;
            }
            public virtual EntityState Update(T entity)
            {
                return dbSet.Update(entity).State;
            }

            public virtual void SaveChanges()
            {
                _context.SaveChanges();
            }

        }
    
}
