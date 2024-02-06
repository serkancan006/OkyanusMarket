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
    public class OrderDetailManager : IOrderDetailService
    {
        IOrderDetailDal _OrderDetailDal;
        public OrderDetailManager(IOrderDetailDal OrderDetailDal)
        {
            _OrderDetailDal = OrderDetailDal;
        }

        public void TAdd(OrderDetail entity)
        {
            _OrderDetailDal.Add(entity);
        }

        public void TAddRange(IEnumerable<OrderDetail> entities)
        {
            _OrderDetailDal.AddRange(entities);
        }

        public bool TAny(Expression<Func<OrderDetail, bool>> filter = null, bool tracking = true)
        {
            return _OrderDetailDal.Any(filter, tracking);
        }

        public IQueryable<OrderDetail> TAsQueryable(bool tracking = true)
        {
            return _OrderDetailDal.AsQueryable(tracking);
        }

        public int TCount(Expression<Func<OrderDetail, bool>> filter = null, bool tracking = true)
        {
            return _OrderDetailDal.Count();
        }

        public void TDelete(OrderDetail entity)
        {
            _OrderDetailDal.Delete(entity);
        }

        public void TDeleteRange(IEnumerable<OrderDetail> entities)
        {
            _OrderDetailDal.DeleteRange(entities);
        }

        public OrderDetail TGetByID(int id)
        {
            return _OrderDetailDal.GetByID(id);
        }

        public OrderDetail TGetFirstOrDefault(Expression<Func<OrderDetail, bool>> filter, bool tracking = true)
        {
            return _OrderDetailDal.GetFirstOrDefault(filter, tracking);
        }

        public List<OrderDetail> TGetListAll(bool tracking = true)
        {
            return _OrderDetailDal.GetListAll();
        }

        public IQueryable<OrderDetail> TInclude(Expression<Func<OrderDetail, object>> navigationPropertyPath, bool tracking = true)
        {
            return _OrderDetailDal.Include(navigationPropertyPath, tracking);
        }

        public IQueryable<OrderDetail> TOrderBy(Expression<Func<OrderDetail, object>> keySelector, bool tracking = true)
        {
            return _OrderDetailDal.OrderBy(keySelector, tracking);
        }

        public IQueryable<OrderDetail> TOrderByDescending(Expression<Func<OrderDetail, object>> keySelector, bool tracking = true)
        {
            return _OrderDetailDal.OrderByDescending(keySelector, tracking);
        }

        public void TUpdate(OrderDetail entity)
        {
            _OrderDetailDal.Update(entity);
        }

        public void TUpdateRange(IEnumerable<OrderDetail> entities)
        {
            _OrderDetailDal.UpdateRange(entities);
        }

        public IQueryable<OrderDetail> TWhere(Expression<Func<OrderDetail, bool>> filter, bool tracking = true)
        {
            return _OrderDetailDal.Where(filter, tracking);
        }
    }
}
