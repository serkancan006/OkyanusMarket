using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Okyanus.DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        Task AddRangeAsync(IEnumerable<T> entities);
        Task DeleteRangeAsync(IEnumerable<T> entities);
        Task UpdateRangeAsync(IEnumerable<T> entities);

        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);

        Task<T> GetByIDAsync(int id);
        Task<List<T>> GetListAllAsync(bool tracking = false);

        // Linq sorguları oluşturmak için kullanılan IQueryable örneği döndüren metot.
        IQueryable<T> AsQueryable(bool tracking = false);
        // İlişkili verileri yüklemek için kullanılan metot.
        IQueryable<T> Include(Expression<Func<T, object>> navigationPropertyPath, bool tracking = false);
        // Belirli bir koşula göre ilk öğeyi almak için kullanılan metot.
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter, bool tracking = false);
        // Belirli bir koşula göre sayma işlemi yapmak için kullanılan metot.
        Task<int> CountAsync(Expression<Func<T, bool>> filter = null, bool tracking = false);
        // Belirli bir koşulu karşılayan varlık olup olmadığını kontrol etmek için kullanılan metot.
        Task<bool> AnyAsync(Expression<Func<T, bool>> filter = null, bool tracking = false);
        // Sıralama yapmak için kullanılan metot.
        IQueryable<T> OrderBy(Expression<Func<T, object>> keySelector, bool tracking = false);
        // Azalan sırada sıralama yapmak için kullanılan metot.
        IQueryable<T> OrderByDescending(Expression<Func<T, object>> keySelector, bool tracking = false);
        // Belirli bir koşula göre filtreleme yapmak için kullanılan metot.
        IQueryable<T> Where(Expression<Func<T, bool>> filter, bool tracking = false);
    }
}
