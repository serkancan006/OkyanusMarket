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
    public class SssManager : ISssService
    {
        ISssDal _SssDal;
        public SssManager(ISssDal SssDal)
        {
            _SssDal = SssDal;
        }

        public async Task TAddAsync(Sss entity)
        {
            await _SssDal.AddAsync(entity);
        }

        public async Task TAddRangeAsync(IEnumerable<Sss> entities)
        {
            await _SssDal.AddRangeAsync(entities);
        }

        public async Task<bool> TAnyAsync(Expression<Func<Sss, bool>> filter = null)
        {
            return await _SssDal.AnyAsync(filter);
        }

        public IQueryable<Sss> TAsQueryable()
        {
            return _SssDal.AsQueryable();
        }

        public async Task<int> TCountAsync(Expression<Func<Sss, bool>> filter = null)
        {
            return await _SssDal.CountAsync();
        }

        public async Task TDeleteAsync(Sss entity)
        {
            await _SssDal.DeleteAsync(entity);
        }

        public async Task TDeleteRangeAsync(IEnumerable<Sss> entities)
        {
            await _SssDal.DeleteRangeAsync(entities);
        }

        public async Task<Sss> TGetByIDAsync(int id)
        {
            return await _SssDal.GetByIDAsync(id);
        }

        public async Task<Sss> TGetFirstOrDefaultAsync(Expression<Func<Sss, bool>> filter)
        {
            return await _SssDal.GetFirstOrDefaultAsync(filter);
        }

        public async Task<List<Sss>> TGetListAllAsync()
        {
            return await _SssDal.GetListAllAsync();
        }

        public IQueryable<Sss> TInclude(Expression<Func<Sss, object>> navigationPropertyPath)
        {
            return _SssDal.Include(navigationPropertyPath);
        }

        public IQueryable<Sss> TOrderBy(Expression<Func<Sss, object>> keySelector)
        {
            return _SssDal.OrderBy(keySelector);
        }

        public IQueryable<Sss> TOrderByDescending(Expression<Func<Sss, object>> keySelector)
        {
            return _SssDal.OrderByDescending(keySelector);
        }

        public async Task TUpdateAsync(Sss entity)
        {
            await _SssDal.UpdateAsync(entity);
        }

        public async Task TUpdateRangeAsync(IEnumerable<Sss> entities)
        {
            await _SssDal.UpdateRangeAsync(entities);
        }

        public IQueryable<Sss> TWhere(Expression<Func<Sss, bool>> filter)
        {
            return _SssDal.Where(filter);
        }
    }
}
