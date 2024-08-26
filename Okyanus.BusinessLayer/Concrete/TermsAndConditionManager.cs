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
    public class TermsAndConditionManager : ITermsAndConditionService
    {
        ITermsAndConditionDal _TermsAndConditionDal;
        public TermsAndConditionManager(ITermsAndConditionDal TermsAndConditionDal)
        {
            _TermsAndConditionDal = TermsAndConditionDal;
        }

        public async Task TAddAsync(TermsAndCondition entity)
        {
            await _TermsAndConditionDal.AddAsync(entity);
        }

        public async Task TAddRangeAsync(IEnumerable<TermsAndCondition> entities)
        {
            await _TermsAndConditionDal.AddRangeAsync(entities);
        }

        public async Task<bool> TAnyAsync(Expression<Func<TermsAndCondition, bool>> filter = null)
        {
            return await _TermsAndConditionDal.AnyAsync(filter);
        }

        public IQueryable<TermsAndCondition> TAsQueryable()
        {
            return _TermsAndConditionDal.AsQueryable();
        }

        public async Task<int> TCountAsync(Expression<Func<TermsAndCondition, bool>> filter = null)
        {
            return await _TermsAndConditionDal.CountAsync();
        }

        public async Task TDeleteAsync(TermsAndCondition entity)
        {
            await _TermsAndConditionDal.DeleteAsync(entity);
        }

        public async Task TDeleteRangeAsync(IEnumerable<TermsAndCondition> entities)
        {
            await _TermsAndConditionDal.DeleteRangeAsync(entities);
        }

        public async Task<TermsAndCondition> TGetByIDAsync(int id)
        {
            return await _TermsAndConditionDal.GetByIDAsync(id);
        }

        public async Task<TermsAndCondition> TGetByIDAsync(string id)
        {
            return await _TermsAndConditionDal.GetByIDAsync(id);
        }

        public async Task<TermsAndCondition> TGetFirstOrDefaultAsync(Expression<Func<TermsAndCondition, bool>> filter)
        {
            return await _TermsAndConditionDal.GetFirstOrDefaultAsync(filter);
        }

        public async Task<List<TermsAndCondition>> TGetListAllAsync()
        {
            return await _TermsAndConditionDal.GetListAllAsync();
        }

        public IQueryable<TermsAndCondition> TInclude(Expression<Func<TermsAndCondition, object>> navigationPropertyPath)
        {
            return _TermsAndConditionDal.Include(navigationPropertyPath);
        }

        public IQueryable<TermsAndCondition> TOrderBy(Expression<Func<TermsAndCondition, object>> keySelector)
        {
            return _TermsAndConditionDal.OrderBy(keySelector);
        }

        public IQueryable<TermsAndCondition> TOrderByDescending(Expression<Func<TermsAndCondition, object>> keySelector)
        {
            return _TermsAndConditionDal.OrderByDescending(keySelector);
        }

        public async Task TUpdateAsync(TermsAndCondition entity)
        {
            await _TermsAndConditionDal.UpdateAsync(entity);
        }

        public async Task TUpdateRangeAsync(IEnumerable<TermsAndCondition> entities)
        {
            await _TermsAndConditionDal.UpdateRangeAsync(entities);
        }

        public IQueryable<TermsAndCondition> TWhere(Expression<Func<TermsAndCondition, bool>> filter)
        {
            return _TermsAndConditionDal.Where(filter);
        }
    }
}
