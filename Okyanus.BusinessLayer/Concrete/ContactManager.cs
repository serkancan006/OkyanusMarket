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

        public void TAdd(Contact entity)
        {
            _ContactDal.Add(entity);
        }

        public void TAddRange(IEnumerable<Contact> entities)
        {
            _ContactDal.AddRange(entities);
        }

        public bool TAny(Expression<Func<Contact, bool>> filter = null, bool tracking = true)
        {
            return _ContactDal.Any(filter, tracking);
        }

        public IQueryable<Contact> TAsQueryable(bool tracking = true)
        {
            return _ContactDal.AsQueryable(tracking);
        }

        public int TCount(Expression<Func<Contact, bool>> filter = null, bool tracking = true)
        {
            return _ContactDal.Count();
        }

        public void TDelete(Contact entity)
        {
            _ContactDal.Delete(entity);
        }

        public void TDeleteRange(IEnumerable<Contact> entities)
        {
            _ContactDal.DeleteRange(entities);
        }

        public Contact TGetByID(int id)
        {
            return _ContactDal.GetByID(id);
        }

        public Contact TGetFirstOrDefault(Expression<Func<Contact, bool>> filter, bool tracking = true)
        {
            return _ContactDal.GetFirstOrDefault(filter, tracking);
        }

        public List<Contact> TGetListAll(bool tracking = true)
        {
            return _ContactDal.GetListAll();
        }

        public IQueryable<Contact> TInclude(Expression<Func<Contact, object>> navigationPropertyPath, bool tracking = true)
        {
            return _ContactDal.Include(navigationPropertyPath, tracking);
        }

        public IQueryable<Contact> TOrderBy(Expression<Func<Contact, object>> keySelector, bool tracking = true)
        {
            return _ContactDal.OrderBy(keySelector, tracking);
        }

        public IQueryable<Contact> TOrderByDescending(Expression<Func<Contact, object>> keySelector, bool tracking = true)
        {
            return _ContactDal.OrderByDescending(keySelector, tracking);
        }

        public void TUpdate(Contact entity)
        {
            _ContactDal.Update(entity);
        }

        public void TUpdateRange(IEnumerable<Contact> entities)
        {
            _ContactDal.UpdateRange(entities);
        }

        public IQueryable<Contact> TWhere(Expression<Func<Contact, bool>> filter, bool tracking = true)
        {
            return _ContactDal.Where(filter, tracking);
        }
    }
}
