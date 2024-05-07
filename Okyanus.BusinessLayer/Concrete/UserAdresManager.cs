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
    public class UserAdresManager : IUserAdresService
    {
        IUserAdresDal _UserAdresDal;
        public UserAdresManager(IUserAdresDal UserAdresDal)
        {
            _UserAdresDal = UserAdresDal;
        }

        public async Task TAddAsync(UserAdres entity)
        {
            await _UserAdresDal.AddAsync(entity);
        }

        public async Task TAddRangeAsync(IEnumerable<UserAdres> entities)
        {
            await _UserAdresDal.AddRangeAsync(entities);
        }

        public async Task<bool> TAnyAsync(Expression<Func<UserAdres, bool>> filter = null)
        {
            return await _UserAdresDal.AnyAsync(filter);
        }

        public IQueryable<UserAdres> TAsQueryable()
        {
            return _UserAdresDal.AsQueryable();
        }

        public async Task<int> TCountAsync(Expression<Func<UserAdres, bool>> filter = null)
        {
            return await _UserAdresDal.CountAsync();
        }

        public async Task TDeleteAsync(UserAdres entity)
        {
            await _UserAdresDal.DeleteAsync(entity);
        }

        public async Task TDeleteRangeAsync(IEnumerable<UserAdres> entities)
        {
            await _UserAdresDal.DeleteRangeAsync(entities);
        }

        public async Task<UserAdres> TGetByIDAsync(int id)
        {
            return await _UserAdresDal.GetByIDAsync(id);
        }

        public async Task<UserAdres> TGetFirstOrDefaultAsync(Expression<Func<UserAdres, bool>> filter)
        {
            return await _UserAdresDal.GetFirstOrDefaultAsync(filter);
        }

        public async Task<List<UserAdres>> TGetListAllAsync()
        {
            return await _UserAdresDal.GetListAllAsync();
        }

        public IQueryable<UserAdres> TInclude(Expression<Func<UserAdres, object>> navigationPropertyPath)
        {
            return _UserAdresDal.Include(navigationPropertyPath);
        }

        public IQueryable<UserAdres> TOrderBy(Expression<Func<UserAdres, object>> keySelector)
        {
            return _UserAdresDal.OrderBy(keySelector);
        }

        public IQueryable<UserAdres> TOrderByDescending(Expression<Func<UserAdres, object>> keySelector)
        {
            return _UserAdresDal.OrderByDescending(keySelector);
        }

        public async Task TUpdateAsync(UserAdres entity)
        {
            await _UserAdresDal.UpdateAsync(entity);
        }

        public async Task TUpdateRangeAsync(IEnumerable<UserAdres> entities)
        {
            await _UserAdresDal.UpdateRangeAsync(entities);
        }

        public IQueryable<UserAdres> TWhere(Expression<Func<UserAdres, bool>> filter)
        {
            return _UserAdresDal.Where(filter);
        }
    }
}
