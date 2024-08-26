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

        public async Task TAddAsync(Order entity)
        {
            await _OrderDal.AddAsync(entity);
        }

        public async Task TAddRangeAsync(IEnumerable<Order> entities)
        {
            await _OrderDal.AddRangeAsync(entities);
        }

        public async Task<bool> TAnyAsync(Expression<Func<Order, bool>> filter = null)
        {
            return await _OrderDal.AnyAsync(filter);
        }

        public IQueryable<Order> TAsQueryable()
        {
            return _OrderDal.AsQueryable();
        }

        public async Task<int> TCountAsync(Expression<Func<Order, bool>> filter = null)
        {
            return await _OrderDal.CountAsync();
        }

        public async Task TDeleteAsync(Order entity)
        {
            await _OrderDal.DeleteAsync(entity);
        }

        public async Task TDeleteRangeAsync(IEnumerable<Order> entities)
        {
            await _OrderDal.DeleteRangeAsync(entities);
        }

        public async Task<Order> TGetByIDAsync(int id)
        {
            return await _OrderDal.GetByIDAsync(id);
        }

        public async Task<Order> TGetByIDAsync(string id)
        {
            return await _OrderDal.GetByIDAsync(id);
        }

        public async Task<Order> TGetFirstOrDefaultAsync(Expression<Func<Order, bool>> filter)
        {
            return await _OrderDal.GetFirstOrDefaultAsync(filter);
        }

        public async Task<List<Order>> TGetListAllAsync()
        {
            return await _OrderDal.GetListAllAsync();
        }

        public IQueryable<Order> TInclude(Expression<Func<Order, object>> navigationPropertyPath)
        {
            return _OrderDal.Include(navigationPropertyPath);
        }

        public IQueryable<Order> TOrderBy(Expression<Func<Order, object>> keySelector)
        {
            return _OrderDal.OrderBy(keySelector);
        }

        public IQueryable<Order> TOrderByDescending(Expression<Func<Order, object>> keySelector)
        {
            return _OrderDal.OrderByDescending(keySelector);
        }

        public async Task TUpdateAsync(Order entity)
        {
            await _OrderDal.UpdateAsync(entity);
        }

        public async Task TUpdateRangeAsync(IEnumerable<Order> entities)
        {
            await _OrderDal.UpdateRangeAsync(entities);
        }

        public IQueryable<Order> TWhere(Expression<Func<Order, bool>> filter)
        {
            return _OrderDal.Where(filter);
        }

        public async Task UpdateOrderStatusAsync(int id, string orderStatus)
        {
            var order = await _OrderDal.GetByIDAsync(id);
            order.OrderStatus = orderStatus;
            await _OrderDal.UpdateAsync(order);    
        }
    }
}
