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
    public class BasketManager : IBasketService
    {
        IBasketDal _BasketDal;
        public BasketManager(IBasketDal BasketDal)
        {
            _BasketDal = BasketDal;
        }

        public async Task TAddAsync(Basket entity)
        {
            await _BasketDal.AddAsync(entity);
        }

        public async Task TAddRangeAsync(IEnumerable<Basket> entities)
        {
            await _BasketDal.AddRangeAsync(entities);
        }

        public async Task<bool> TAnyAsync(Expression<Func<Basket, bool>> filter = null)
        {
            return await _BasketDal.AnyAsync(filter);
        }

        public IQueryable<Basket> TAsQueryable()
        {
            return _BasketDal.AsQueryable();
        }

        public async Task<int> TCountAsync(Expression<Func<Basket, bool>> filter = null)
        {
            return await _BasketDal.CountAsync();
        }

        public async Task TDeleteAsync(Basket entity)
        {
            await _BasketDal.DeleteAsync(entity);
        }

        public async Task TDeleteRangeAsync(IEnumerable<Basket> entities)
        {
            await _BasketDal.DeleteRangeAsync(entities);
        }

        public async Task<Basket> TGetByIDAsync(int id)
        {
            return await _BasketDal.GetByIDAsync(id);
        }

        public async Task<Basket> TGetByIDAsync(string id)
        {
            return await _BasketDal.GetByIDAsync(id);
        }

        public async Task<Basket> TGetFirstOrDefaultAsync(Expression<Func<Basket, bool>> filter)
        {
            return await _BasketDal.GetFirstOrDefaultAsync(filter);
        }

        public async Task<List<Basket>> TGetListAllAsync()
        {
            return await _BasketDal.GetListAllAsync();
        }

        public IQueryable<Basket> TInclude(Expression<Func<Basket, object>> navigationPropertyPath)
        {
            return _BasketDal.Include(navigationPropertyPath);
        }

        public IQueryable<Basket> TOrderBy(Expression<Func<Basket, object>> keySelector)
        {
            return _BasketDal.OrderBy(keySelector);
        }

        public IQueryable<Basket> TOrderByDescending(Expression<Func<Basket, object>> keySelector)
        {
            return _BasketDal.OrderByDescending(keySelector);
        }

        public async Task TUpdateAsync(Basket entity)
        {
            await _BasketDal.UpdateAsync(entity);
        }

        public async Task TUpdateRangeAsync(IEnumerable<Basket> entities)
        {
            await _BasketDal.UpdateRangeAsync(entities);
        }

        public IQueryable<Basket> TWhere(Expression<Func<Basket, bool>> filter)
        {
            return _BasketDal.Where(filter);
        }
    }
}
