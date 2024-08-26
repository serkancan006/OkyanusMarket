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

        public async Task TAddAsync(OrderDetail entity)
        {
            await _OrderDetailDal.AddAsync(entity);
        }

        public async Task TAddRangeAsync(IEnumerable<OrderDetail> entities)
        {
            await _OrderDetailDal.AddRangeAsync(entities);
        }

        public async Task<bool> TAnyAsync(Expression<Func<OrderDetail, bool>> filter = null)
        {
            return await _OrderDetailDal.AnyAsync(filter);
        }

        public IQueryable<OrderDetail> TAsQueryable()
        {
            return _OrderDetailDal.AsQueryable();
        }

        public async Task<int> TCountAsync(Expression<Func<OrderDetail, bool>> filter = null)
        {
            return await _OrderDetailDal.CountAsync();
        }

        public async Task TDeleteAsync(OrderDetail entity)
        {
            await _OrderDetailDal.DeleteAsync(entity);
        }

        public async Task TDeleteRangeAsync(IEnumerable<OrderDetail> entities)
        {
            await _OrderDetailDal.DeleteRangeAsync(entities);
        }

        public async Task<OrderDetail> TGetByIDAsync(int id)
        {
            return await _OrderDetailDal.GetByIDAsync(id);
        }

        public async Task<OrderDetail> TGetByIDAsync(string id)
        {
            return await _OrderDetailDal.GetByIDAsync(id);
        }

        public async Task<OrderDetail> TGetFirstOrDefaultAsync(Expression<Func<OrderDetail, bool>> filter)
        {
            return await _OrderDetailDal.GetFirstOrDefaultAsync(filter);
        }

        public async Task<List<OrderDetail>> TGetListAllAsync()
        {
            return await _OrderDetailDal.GetListAllAsync();
        }

        public IQueryable<OrderDetail> TInclude(Expression<Func<OrderDetail, object>> navigationPropertyPath)
        {
            return _OrderDetailDal.Include(navigationPropertyPath);
        }

        public IQueryable<OrderDetail> TOrderBy(Expression<Func<OrderDetail, object>> keySelector)
        {
            return _OrderDetailDal.OrderBy(keySelector);
        }

        public IQueryable<OrderDetail> TOrderByDescending(Expression<Func<OrderDetail, object>> keySelector)
        {
            return _OrderDetailDal.OrderByDescending(keySelector);
        }

        public async Task TUpdateAsync(OrderDetail entity)
        {
            await _OrderDetailDal.UpdateAsync(entity);
        }

        public async Task TUpdateRangeAsync(IEnumerable<OrderDetail> entities)
        {
            await _OrderDetailDal.UpdateRangeAsync(entities);
        }

        public IQueryable<OrderDetail> TWhere(Expression<Func<OrderDetail, bool>> filter)
        {
            return _OrderDetailDal.Where(filter);
        }
    }
}
