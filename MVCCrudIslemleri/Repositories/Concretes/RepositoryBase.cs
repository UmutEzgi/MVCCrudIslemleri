using MVCCrudIslemleri.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using System.Data.Entity;
using MVCCrudIslemleri.Data.Entities;

namespace MVCCrudIslemleri.Repositories.Concretes
{
    public class RepositoryBase<T> :
        IRepository<T> where T : EntityBase, new()
    {
        protected DbContext _context;
        protected IDbSet<T> _dbset;

        public RepositoryBase(DbContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
          
        }

        public void Add(T entity)
        {

            _dbset.Add(entity);
        }

        public void Delete(int id)
        {
             var entity =_dbset.Find(id);
            _dbset.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbset.AsEnumerable<T>();
        }

        public T GetObject(Expression<Func<T, bool>> lamda)
        {
            return _dbset.FirstOrDefault(lamda);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> lamda)
        {
            return _dbset.Where(lamda).AsEnumerable<T>();
        }

        public IQueryable<T> WhereQueryable(Expression<Func<T, bool>> lamda)
        {
            return _dbset.Where(lamda).AsQueryable<T>();
        }
    }
}