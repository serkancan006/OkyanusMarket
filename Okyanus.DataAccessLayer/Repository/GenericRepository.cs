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

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRangeAsync(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                _context.Update(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<T> GetByIDAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetByIDAsync(string id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetListAllAsync(bool tracking = false)
        {
            if (!tracking)
                return await _context.Set<T>().AsNoTracking().ToListAsync();
            else
                return await _context.Set<T>().ToListAsync();
        }

        public IQueryable<T> AsQueryable(bool tracking = false)
        {
            if (!tracking)
                return _context.Set<T>().AsNoTracking();
            else
                return _context.Set<T>().AsQueryable();
        }

        public IQueryable<T> Include(Expression<Func<T, object>> navigationPropertyPath, bool tracking = false)
        {
            if (!tracking)
                return _context.Set<T>().AsNoTracking().Include(navigationPropertyPath);
            else
                return _context.Set<T>().Include(navigationPropertyPath);
        }

        public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> filter, bool tracking = false)
        {
            if (!tracking)
                return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(filter);
            else
                return await _context.Set<T>().FirstOrDefaultAsync(filter);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> filter = null, bool tracking = false)
        {
            if (!tracking)
                return filter != null ? await _context.Set<T>().AsNoTracking().CountAsync(filter) : await _context.Set<T>().AsNoTracking().CountAsync();
            else
                return filter != null ? await _context.Set<T>().CountAsync(filter) : await _context.Set<T>().CountAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> filter = null, bool tracking = false)
        {
            if (!tracking)
                return filter != null ? await _context.Set<T>().AsNoTracking().AnyAsync(filter) : await _context.Set<T>().AsNoTracking().AnyAsync();
            else
                return filter != null ? await _context.Set<T>().AnyAsync(filter) : await _context.Set<T>().AnyAsync();
        }

        public IQueryable<T> OrderBy(Expression<Func<T, object>> keySelector, bool tracking = false)
        {
            if (!tracking)
                return _context.Set<T>().AsNoTracking().OrderBy(keySelector);
            else
                return _context.Set<T>().OrderBy(keySelector);
        }

        public IQueryable<T> OrderByDescending(Expression<Func<T, object>> keySelector, bool tracking = false)
        {
            if (!tracking)
                return _context.Set<T>().AsNoTracking().OrderByDescending(keySelector);
            else
                return _context.Set<T>().OrderByDescending(keySelector);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> filter, bool tracking = false)
        {
            if (!tracking)
                return _context.Set<T>().AsNoTracking().Where(filter);
            else
                return _context.Set<T>().Where(filter);
        }

       
    }
}
