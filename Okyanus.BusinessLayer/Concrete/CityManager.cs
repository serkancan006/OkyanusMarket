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
    public class CityManager : ICityService
    {
        ICityDal _CityDal;
        public CityManager(ICityDal CityDal)
        {
            _CityDal = CityDal;
        }

        public async Task TAddAsync(City entity)
        {
            await _CityDal.AddAsync(entity);
        }

        public async Task TAddRangeAsync(IEnumerable<City> entities)
        {
            await _CityDal.AddRangeAsync(entities);
        }

        public async Task<bool> TAnyAsync(Expression<Func<City, bool>> filter = null)
        {
            return await _CityDal.AnyAsync(filter);
        }

        public IQueryable<City> TAsQueryable()
        {
            return _CityDal.AsQueryable();
        }

        public async Task<int> TCountAsync(Expression<Func<City, bool>> filter = null)
        {
            return await _CityDal.CountAsync();
        }

        public async Task TDeleteAsync(City entity)
        {
            await _CityDal.DeleteAsync(entity);
        }

        public async Task TDeleteRangeAsync(IEnumerable<City> entities)
        {
            await _CityDal.DeleteRangeAsync(entities);
        }

        public async Task<City> TGetByIDAsync(int id)
        {
            return await _CityDal.GetByIDAsync(id);
        }

        public async Task<City> TGetFirstOrDefaultAsync(Expression<Func<City, bool>> filter)
        {
            return await _CityDal.GetFirstOrDefaultAsync(filter);
        }

        public async Task<List<City>> TGetListAllAsync()
        {
            return await _CityDal.GetListAllAsync();
        }

        public IQueryable<City> TInclude(Expression<Func<City, object>> navigationPropertyPath)
        {
            return _CityDal.Include(navigationPropertyPath);
        }

        public IQueryable<City> TOrderBy(Expression<Func<City, object>> keySelector)
        {
            return _CityDal.OrderBy(keySelector);
        }

        public IQueryable<City> TOrderByDescending(Expression<Func<City, object>> keySelector)
        {
            return _CityDal.OrderByDescending(keySelector);
        }

        public async Task TUpdateAsync(City entity)
        {
            await _CityDal.UpdateAsync(entity);
        }

        public async Task TUpdateRangeAsync(IEnumerable<City> entities)
        {
            await _CityDal.UpdateRangeAsync(entities);
        }

        public IQueryable<City> TWhere(Expression<Func<City, bool>> filter)
        {
            return _CityDal.Where(filter);
        }
    }
}
