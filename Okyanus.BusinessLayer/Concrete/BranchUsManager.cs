using Okyanus.BusinessLayer.Abstract;
using Okyanus.DataAccessLayer.Abstract;
using Okyanus.EntityLayer.Entities;
using System.Linq.Expressions;

namespace Okyanus.BusinessLayer.Concrete
{
    public class BranchUsManager : IBranchUsService
    {
        IBranchUsDal _BranchUsDal;
        public BranchUsManager(IBranchUsDal BranchUsDal)
        {
            _BranchUsDal = BranchUsDal;
        }

        public async Task TAddAsync(BranchUs entity)
        {
            await _BranchUsDal.AddAsync(entity);
        }

        public async Task TAddRangeAsync(IEnumerable<BranchUs> entities)
        {
            await _BranchUsDal.AddRangeAsync(entities);
        }

        public async Task<bool> TAnyAsync(Expression<Func<BranchUs, bool>> filter = null)
        {
            return await _BranchUsDal.AnyAsync(filter);
        }

        public IQueryable<BranchUs> TAsQueryable()
        {
            return _BranchUsDal.AsQueryable();
        }

        public async Task<int> TCountAsync(Expression<Func<BranchUs, bool>> filter = null)
        {
            return await _BranchUsDal.CountAsync();
        }

        public async Task TDeleteAsync(BranchUs entity)
        {
            await _BranchUsDal.DeleteAsync(entity);
        }

        public async Task TDeleteRangeAsync(IEnumerable<BranchUs> entities)
        {
            await _BranchUsDal.DeleteRangeAsync(entities);
        }

        public async Task<BranchUs> TGetByIDAsync(int id)
        {
            return await _BranchUsDal.GetByIDAsync(id);
        }

        public async Task<BranchUs> TGetByIDAsync(string id)
        {
            return await _BranchUsDal.GetByIDAsync(id);
        }

        public async Task<BranchUs> TGetFirstOrDefaultAsync(Expression<Func<BranchUs, bool>> filter)
        {
            return await _BranchUsDal.GetFirstOrDefaultAsync(filter);
        }

        public async Task<List<BranchUs>> TGetListAllAsync()
        {
            return await _BranchUsDal.GetListAllAsync();
        }

        public IQueryable<BranchUs> TInclude(Expression<Func<BranchUs, object>> navigationPropertyPath)
        {
            return _BranchUsDal.Include(navigationPropertyPath);
        }

        public IQueryable<BranchUs> TOrderBy(Expression<Func<BranchUs, object>> keySelector)
        {
            return _BranchUsDal.OrderBy(keySelector);
        }

        public IQueryable<BranchUs> TOrderByDescending(Expression<Func<BranchUs, object>> keySelector)
        {
            return _BranchUsDal.OrderByDescending(keySelector);
        }

        public async Task TUpdateAsync(BranchUs entity)
        {
            await _BranchUsDal.UpdateAsync(entity);
        }

        public async Task TUpdateRangeAsync(IEnumerable<BranchUs> entities)
        {
            await _BranchUsDal.UpdateRangeAsync(entities);
        }

        public IQueryable<BranchUs> TWhere(Expression<Func<BranchUs, bool>> filter)
        {
            return _BranchUsDal.Where(filter);
        }
    }
}
