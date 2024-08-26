using Okyanus.BusinessLayer.Abstract;
using Okyanus.DataAccessLayer.Abstract;
using Okyanus.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Okyanus.BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        IAboutDal _AboutDal;
        public AboutManager(IAboutDal AboutDal)
        {
            _AboutDal = AboutDal;
        }

        public async Task TAddAsync(About entity)
        {
            await _AboutDal.AddAsync(entity);
        }

        public async Task TAddRangeAsync(IEnumerable<About> entities)
        {
            await _AboutDal.AddRangeAsync(entities);
        }

        public async Task<bool> TAnyAsync(Expression<Func<About, bool>> filter = null)
        {
            return await _AboutDal.AnyAsync(filter);
        }

        public IQueryable<About> TAsQueryable()
        {
            return _AboutDal.AsQueryable();
        }

        public async Task<int> TCountAsync(Expression<Func<About, bool>> filter = null)
        {
            return await _AboutDal.CountAsync();
        }

        public async Task TDeleteAsync(About entity)
        {
            await _AboutDal.DeleteAsync(entity);
        }

        public async Task TDeleteRangeAsync(IEnumerable<About> entities)
        {
            await _AboutDal.DeleteRangeAsync(entities);
        }

        public async Task<About> TGetByIDAsync(int id)
        {
            return await _AboutDal.GetByIDAsync(id);
        }

        public async Task<About> TGetByIDAsync(string id)
        {
            return await _AboutDal.GetByIDAsync(id);
        }

        public async Task<About> TGetFirstOrDefaultAsync(Expression<Func<About, bool>> filter)
        {
            return await _AboutDal.GetFirstOrDefaultAsync(filter);
        }

        public async Task<List<About>> TGetListAllAsync()
        {
            return await _AboutDal.GetListAllAsync();
        }

        public IQueryable<About> TInclude(Expression<Func<About, object>> navigationPropertyPath)
        {
            return _AboutDal.Include(navigationPropertyPath);
        }

        public IQueryable<About> TOrderBy(Expression<Func<About, object>> keySelector)
        {
            return _AboutDal.OrderBy(keySelector);
        }

        public IQueryable<About> TOrderByDescending(Expression<Func<About, object>> keySelector)
        {
            return _AboutDal.OrderByDescending(keySelector);
        }

        public async Task TUpdateAsync(About entity)
        {
            await _AboutDal.UpdateAsync(entity);
        }

        public async Task TUpdateRangeAsync(IEnumerable<About> entities)
        {
            await _AboutDal.UpdateRangeAsync(entities);
        }

        public IQueryable<About> TWhere(Expression<Func<About, bool>> filter)
        {
            return _AboutDal.Where(filter);
        }
      
    }
}
