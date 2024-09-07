using Okyanus.BusinessLayer.Abstract;
using Okyanus.DataAccessLayer.Abstract;
using Okyanus.EntityLayer.Entities;
using System.Linq.Expressions;

namespace Okyanus.BusinessLayer.Concrete
{
    public class GroupManager : IGroupService
    {
        IGroupDal _GroupDal;
        public GroupManager(IGroupDal GroupDal)
        {
            _GroupDal = GroupDal;
        }

        public async Task TAddAsync(Group entity)
        {
            await _GroupDal.AddAsync(entity);
        }

        public async Task TAddRangeAsync(IEnumerable<Group> entities)
        {
            await _GroupDal.AddRangeAsync(entities);
        }

        public async Task<bool> TAnyAsync(Expression<Func<Group, bool>> filter = null)
        {
            return await _GroupDal.AnyAsync(filter);
        }

        public IQueryable<Group> TAsQueryable()
        {
            return _GroupDal.AsQueryable();
        }

        public async Task<int> TCountAsync(Expression<Func<Group, bool>> filter = null)
        {
            return await _GroupDal.CountAsync();
        }

        public async Task TDeleteAsync(Group entity)
        {
            await _GroupDal.DeleteAsync(entity);
        }

        public async Task TDeleteRangeAsync(IEnumerable<Group> entities)
        {
            await _GroupDal.DeleteRangeAsync(entities);
        }

        public async Task<Group> TGetByIDAsync(int id)
        {
            return await _GroupDal.GetByIDAsync(id);
        }

        public async Task<Group> TGetByIDAsync(string id)
        {
            return await _GroupDal.GetByIDAsync(id);
        }

        public async Task<Group> TGetFirstOrDefaultAsync(Expression<Func<Group, bool>> filter)
        {
            return await _GroupDal.GetFirstOrDefaultAsync(filter);
        }

        public async Task<List<Group>> TGetListAllAsync()
        {
            return await _GroupDal.GetListAllAsync();
        }

        public IQueryable<Group> TInclude(Expression<Func<Group, object>> navigationPropertyPath)
        {
            return _GroupDal.Include(navigationPropertyPath);
        }

        public IQueryable<Group> TOrderBy(Expression<Func<Group, object>> keySelector)
        {
            return _GroupDal.OrderBy(keySelector);
        }

        public IQueryable<Group> TOrderByDescending(Expression<Func<Group, object>> keySelector)
        {
            return _GroupDal.OrderByDescending(keySelector);
        }

        public async Task TUpdateAsync(Group entity)
        {
            await _GroupDal.UpdateAsync(entity);
        }

        public async Task TUpdateRangeAsync(IEnumerable<Group> entities)
        {
            await _GroupDal.UpdateRangeAsync(entities);
        }

        public IQueryable<Group> TWhere(Expression<Func<Group, bool>> filter)
        {
            return _GroupDal.Where(filter);
        }
    }
}
