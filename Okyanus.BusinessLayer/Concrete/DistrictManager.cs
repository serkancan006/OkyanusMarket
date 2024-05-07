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
    public class DistrictManager : IDistrictService
    {
        IDistrictDal _DistrictDal;
        public DistrictManager(IDistrictDal DistrictDal)
        {
            _DistrictDal = DistrictDal;
        }

        public async Task TAddAsync(District entity)
        {
            await _DistrictDal.AddAsync(entity);
        }

        public async Task TAddRangeAsync(IEnumerable<District> entities)
        {
            await _DistrictDal.AddRangeAsync(entities);
        }

        public async Task<bool> TAnyAsync(Expression<Func<District, bool>> filter = null)
        {
            return await _DistrictDal.AnyAsync(filter);
        }

        public IQueryable<District> TAsQueryable()
        {
            return _DistrictDal.AsQueryable();
        }

        public async Task<int> TCountAsync(Expression<Func<District, bool>> filter = null)
        {
            return await _DistrictDal.CountAsync();
        }

        public async Task TDeleteAsync(District entity)
        {
            await _DistrictDal.DeleteAsync(entity);
        }

        public async Task TDeleteRangeAsync(IEnumerable<District> entities)
        {
            await _DistrictDal.DeleteRangeAsync(entities);
        }

        public async Task<District> TGetByIDAsync(int id)
        {
            return await _DistrictDal.GetByIDAsync(id);
        }

        public async Task<District> TGetFirstOrDefaultAsync(Expression<Func<District, bool>> filter)
        {
            return await _DistrictDal.GetFirstOrDefaultAsync(filter);
        }

        public async Task<List<District>> TGetListAllAsync()
        {
            return await _DistrictDal.GetListAllAsync();
        }

        public IQueryable<District> TInclude(Expression<Func<District, object>> navigationPropertyPath)
        {
            return _DistrictDal.Include(navigationPropertyPath);
        }

        public IQueryable<District> TOrderBy(Expression<Func<District, object>> keySelector)
        {
            return _DistrictDal.OrderBy(keySelector);
        }

        public IQueryable<District> TOrderByDescending(Expression<Func<District, object>> keySelector)
        {
            return _DistrictDal.OrderByDescending(keySelector);
        }

        public async Task TUpdateAsync(District entity)
        {
            await _DistrictDal.UpdateAsync(entity);
        }

        public async Task TUpdateRangeAsync(IEnumerable<District> entities)
        {
            await _DistrictDal.UpdateRangeAsync(entities);
        }

        public IQueryable<District> TWhere(Expression<Func<District, bool>> filter)
        {
            return _DistrictDal.Where(filter);
        }
    }
}
