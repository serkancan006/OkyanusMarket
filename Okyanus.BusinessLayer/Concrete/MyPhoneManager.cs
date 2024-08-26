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
    public class MyPhoneManager : IMyPhoneService
    {
        IMyPhoneDal _MyPhoneDal;
        public MyPhoneManager(IMyPhoneDal MyPhoneDal)
        {
            _MyPhoneDal = MyPhoneDal;
        }

        public async Task TAddAsync(MyPhone entity)
        {
            await _MyPhoneDal.AddAsync(entity);
        }

        public async Task TAddRangeAsync(IEnumerable<MyPhone> entities)
        {
            await _MyPhoneDal.AddRangeAsync(entities);
        }

        public async Task<bool> TAnyAsync(Expression<Func<MyPhone, bool>> filter = null)
        {
            return await _MyPhoneDal.AnyAsync(filter);
        }

        public IQueryable<MyPhone> TAsQueryable()
        {
            return _MyPhoneDal.AsQueryable();
        }

        public async Task<int> TCountAsync(Expression<Func<MyPhone, bool>> filter = null)
        {
            return await _MyPhoneDal.CountAsync();
        }

        public async Task TDeleteAsync(MyPhone entity)
        {
            await _MyPhoneDal.DeleteAsync(entity);
        }

        public async Task TDeleteRangeAsync(IEnumerable<MyPhone> entities)
        {
            await _MyPhoneDal.DeleteRangeAsync(entities);
        }

        public async Task<MyPhone> TGetByIDAsync(int id)
        {
            return await _MyPhoneDal.GetByIDAsync(id);
        }

        public async Task<MyPhone> TGetByIDAsync(string id)
        {
            return await _MyPhoneDal.GetByIDAsync(id);
        }

        public async Task<MyPhone> TGetFirstOrDefaultAsync(Expression<Func<MyPhone, bool>> filter)
        {
            return await _MyPhoneDal.GetFirstOrDefaultAsync(filter);
        }

        public async Task<List<MyPhone>> TGetListAllAsync()
        {
            return await _MyPhoneDal.GetListAllAsync();
        }

        public IQueryable<MyPhone> TInclude(Expression<Func<MyPhone, object>> navigationPropertyPath)
        {
            return _MyPhoneDal.Include(navigationPropertyPath);
        }

        public IQueryable<MyPhone> TOrderBy(Expression<Func<MyPhone, object>> keySelector)
        {
            return _MyPhoneDal.OrderBy(keySelector);
        }

        public IQueryable<MyPhone> TOrderByDescending(Expression<Func<MyPhone, object>> keySelector)
        {
            return _MyPhoneDal.OrderByDescending(keySelector);
        }

        public async Task TUpdateAsync(MyPhone entity)
        {
            await _MyPhoneDal.UpdateAsync(entity);
        }

        public async Task TUpdateRangeAsync(IEnumerable<MyPhone> entities)
        {
            await _MyPhoneDal.UpdateRangeAsync(entities);
        }

        public IQueryable<MyPhone> TWhere(Expression<Func<MyPhone, bool>> filter)
        {
            return _MyPhoneDal.Where(filter);
        }
    }
}
