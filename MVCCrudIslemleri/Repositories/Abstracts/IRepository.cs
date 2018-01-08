using MVCCrudIslemleri.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVCCrudIslemleri.Repositories.Abstracts
{
    public interface IRepository<T>
        where T : EntityBase, new()
    {
        void Add(T entity);
        void Delete(int id);
        void Update(T entity);
        IEnumerable<T> GetAll();
        IQueryable<T> WhereQueryable(Expression<Func<T, bool>> lamda);
        IEnumerable<T> Where(Expression<Func<T, bool>> lamda);
        T GetObject(Expression<Func<T, bool>> lamda);
    }
}
