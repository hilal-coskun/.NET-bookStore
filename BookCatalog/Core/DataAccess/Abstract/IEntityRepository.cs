using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Abstract
{
    public interface IEntityRepository<T>
    {
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        List<T> GetListWithBookCategories(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
