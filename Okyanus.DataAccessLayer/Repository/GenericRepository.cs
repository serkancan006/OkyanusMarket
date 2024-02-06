using Microsoft.EntityFrameworkCore;
using Okyanus.DataAccessLayer.Abstract;
using Okyanus.DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Okyanus.DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly Context _context;

        public GenericRepository(Context context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                _context.Update(entity);
                _context.SaveChanges();
            }
        }

        public T GetByID(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetListAll(bool tracking = true)
        {
            if (!tracking)
                return _context.Set<T>().AsNoTracking().ToList();
            else
                return _context.Set<T>().ToList();
        }

        public IQueryable<T> AsQueryable(bool tracking = true)
        {
            if (!tracking)
                return _context.Set<T>().AsNoTracking();
            else
                return _context.Set<T>().AsQueryable();
        }

        public IQueryable<T> Include(Expression<Func<T, object>> navigationPropertyPath, bool tracking = true)
        {
            if (!tracking)
                return _context.Set<T>().AsNoTracking().Include(navigationPropertyPath);
            else
                return _context.Set<T>().Include(navigationPropertyPath);
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter, bool tracking = true)
        {
            if (!tracking)
                return _context.Set<T>().AsNoTracking().FirstOrDefault(filter);
            else
                return _context.Set<T>().FirstOrDefault(filter);
        }

        public int Count(Expression<Func<T, bool>> filter = null, bool tracking = true)
        {
            if (!tracking)
                return filter != null ? _context.Set<T>().AsNoTracking().Count(filter) : _context.Set<T>().AsNoTracking().Count();
            else
                return filter != null ? _context.Set<T>().Count(filter) : _context.Set<T>().Count();
        }

        public bool Any(Expression<Func<T, bool>> filter = null, bool tracking = true)
        {
            if (!tracking)
                return filter != null ? _context.Set<T>().AsNoTracking().Any(filter) : _context.Set<T>().AsNoTracking().Any();
            else
                return filter != null ? _context.Set<T>().Any(filter) : _context.Set<T>().Any();
        }

        public IQueryable<T> OrderBy(Expression<Func<T, object>> keySelector, bool tracking = true)
        {
            if (!tracking)
                return _context.Set<T>().AsNoTracking().OrderBy(keySelector);
            else
                return _context.Set<T>().OrderBy(keySelector);
        }

        public IQueryable<T> OrderByDescending(Expression<Func<T, object>> keySelector, bool tracking = true)
        {
            if (!tracking)
                return _context.Set<T>().AsNoTracking().OrderByDescending(keySelector);
            else
                return _context.Set<T>().OrderByDescending(keySelector);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> filter, bool tracking = true)
        {
            if (!tracking)
                return _context.Set<T>().AsNoTracking().Where(filter);
            else
                return _context.Set<T>().Where(filter);
        }

    }
}
