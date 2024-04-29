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

        public void TAdd(City entity)
        {
            _CityDal.Add(entity);
        }

        public void TAddRange(IEnumerable<City> entities)
        {
            _CityDal.AddRange(entities);
        }

        public bool TAny(Expression<Func<City, bool>> filter = null, bool tracking = true)
        {
            return _CityDal.Any(filter, tracking);
        }

        public IQueryable<City> TAsQueryable(bool tracking = true)
        {
            return _CityDal.AsQueryable(tracking);
        }

        public int TCount(Expression<Func<City, bool>> filter = null, bool tracking = true)
        {
            return _CityDal.Count();
        }

        public void TDelete(City entity)
        {
            _CityDal.Delete(entity);
        }

        public void TDeleteRange(IEnumerable<City> entities)
        {
            _CityDal.DeleteRange(entities);
        }

        public City TGetByID(int id)
        {
            return _CityDal.GetByID(id);
        }

        public City TGetFirstOrDefault(Expression<Func<City, bool>> filter, bool tracking = true)
        {
            return _CityDal.GetFirstOrDefault(filter, tracking);
        }

        public List<City> TGetListAll(bool tracking = true)
        {
            return _CityDal.GetListAll();
        }

        public IQueryable<City> TInclude(Expression<Func<City, object>> navigationPropertyPath, bool tracking = true)
        {
            return _CityDal.Include(navigationPropertyPath, tracking);
        }

        public IQueryable<City> TOrderBy(Expression<Func<City, object>> keySelector, bool tracking = true)
        {
            return _CityDal.OrderBy(keySelector, tracking);
        }

        public IQueryable<City> TOrderByDescending(Expression<Func<City, object>> keySelector, bool tracking = true)
        {
            return _CityDal.OrderByDescending(keySelector, tracking);
        }

        public void TUpdate(City entity)
        {
            _CityDal.Update(entity);
        }

        public void TUpdateRange(IEnumerable<City> entities)
        {
            _CityDal.UpdateRange(entities);
        }

        public IQueryable<City> TWhere(Expression<Func<City, bool>> filter, bool tracking = true)
        {
            return _CityDal.Where(filter, tracking);
        }
    }
}
