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
    public class DeliveryTimeManager : IDeliveryTimeService
    {
        IDeliveryTimeDal _DeliveryTimeDal;
        public DeliveryTimeManager(IDeliveryTimeDal DeliveryTimeDal)
        {
            _DeliveryTimeDal = DeliveryTimeDal;
        }

        public void TAdd(DeliveryTime entity)
        {
            _DeliveryTimeDal.Add(entity);
        }

        public void TAddRange(IEnumerable<DeliveryTime> entities)
        {
            _DeliveryTimeDal.AddRange(entities);
        }

        public bool TAny(Expression<Func<DeliveryTime, bool>> filter = null, bool tracking = true)
        {
            return _DeliveryTimeDal.Any(filter, tracking);
        }

        public IQueryable<DeliveryTime> TAsQueryable(bool tracking = true)
        {
            return _DeliveryTimeDal.AsQueryable(tracking);
        }

        public int TCount(Expression<Func<DeliveryTime, bool>> filter = null, bool tracking = true)
        {
            return _DeliveryTimeDal.Count();
        }

        public void TDelete(DeliveryTime entity)
        {
            _DeliveryTimeDal.Delete(entity);
        }

        public void TDeleteRange(IEnumerable<DeliveryTime> entities)
        {
            _DeliveryTimeDal.DeleteRange(entities);
        }

        public DeliveryTime TGetByID(int id)
        {
            return _DeliveryTimeDal.GetByID(id);
        }

        public DeliveryTime TGetFirstOrDefault(Expression<Func<DeliveryTime, bool>> filter, bool tracking = true)
        {
            return _DeliveryTimeDal.GetFirstOrDefault(filter, tracking);
        }

        public List<DeliveryTime> TGetListAll(bool tracking = true)
        {
            return _DeliveryTimeDal.GetListAll();
        }

        public IQueryable<DeliveryTime> TInclude(Expression<Func<DeliveryTime, object>> navigationPropertyPath, bool tracking = true)
        {
            return _DeliveryTimeDal.Include(navigationPropertyPath, tracking);
        }

        public IQueryable<DeliveryTime> TOrderBy(Expression<Func<DeliveryTime, object>> keySelector, bool tracking = true)
        {
            return _DeliveryTimeDal.OrderBy(keySelector, tracking);
        }

        public IQueryable<DeliveryTime> TOrderByDescending(Expression<Func<DeliveryTime, object>> keySelector, bool tracking = true)
        {
            return _DeliveryTimeDal.OrderByDescending(keySelector, tracking);
        }

        public void TUpdate(DeliveryTime entity)
        {
            _DeliveryTimeDal.Update(entity);
        }

        public void TUpdateRange(IEnumerable<DeliveryTime> entities)
        {
            _DeliveryTimeDal.UpdateRange(entities);
        }

        public IQueryable<DeliveryTime> TWhere(Expression<Func<DeliveryTime, bool>> filter, bool tracking = true)
        {
            return _DeliveryTimeDal.Where(filter, tracking);
        }
    }
}
