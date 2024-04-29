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

        public void TAdd(District entity)
        {
            _DistrictDal.Add(entity);
        }

        public void TAddRange(IEnumerable<District> entities)
        {
            _DistrictDal.AddRange(entities);
        }

        public bool TAny(Expression<Func<District, bool>> filter = null, bool tracking = true)
        {
            return _DistrictDal.Any(filter, tracking);
        }

        public IQueryable<District> TAsQueryable(bool tracking = true)
        {
            return _DistrictDal.AsQueryable(tracking);
        }

        public int TCount(Expression<Func<District, bool>> filter = null, bool tracking = true)
        {
            return _DistrictDal.Count();
        }

        public void TDelete(District entity)
        {
            _DistrictDal.Delete(entity);
        }

        public void TDeleteRange(IEnumerable<District> entities)
        {
            _DistrictDal.DeleteRange(entities);
        }

        public District TGetByID(int id)
        {
            return _DistrictDal.GetByID(id);
        }

        public District TGetFirstOrDefault(Expression<Func<District, bool>> filter, bool tracking = true)
        {
            return _DistrictDal.GetFirstOrDefault(filter, tracking);
        }

        public List<District> TGetListAll(bool tracking = true)
        {
            return _DistrictDal.GetListAll();
        }

        public IQueryable<District> TInclude(Expression<Func<District, object>> navigationPropertyPath, bool tracking = true)
        {
            return _DistrictDal.Include(navigationPropertyPath, tracking);
        }

        public IQueryable<District> TOrderBy(Expression<Func<District, object>> keySelector, bool tracking = true)
        {
            return _DistrictDal.OrderBy(keySelector, tracking);
        }

        public IQueryable<District> TOrderByDescending(Expression<Func<District, object>> keySelector, bool tracking = true)
        {
            return _DistrictDal.OrderByDescending(keySelector, tracking);
        }

        public void TUpdate(District entity)
        {
            _DistrictDal.Update(entity);
        }

        public void TUpdateRange(IEnumerable<District> entities)
        {
            _DistrictDal.UpdateRange(entities);
        }

        public IQueryable<District> TWhere(Expression<Func<District, bool>> filter, bool tracking = true)
        {
            return _DistrictDal.Where(filter, tracking);
        }
    }
}
