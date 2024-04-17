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
    public class OrderManager : IOrderService
    {
        IOrderDal _OrderDal;
        public OrderManager(IOrderDal OrderDal)
        {
            _OrderDal = OrderDal;
        }

        public void TAdd(Order entity)
        {
            _OrderDal.Add(entity);
        }

        public void TAddRange(IEnumerable<Order> entities)
        {
            _OrderDal.AddRange(entities);
        }

        public bool TAny(Expression<Func<Order, bool>> filter = null, bool tracking = true)
        {
            return _OrderDal.Any(filter, tracking);
        }

        public IQueryable<Order> TAsQueryable(bool tracking = true)
        {
            return _OrderDal.AsQueryable(tracking);
        }

        public int TCount(Expression<Func<Order, bool>> filter = null, bool tracking = true)
        {
            return _OrderDal.Count();
        }

        public void TDelete(Order entity)
        {
            _OrderDal.Delete(entity);
        }

        public void TDeleteRange(IEnumerable<Order> entities)
        {
            _OrderDal.DeleteRange(entities);
        }

        public Order TGetByID(int id)
        {
            return _OrderDal.GetByID(id);
        }

        public Order TGetFirstOrDefault(Expression<Func<Order, bool>> filter, bool tracking = true)
        {
            return _OrderDal.GetFirstOrDefault(filter, tracking);
        }

        public List<Order> TGetListAll(bool tracking = true)
        {
            return _OrderDal.GetListAll();
        }

        public IQueryable<Order> TInclude(Expression<Func<Order, object>> navigationPropertyPath, bool tracking = true)
        {
            return _OrderDal.Include(navigationPropertyPath, tracking);
        }

        public IQueryable<Order> TOrderBy(Expression<Func<Order, object>> keySelector, bool tracking = true)
        {
            return _OrderDal.OrderBy(keySelector, tracking);
        }

        public IQueryable<Order> TOrderByDescending(Expression<Func<Order, object>> keySelector, bool tracking = true)
        {
            return _OrderDal.OrderByDescending(keySelector, tracking);
        }

        public void TUpdate(Order entity)
        {
            _OrderDal.Update(entity);
        }

        public void TUpdateRange(IEnumerable<Order> entities)
        {
            _OrderDal.UpdateRange(entities);
        }

        public IQueryable<Order> TWhere(Expression<Func<Order, bool>> filter, bool tracking = true)
        {
            return _OrderDal.Where(filter, tracking);
        }

        public void UpdateOrderStatus(int id, string orderStatus)
        {
            var order = _OrderDal.GetByID(id);
            order.OrderStatus = orderStatus;
            _OrderDal.Update(order);    
        }
    }
}
