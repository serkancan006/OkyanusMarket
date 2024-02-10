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
    public class ContactMessageManager : IContactMessageService
    {
        IContactMessageDal _ContactMessageDal;
        public ContactMessageManager(IContactMessageDal ContactMessageDal)
        {
            _ContactMessageDal = ContactMessageDal;
        }

        public void TAdd(ContactMessage entity)
        {
            _ContactMessageDal.Add(entity);
        }

        public void TAddRange(IEnumerable<ContactMessage> entities)
        {
            _ContactMessageDal.AddRange(entities);
        }

        public bool TAny(Expression<Func<ContactMessage, bool>> filter = null, bool tracking = true)
        {
            return _ContactMessageDal.Any(filter, tracking);
        }

        public IQueryable<ContactMessage> TAsQueryable(bool tracking = true)
        {
            return _ContactMessageDal.AsQueryable(tracking);
        }

        public int TCount(Expression<Func<ContactMessage, bool>> filter = null, bool tracking = true)
        {
            return _ContactMessageDal.Count();
        }

        public void TDelete(ContactMessage entity)
        {
            _ContactMessageDal.Delete(entity);
        }

        public void TDeleteRange(IEnumerable<ContactMessage> entities)
        {
            _ContactMessageDal.DeleteRange(entities);
        }

        public ContactMessage TGetByID(int id)
        {
            return _ContactMessageDal.GetByID(id);
        }

        public ContactMessage TGetFirstOrDefault(Expression<Func<ContactMessage, bool>> filter, bool tracking = true)
        {
            return _ContactMessageDal.GetFirstOrDefault(filter, tracking);
        }

        public List<ContactMessage> TGetListAll(bool tracking = true)
        {
            return _ContactMessageDal.GetListAll();
        }

        public IQueryable<ContactMessage> TInclude(Expression<Func<ContactMessage, object>> navigationPropertyPath, bool tracking = true)
        {
            return _ContactMessageDal.Include(navigationPropertyPath, tracking);
        }

        public IQueryable<ContactMessage> TOrderBy(Expression<Func<ContactMessage, object>> keySelector, bool tracking = true)
        {
            return _ContactMessageDal.OrderBy(keySelector, tracking);
        }

        public IQueryable<ContactMessage> TOrderByDescending(Expression<Func<ContactMessage, object>> keySelector, bool tracking = true)
        {
            return _ContactMessageDal.OrderByDescending(keySelector, tracking);
        }

        public void TUpdate(ContactMessage entity)
        {
            _ContactMessageDal.Update(entity);
        }

        public void TUpdateRange(IEnumerable<ContactMessage> entities)
        {
            _ContactMessageDal.UpdateRange(entities);
        }

        public IQueryable<ContactMessage> TWhere(Expression<Func<ContactMessage, bool>> filter, bool tracking = true)
        {
            return _ContactMessageDal.Where(filter, tracking);
        }
    }
}
