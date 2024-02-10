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
    public class MyPhoneManager : IMyPhoneService
    {
        IMyPhoneDal _MyPhoneDal;
        public MyPhoneManager(IMyPhoneDal MyPhoneDal)
        {
            _MyPhoneDal = MyPhoneDal;
        }

        public void TAdd(MyPhone entity)
        {
            _MyPhoneDal.Add(entity);
        }

        public void TAddRange(IEnumerable<MyPhone> entities)
        {
            _MyPhoneDal.AddRange(entities);
        }

        public bool TAny(Expression<Func<MyPhone, bool>> filter = null, bool tracking = true)
        {
            return _MyPhoneDal.Any(filter, tracking);
        }

        public IQueryable<MyPhone> TAsQueryable(bool tracking = true)
        {
            return _MyPhoneDal.AsQueryable(tracking);
        }

        public int TCount(Expression<Func<MyPhone, bool>> filter = null, bool tracking = true)
        {
            return _MyPhoneDal.Count();
        }

        public void TDelete(MyPhone entity)
        {
            _MyPhoneDal.Delete(entity);
        }

        public void TDeleteRange(IEnumerable<MyPhone> entities)
        {
            _MyPhoneDal.DeleteRange(entities);
        }

        public MyPhone TGetByID(int id)
        {
            return _MyPhoneDal.GetByID(id);
        }

        public MyPhone TGetFirstOrDefault(Expression<Func<MyPhone, bool>> filter, bool tracking = true)
        {
            return _MyPhoneDal.GetFirstOrDefault(filter, tracking);
        }

        public List<MyPhone> TGetListAll(bool tracking = true)
        {
            return _MyPhoneDal.GetListAll();
        }

        public IQueryable<MyPhone> TInclude(Expression<Func<MyPhone, object>> navigationPropertyPath, bool tracking = true)
        {
            return _MyPhoneDal.Include(navigationPropertyPath, tracking);
        }

        public IQueryable<MyPhone> TOrderBy(Expression<Func<MyPhone, object>> keySelector, bool tracking = true)
        {
            return _MyPhoneDal.OrderBy(keySelector, tracking);
        }

        public IQueryable<MyPhone> TOrderByDescending(Expression<Func<MyPhone, object>> keySelector, bool tracking = true)
        {
            return _MyPhoneDal.OrderByDescending(keySelector, tracking);
        }

        public void TUpdate(MyPhone entity)
        {
            _MyPhoneDal.Update(entity);
        }

        public void TUpdateRange(IEnumerable<MyPhone> entities)
        {
            _MyPhoneDal.UpdateRange(entities);
        }

        public IQueryable<MyPhone> TWhere(Expression<Func<MyPhone, bool>> filter, bool tracking = true)
        {
            return _MyPhoneDal.Where(filter, tracking);
        }
    }
}
