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
    public class ContactManager : IContactService
    {
        IContactDal _ContactDal;
        public ContactManager(IContactDal ContactDal)
        {
            _ContactDal = ContactDal;
        }

        public async Task TAddAsync(Contact entity)
        {
            await _ContactDal.AddAsync(entity);
        }

        public async Task TAddRangeAsync(IEnumerable<Contact> entities)
        {
            await _ContactDal.AddRangeAsync(entities);
        }

        public async Task<bool> TAnyAsync(Expression<Func<Contact, bool>> filter = null)
        {
            return await _ContactDal.AnyAsync(filter);
        }

        public IQueryable<Contact> TAsQueryable()
        {
            return _ContactDal.AsQueryable();
        }

        public async Task<int> TCountAsync(Expression<Func<Contact, bool>> filter = null)
        {
            return await _ContactDal.CountAsync();
        }

        public async Task TDeleteAsync(Contact entity)
        {
            await _ContactDal.DeleteAsync(entity);
        }

        public async Task TDeleteRangeAsync(IEnumerable<Contact> entities)
        {
            await _ContactDal.DeleteRangeAsync(entities);
        }

        public async Task<Contact> TGetByIDAsync(int id)
        {
            return await _ContactDal.GetByIDAsync(id);
        }

        public async Task<Contact> TGetFirstOrDefaultAsync(Expression<Func<Contact, bool>> filter)
        {
            return await _ContactDal.GetFirstOrDefaultAsync(filter);
        }

        public async Task<List<Contact>> TGetListAllAsync()
        {
            return await _ContactDal.GetListAllAsync();
        }

        public IQueryable<Contact> TInclude(Expression<Func<Contact, object>> navigationPropertyPath)
        {
            return _ContactDal.Include(navigationPropertyPath);
        }

        public IQueryable<Contact> TOrderBy(Expression<Func<Contact, object>> keySelector)
        {
            return _ContactDal.OrderBy(keySelector);
        }

        public IQueryable<Contact> TOrderByDescending(Expression<Func<Contact, object>> keySelector)
        {
            return _ContactDal.OrderByDescending(keySelector);
        }

        public async Task TUpdateAsync(Contact entity)
        {
            await _ContactDal.UpdateAsync(entity);
        }

        public async Task TUpdateRangeAsync(IEnumerable<Contact> entities)
        {
            await _ContactDal.UpdateRangeAsync(entities);
        }

        public IQueryable<Contact> TWhere(Expression<Func<Contact, bool>> filter)
        {
            return _ContactDal.Where(filter);
        }
    }
}
