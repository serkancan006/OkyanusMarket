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
        void AddRange(IEnumerable<T> entities);
        void DeleteRange(IEnumerable<T> entities);
        void UpdateRange(IEnumerable<T> entities);

        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);

        T GetByID(int id);
        List<T> GetListAll(bool tracking = true);

        // Linq sorguları oluşturmak için kullanılan IQueryable örneği döndüren metot.
        IQueryable<T> AsQueryable(bool tracking = true);
        // İlişkili verileri yüklemek için kullanılan metot.
        IQueryable<T> Include(Expression<Func<T, object>> navigationPropertyPath, bool tracking = true);
        // Belirli bir koşula göre ilk öğeyi almak için kullanılan metot.
        T GetFirstOrDefault(Expression<Func<T, bool>> filter, bool tracking = true);
        // Belirli bir koşula göre sayma işlemi yapmak için kullanılan metot.
        int Count(Expression<Func<T, bool>> filter = null, bool tracking = true);
        // Belirli bir koşulu karşılayan varlık olup olmadığını kontrol etmek için kullanılan metot.
        bool Any(Expression<Func<T, bool>> filter = null, bool tracking = true);
        // Sıralama yapmak için kullanılan metot.
        IQueryable<T> OrderBy(Expression<Func<T, object>> keySelector, bool tracking = true);
        // Azalan sırada sıralama yapmak için kullanılan metot.
        IQueryable<T> OrderByDescending(Expression<Func<T, object>> keySelector, bool tracking = true);
        // Belirli bir koşula göre filtreleme yapmak için kullanılan metot.
        IQueryable<T> Where(Expression<Func<T, bool>> filter, bool tracking = true);
    }
}
