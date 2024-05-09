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
    public class FavoriUrunlerManager : IFavoriUrunlerService
    {
        IFavoriUrunlerDal _FavoriUrunlerDal;
        public FavoriUrunlerManager(IFavoriUrunlerDal FavoriUrunlerDal)
        {
            _FavoriUrunlerDal = FavoriUrunlerDal;
        }

        public async Task TAddAsync(FavoriUrunler entity)
        {
            await _FavoriUrunlerDal.AddAsync(entity);
        }

        public async Task TAddRangeAsync(IEnumerable<FavoriUrunler> entities)
        {
            await _FavoriUrunlerDal.AddRangeAsync(entities);
        }

        public async Task<bool> TAnyAsync(Expression<Func<FavoriUrunler, bool>> filter = null)
        {
            return await _FavoriUrunlerDal.AnyAsync(filter);
        }

        public IQueryable<FavoriUrunler> TAsQueryable()
        {
            return _FavoriUrunlerDal.AsQueryable();
        }

        public async Task<int> TCountAsync(Expression<Func<FavoriUrunler, bool>> filter = null)
        {
            return await _FavoriUrunlerDal.CountAsync();
        }

        public async Task TDeleteAsync(FavoriUrunler entity)
        {
            await _FavoriUrunlerDal.DeleteAsync(entity);
        }

        public async Task TDeleteRangeAsync(IEnumerable<FavoriUrunler> entities)
        {
            await _FavoriUrunlerDal.DeleteRangeAsync(entities);
        }

        public async Task<FavoriUrunler> TGetByIDAsync(int id)
        {
            return await _FavoriUrunlerDal.GetByIDAsync(id);
        }

        public async Task<List<FavoriUrunler>> TGetFavoriUrunlersByUserAsync(int id)
        {
            return await _FavoriUrunlerDal.GetFavoriUrunlersByUserAsync(id);
        }

        public async Task<FavoriUrunler> TGetFirstOrDefaultAsync(Expression<Func<FavoriUrunler, bool>> filter)
        {
            return await _FavoriUrunlerDal.GetFirstOrDefaultAsync(filter);
        }

        public async Task<List<FavoriUrunler>> TGetListAllAsync()
        {
            return await _FavoriUrunlerDal.GetListAllAsync();
        }

        public IQueryable<FavoriUrunler> TInclude(Expression<Func<FavoriUrunler, object>> navigationPropertyPath)
        {
            return _FavoriUrunlerDal.Include(navigationPropertyPath);
        }

        public IQueryable<FavoriUrunler> TOrderBy(Expression<Func<FavoriUrunler, object>> keySelector)
        {
            return _FavoriUrunlerDal.OrderBy(keySelector);
        }

        public IQueryable<FavoriUrunler> TOrderByDescending(Expression<Func<FavoriUrunler, object>> keySelector)
        {
            return _FavoriUrunlerDal.OrderByDescending(keySelector);
        }

        public async Task TUpdateAsync(FavoriUrunler entity)
        {
            await _FavoriUrunlerDal.UpdateAsync(entity);
        }

        public async Task TUpdateRangeAsync(IEnumerable<FavoriUrunler> entities)
        {
            await _FavoriUrunlerDal.UpdateRangeAsync(entities);
        }

        public IQueryable<FavoriUrunler> TWhere(Expression<Func<FavoriUrunler, bool>> filter)
        {
            return _FavoriUrunlerDal.Where(filter);
        }
    }
}
