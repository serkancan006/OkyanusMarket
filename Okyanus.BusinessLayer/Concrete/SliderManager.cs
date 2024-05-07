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
    public class SliderManager : ISliderService
    {
        ISliderDal _SliderDal;
        public SliderManager(ISliderDal SliderDal)
        {
            _SliderDal = SliderDal;
        }

        public async Task TAddAsync(Slider entity)
        {
            await _SliderDal.AddAsync(entity);
        }

        public async Task TAddRangeAsync(IEnumerable<Slider> entities)
        {
            await _SliderDal.AddRangeAsync(entities);
        }

        public async Task<bool> TAnyAsync(Expression<Func<Slider, bool>> filter = null)
        {
            return await _SliderDal.AnyAsync(filter);
        }

        public IQueryable<Slider> TAsQueryable()
        {
            return _SliderDal.AsQueryable();
        }

        public async Task<int> TCountAsync(Expression<Func<Slider, bool>> filter = null)
        {
            return await _SliderDal.CountAsync();
        }

        public async Task TDeleteAsync(Slider entity)
        {
            await _SliderDal.DeleteAsync(entity);
        }

        public async Task TDeleteRangeAsync(IEnumerable<Slider> entities)
        {
            await _SliderDal.DeleteRangeAsync(entities);
        }

        public async Task<Slider> TGetByIDAsync(int id)
        {
            return await _SliderDal.GetByIDAsync(id);
        }

        public async Task<Slider> TGetFirstOrDefaultAsync(Expression<Func<Slider, bool>> filter)
        {
            return await _SliderDal.GetFirstOrDefaultAsync(filter);
        }

        public async Task<List<Slider>> TGetListAllAsync()
        {
            return await _SliderDal.GetListAllAsync();
        }

        public IQueryable<Slider> TInclude(Expression<Func<Slider, object>> navigationPropertyPath)
        {
            return _SliderDal.Include(navigationPropertyPath);
        }

        public IQueryable<Slider> TOrderBy(Expression<Func<Slider, object>> keySelector)
        {
            return _SliderDal.OrderBy(keySelector);
        }

        public IQueryable<Slider> TOrderByDescending(Expression<Func<Slider, object>> keySelector)
        {
            return _SliderDal.OrderByDescending(keySelector);
        }

        public async Task TUpdateAsync(Slider entity)
        {
            await _SliderDal.UpdateAsync(entity);
        }

        public async Task TUpdateRangeAsync(IEnumerable<Slider> entities)
        {
            await _SliderDal.UpdateRangeAsync(entities);
        }

        public IQueryable<Slider> TWhere(Expression<Func<Slider, bool>> filter)
        {
            return _SliderDal.Where(filter);
        }
    }
}
