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
    public class SssManager : ISssService
    {
        ISssDal _SssDal;
        public SssManager(ISssDal SssDal)
        {
            _SssDal = SssDal;
        }

        public void TAdd(Sss entity)
        {
            _SssDal.Add(entity);
        }

        public void TAddRange(IEnumerable<Sss> entities)
        {
            _SssDal.AddRange(entities);
        }

        public bool TAny(Expression<Func<Sss, bool>> filter = null, bool tracking = true)
        {
            return _SssDal.Any(filter, tracking);
        }

        public IQueryable<Sss> TAsQueryable(bool tracking = true)
        {
            return _SssDal.AsQueryable(tracking);
        }

        public int TCount(Expression<Func<Sss, bool>> filter = null, bool tracking = true)
        {
            return _SssDal.Count();
        }

        public void TDelete(Sss entity)
        {
            _SssDal.Delete(entity);
        }

        public void TDeleteRange(IEnumerable<Sss> entities)
        {
            _SssDal.DeleteRange(entities);
        }

        public Sss TGetByID(int id)
        {
            return _SssDal.GetByID(id);
        }

        public Sss TGetFirstOrDefault(Expression<Func<Sss, bool>> filter, bool tracking = true)
        {
            return _SssDal.GetFirstOrDefault(filter, tracking);
        }

        public List<Sss> TGetListAll(bool tracking = true)
        {
            return _SssDal.GetListAll();
        }

        public IQueryable<Sss> TInclude(Expression<Func<Sss, object>> navigationPropertyPath, bool tracking = true)
        {
            return _SssDal.Include(navigationPropertyPath, tracking);
        }

        public IQueryable<Sss> TOrderBy(Expression<Func<Sss, object>> keySelector, bool tracking = true)
        {
            return _SssDal.OrderBy(keySelector, tracking);
        }

        public IQueryable<Sss> TOrderByDescending(Expression<Func<Sss, object>> keySelector, bool tracking = true)
        {
            return _SssDal.OrderByDescending(keySelector, tracking);
        }

        public void TUpdate(Sss entity)
        {
            _SssDal.Update(entity);
        }

        public void TUpdateRange(IEnumerable<Sss> entities)
        {
            _SssDal.UpdateRange(entities);
        }

        public IQueryable<Sss> TWhere(Expression<Func<Sss, bool>> filter, bool tracking = true)
        {
            return _SssDal.Where(filter, tracking);
        }
    }
}
