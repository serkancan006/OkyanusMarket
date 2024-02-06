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
        void TAddRange(IEnumerable<T> entities);
        void TDeleteRange(IEnumerable<T> entities);
        void TUpdateRange(IEnumerable<T> entities);

        void TAdd(T entity);
        void TDelete(T entity);
        void TUpdate(T entity);

        T TGetByID(int id);
        List<T> TGetListAll(bool tracking = true);

        IQueryable<T> TAsQueryable(bool tracking = true);
        IQueryable<T> TInclude(Expression<Func<T, object>> navigationPropertyPath, bool tracking = true);
        T TGetFirstOrDefault(Expression<Func<T, bool>> filter, bool tracking = true);
        int TCount(Expression<Func<T, bool>> filter = null, bool tracking = true);
        bool TAny(Expression<Func<T, bool>> filter = null, bool tracking = true);
        IQueryable<T> TOrderBy(Expression<Func<T, object>> keySelector, bool tracking = true);
        IQueryable<T> TOrderByDescending(Expression<Func<T, object>> keySelector, bool tracking = true);
        IQueryable<T> TWhere(Expression<Func<T, bool>> filter, bool tracking = true);
    }
}
