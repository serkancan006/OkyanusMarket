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
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;
        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void TAdd(About entity)
        {
            _aboutDal.Add(entity);
        }

        public void TAddRange(IEnumerable<About> entities)
        {
            _aboutDal.AddRange(entities);
        }

        public bool TAny(Expression<Func<About, bool>> filter = null, bool tracking = true)
        {
            return _aboutDal.Any(filter, tracking);
        }

        public IQueryable<About> TAsQueryable(bool tracking = true)
        {
            return _aboutDal.AsQueryable(tracking);
        }

        public int TCount(Expression<Func<About, bool>> filter = null, bool tracking = true)
        {
            return _aboutDal.Count();
        }

        public void TDelete(About entity)
        {
            _aboutDal.Delete(entity);
        }

        public void TDeleteRange(IEnumerable<About> entities)
        {
            _aboutDal.DeleteRange(entities);
        }

        public About TGetByID(int id)
        {
            return _aboutDal.GetByID(id);
        }

        public About TGetFirstOrDefault(Expression<Func<About, bool>> filter, bool tracking = true)
        {
            return _aboutDal.GetFirstOrDefault(filter, tracking);
        }

        public List<About> TGetListAll(bool tracking = true)
        {
            return _aboutDal.GetListAll();
        }

        public IQueryable<About> TInclude(Expression<Func<About, object>> navigationPropertyPath, bool tracking = true)
        {
            return _aboutDal.Include(navigationPropertyPath, tracking);
        }

        public IQueryable<About> TOrderBy(Expression<Func<About, object>> keySelector, bool tracking = true)
        {
            return _aboutDal.OrderBy(keySelector, tracking);
        }

        public IQueryable<About> TOrderByDescending(Expression<Func<About, object>> keySelector, bool tracking = true)
        {
            return _aboutDal.OrderByDescending(keySelector, tracking);
        }

        public void TUpdate(About entity)
        {
            _aboutDal.Update(entity);
        }

        public void TUpdateRange(IEnumerable<About> entities)
        {
            _aboutDal.UpdateRange(entities);
        }

        public IQueryable<About> TWhere(Expression<Func<About, bool>> filter, bool tracking = true)
        {
            return _aboutDal.Where(filter, tracking);
        }
    }
}
