using Okyanus.BusinessLayer.Abstract;
using Okyanus.DataAccessLayer.Abstract;
using Okyanus.EntityLayer.Entities;
using System.Linq.Expressions;

namespace Okyanus.BusinessLayer.Concrete
{
    public class MarkaManager : IMarkaService
    {
        IMarkaDal _MarkaDal;
        public MarkaManager(IMarkaDal MarkaDal)
        {
            _MarkaDal = MarkaDal;
        }

        public async Task TAddAsync(Marka entity)
        {
            await _MarkaDal.AddAsync(entity);
        }

        public async Task TAddRangeAsync(IEnumerable<Marka> entities)
        {
            await _MarkaDal.AddRangeAsync(entities);
        }

        public async Task<bool> TAnyAsync(Expression<Func<Marka, bool>> filter = null)
        {
            return await _MarkaDal.AnyAsync(filter);
        }

        public IQueryable<Marka> TAsQueryable()
        {
            return _MarkaDal.AsQueryable();
        }

        public async Task<int> TCountAsync(Expression<Func<Marka, bool>> filter = null)
        {
            return await _MarkaDal.CountAsync();
        }

        public async Task TDeleteAsync(Marka entity)
        {
            await _MarkaDal.DeleteAsync(entity);
        }

        public async Task TDeleteRangeAsync(IEnumerable<Marka> entities)
        {
            await _MarkaDal.DeleteRangeAsync(entities);
        }

        public async Task<Marka> TGetByIDAsync(int id)
        {
            return await _MarkaDal.GetByIDAsync(id);
        }

        public async Task<Marka> TGetByIDAsync(string id)
        {
            return await _MarkaDal.GetByIDAsync(id);
        }

        public async Task<Marka> TGetFirstOrDefaultAsync(Expression<Func<Marka, bool>> filter)
        {
            return await _MarkaDal.GetFirstOrDefaultAsync(filter);
        }

        public async Task<List<Marka>> TGetListAllAsync()
        {
            return await _MarkaDal.GetListAllAsync();
        }

        public IQueryable<Marka> TInclude(Expression<Func<Marka, object>> navigationPropertyPath)
        {
            return _MarkaDal.Include(navigationPropertyPath);
        }

        public IQueryable<Marka> TOrderBy(Expression<Func<Marka, object>> keySelector)
        {
            return _MarkaDal.OrderBy(keySelector);
        }

        public IQueryable<Marka> TOrderByDescending(Expression<Func<Marka, object>> keySelector)
        {
            return _MarkaDal.OrderByDescending(keySelector);
        }

        public async Task TUpdateAsync(Marka entity)
        {
            await _MarkaDal.UpdateAsync(entity);
        }

        public async Task TUpdateRangeAsync(IEnumerable<Marka> entities)
        {
            await _MarkaDal.UpdateRangeAsync(entities);
        }

        public IQueryable<Marka> TWhere(Expression<Func<Marka, bool>> filter)
        {
            return _MarkaDal.Where(filter);
        }
    }
}
