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

        public void TAdd(Slider entity)
        {
            _SliderDal.Add(entity);
        }

        public void TAddRange(IEnumerable<Slider> entities)
        {
            _SliderDal.AddRange(entities);
        }

        public bool TAny(Expression<Func<Slider, bool>> filter = null, bool tracking = true)
        {
            return _SliderDal.Any(filter, tracking);
        }

        public IQueryable<Slider> TAsQueryable(bool tracking = true)
        {
            return _SliderDal.AsQueryable(tracking);
        }

        public int TCount(Expression<Func<Slider, bool>> filter = null, bool tracking = true)
        {
            return _SliderDal.Count();
        }

        public void TDelete(Slider entity)
        {
            _SliderDal.Delete(entity);
        }

        public void TDeleteRange(IEnumerable<Slider> entities)
        {
            _SliderDal.DeleteRange(entities);
        }

        public Slider TGetByID(int id)
        {
            return _SliderDal.GetByID(id);
        }

        public Slider TGetFirstOrDefault(Expression<Func<Slider, bool>> filter, bool tracking = true)
        {
            return _SliderDal.GetFirstOrDefault(filter, tracking);
        }

        public List<Slider> TGetListAll(bool tracking = true)
        {
            return _SliderDal.GetListAll();
        }

        public IQueryable<Slider> TInclude(Expression<Func<Slider, object>> navigationPropertyPath, bool tracking = true)
        {
            return _SliderDal.Include(navigationPropertyPath, tracking);
        }

        public IQueryable<Slider> TOrderBy(Expression<Func<Slider, object>> keySelector, bool tracking = true)
        {
            return _SliderDal.OrderBy(keySelector, tracking);
        }

        public IQueryable<Slider> TOrderByDescending(Expression<Func<Slider, object>> keySelector, bool tracking = true)
        {
            return _SliderDal.OrderByDescending(keySelector, tracking);
        }

        public void TUpdate(Slider entity)
        {
            _SliderDal.Update(entity);
        }

        public void TUpdateRange(IEnumerable<Slider> entities)
        {
            _SliderDal.UpdateRange(entities);
        }

        public IQueryable<Slider> TWhere(Expression<Func<Slider, bool>> filter, bool tracking = true)
        {
            return _SliderDal.Where(filter, tracking);
        }
    }
}
