using Okyanus.BusinessLayer.Abstract;
using Okyanus.DataAccessLayer.Abstract;
using Okyanus.EntityLayer.Entities;
using System.Linq.Expressions;

namespace Okyanus.BusinessLayer.Concrete
{
    public class DeliveryTimeManager : IDeliveryTimeService
    {
        IDeliveryTimeDal _DeliveryTimeDal;
        public DeliveryTimeManager(IDeliveryTimeDal DeliveryTimeDal)
        {
            _DeliveryTimeDal = DeliveryTimeDal;
        }

        public async Task TAddAsync(DeliveryTime entity)
        {
            await _DeliveryTimeDal.AddAsync(entity);
        }

        public async Task TAddRangeAsync(IEnumerable<DeliveryTime> entities)
        {
            await _DeliveryTimeDal.AddRangeAsync(entities);
        }

        public async Task<bool> TAnyAsync(Expression<Func<DeliveryTime, bool>> filter = null)
        {
            return await _DeliveryTimeDal.AnyAsync(filter);
        }

        public IQueryable<DeliveryTime> TAsQueryable()
        {
            return _DeliveryTimeDal.AsQueryable();
        }

        public async Task<int> TCountAsync(Expression<Func<DeliveryTime, bool>> filter = null)
        {
            return await _DeliveryTimeDal.CountAsync();
        }

        public async Task TDeleteAsync(DeliveryTime entity)
        {
            await _DeliveryTimeDal.DeleteAsync(entity);
        }

        public async Task TDeleteRangeAsync(IEnumerable<DeliveryTime> entities)
        {
            await _DeliveryTimeDal.DeleteRangeAsync(entities);
        }

        public async Task<DeliveryTime> TGetByIDAsync(int id)
        {
            return await _DeliveryTimeDal.GetByIDAsync(id);
        }

        public async Task<DeliveryTime> TGetByIDAsync(string id)
        {
            return await _DeliveryTimeDal.GetByIDAsync(id);
        }

        public async Task<DeliveryTime> TGetFirstOrDefaultAsync(Expression<Func<DeliveryTime, bool>> filter)
        {
            return await _DeliveryTimeDal.GetFirstOrDefaultAsync(filter);
        }

        public async Task<List<DeliveryTime>> TGetListAllAsync()
        {
            return await _DeliveryTimeDal.GetListAllAsync();
        }

        public IQueryable<DeliveryTime> TInclude(Expression<Func<DeliveryTime, object>> navigationPropertyPath)
        {
            return _DeliveryTimeDal.Include(navigationPropertyPath);
        }

        public IQueryable<DeliveryTime> TOrderBy(Expression<Func<DeliveryTime, object>> keySelector)
        {
            return _DeliveryTimeDal.OrderBy(keySelector);
        }

        public IQueryable<DeliveryTime> TOrderByDescending(Expression<Func<DeliveryTime, object>> keySelector)
        {
            return _DeliveryTimeDal.OrderByDescending(keySelector);
        }

        public async Task TUpdateAsync(DeliveryTime entity)
        {
            await _DeliveryTimeDal.UpdateAsync(entity);
        }

        public async Task TUpdateRangeAsync(IEnumerable<DeliveryTime> entities)
        {
            await _DeliveryTimeDal.UpdateRangeAsync(entities);
        }

        public IQueryable<DeliveryTime> TWhere(Expression<Func<DeliveryTime, bool>> filter)
        {
            return _DeliveryTimeDal.Where(filter);
        }
    }
}
