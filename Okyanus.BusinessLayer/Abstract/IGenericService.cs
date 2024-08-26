using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Okyanus.BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        Task TAddRangeAsync(IEnumerable<T> entities);
        Task TDeleteRangeAsync(IEnumerable<T> entities);
        Task TUpdateRangeAsync(IEnumerable<T> entities);

        Task TAddAsync(T entity);
        Task TDeleteAsync(T entity);
        Task TUpdateAsync(T entity);

        Task<T> TGetByIDAsync(int id);
        Task<T> TGetByIDAsync(string id);
        Task<List<T>> TGetListAllAsync();

        IQueryable<T> TAsQueryable();
        IQueryable<T> TInclude(Expression<Func<T, object>> navigationPropertyPath);
        Task<T> TGetFirstOrDefaultAsync(Expression<Func<T, bool>> filter);
        Task<int> TCountAsync(Expression<Func<T, bool>> filter = null);
        Task<bool> TAnyAsync(Expression<Func<T, bool>> filter = null);
        IQueryable<T> TOrderBy(Expression<Func<T, object>> keySelector);
        IQueryable<T> TOrderByDescending(Expression<Func<T, object>> keySelector);
        IQueryable<T> TWhere(Expression<Func<T, bool>> filter);
    }
}
