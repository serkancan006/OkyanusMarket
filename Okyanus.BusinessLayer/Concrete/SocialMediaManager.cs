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
    public class SocialMediaManager : ISocialMediaService
    {
        ISocialMediaDal _SocialMediaDal;
        public SocialMediaManager(ISocialMediaDal SocialMediaDal)
        {
            _SocialMediaDal = SocialMediaDal;
        }

        public async Task TAddAsync(SocialMedia entity)
        {
            await _SocialMediaDal.AddAsync(entity);
        }

        public async Task TAddRangeAsync(IEnumerable<SocialMedia> entities)
        {
            await _SocialMediaDal.AddRangeAsync(entities);
        }

        public async Task<bool> TAnyAsync(Expression<Func<SocialMedia, bool>> filter = null)
        {
            return await _SocialMediaDal.AnyAsync(filter);
        }

        public IQueryable<SocialMedia> TAsQueryable()
        {
            return _SocialMediaDal.AsQueryable();
        }

        public async Task<int> TCountAsync(Expression<Func<SocialMedia, bool>> filter = null)
        {
            return await _SocialMediaDal.CountAsync();
        }

        public async Task TDeleteAsync(SocialMedia entity)
        {
            await _SocialMediaDal.DeleteAsync(entity);
        }

        public async Task TDeleteRangeAsync(IEnumerable<SocialMedia> entities)
        {
            await _SocialMediaDal.DeleteRangeAsync(entities);
        }

        public async Task<SocialMedia> TGetByIDAsync(int id)
        {
            return await _SocialMediaDal.GetByIDAsync(id);
        }

        public async Task<SocialMedia> TGetByIDAsync(string id)
        {
            return await _SocialMediaDal.GetByIDAsync(id);
        }

        public async Task<SocialMedia> TGetFirstOrDefaultAsync(Expression<Func<SocialMedia, bool>> filter)
        {
            return await _SocialMediaDal.GetFirstOrDefaultAsync(filter);
        }

        public async Task<List<SocialMedia>> TGetListAllAsync()
        {
            return await _SocialMediaDal.GetListAllAsync();
        }

        public IQueryable<SocialMedia> TInclude(Expression<Func<SocialMedia, object>> navigationPropertyPath)
        {
            return _SocialMediaDal.Include(navigationPropertyPath);
        }

        public IQueryable<SocialMedia> TOrderBy(Expression<Func<SocialMedia, object>> keySelector)
        {
            return _SocialMediaDal.OrderBy(keySelector);
        }

        public IQueryable<SocialMedia> TOrderByDescending(Expression<Func<SocialMedia, object>> keySelector)
        {
            return _SocialMediaDal.OrderByDescending(keySelector);
        }

        public async Task TUpdateAsync(SocialMedia entity)
        {
            await _SocialMediaDal.UpdateAsync(entity);
        }

        public async Task TUpdateRangeAsync(IEnumerable<SocialMedia> entities)
        {
            await _SocialMediaDal.UpdateRangeAsync(entities);
        }

        public IQueryable<SocialMedia> TWhere(Expression<Func<SocialMedia, bool>> filter)
        {
            return _SocialMediaDal.Where(filter);
        }
    }
}
