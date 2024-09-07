using Okyanus.BusinessLayer.Abstract;
using Okyanus.DataAccessLayer.Abstract;
using Okyanus.EntityLayer.Entities;
using System.Linq.Expressions;

namespace Okyanus.BusinessLayer.Concrete
{
    public class ContactMessageManager : IContactMessageService
    {
        IContactMessageDal _ContactMessageDal;
        public ContactMessageManager(IContactMessageDal ContactMessageDal)
        {
            _ContactMessageDal = ContactMessageDal;
        }

        public async Task TAddAsync(ContactMessage entity)
        {
            await _ContactMessageDal.AddAsync(entity);
        }

        public async Task TAddRangeAsync(IEnumerable<ContactMessage> entities)
        {
            await _ContactMessageDal.AddRangeAsync(entities);
        }

        public async Task<bool> TAnyAsync(Expression<Func<ContactMessage, bool>> filter = null)
        {
            return await _ContactMessageDal.AnyAsync(filter);
        }

        public IQueryable<ContactMessage> TAsQueryable()
        {
            return _ContactMessageDal.AsQueryable();
        }

        public async Task<int> TCountAsync(Expression<Func<ContactMessage, bool>> filter = null)
        {
            return await _ContactMessageDal.CountAsync();
        }

        public async Task TDeleteAsync(ContactMessage entity)
        {
            await _ContactMessageDal.DeleteAsync(entity);
        }

        public async Task TDeleteRangeAsync(IEnumerable<ContactMessage> entities)
        {
            await _ContactMessageDal.DeleteRangeAsync(entities);
        }

        public async Task<ContactMessage> TGetByIDAsync(int id)
        {
            return await _ContactMessageDal.GetByIDAsync(id);
        }

        public async Task<ContactMessage> TGetByIDAsync(string id)
        {
            return await _ContactMessageDal.GetByIDAsync(id);
        }

        public async Task<ContactMessage> TGetFirstOrDefaultAsync(Expression<Func<ContactMessage, bool>> filter)
        {
            return await _ContactMessageDal.GetFirstOrDefaultAsync(filter);
        }

        public async Task<List<ContactMessage>> TGetListAllAsync()
        {
            return await _ContactMessageDal.GetListAllAsync();
        }

        public IQueryable<ContactMessage> TInclude(Expression<Func<ContactMessage, object>> navigationPropertyPath)
        {
            return _ContactMessageDal.Include(navigationPropertyPath);
        }

        public IQueryable<ContactMessage> TOrderBy(Expression<Func<ContactMessage, object>> keySelector)
        {
            return _ContactMessageDal.OrderBy(keySelector);
        }

        public IQueryable<ContactMessage> TOrderByDescending(Expression<Func<ContactMessage, object>> keySelector)
        {
            return _ContactMessageDal.OrderByDescending(keySelector);
        }

        public async Task TUpdateAsync(ContactMessage entity)
        {
            await _ContactMessageDal.UpdateAsync(entity);
        }

        public async Task TUpdateRangeAsync(IEnumerable<ContactMessage> entities)
        {
            await _ContactMessageDal.UpdateRangeAsync(entities);
        }

        public IQueryable<ContactMessage> TWhere(Expression<Func<ContactMessage, bool>> filter)
        {
            return _ContactMessageDal.Where(filter);
        }
    }
}
