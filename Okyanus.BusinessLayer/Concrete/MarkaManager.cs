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
    public class MarkaManager : IMarkaService
    {
        IMarkaDal _MarkaDal;
        public MarkaManager(IMarkaDal MarkaDal)
        {
            _MarkaDal = MarkaDal;
        }

        public void TAdd(Marka entity)
        {
            _MarkaDal.Add(entity);
        }

        public void TAddRange(IEnumerable<Marka> entities)
        {
            _MarkaDal.AddRange(entities);
        }

        public bool TAny(Expression<Func<Marka, bool>> filter = null, bool tracking = true)
        {
            return _MarkaDal.Any(filter, tracking);
        }

        public IQueryable<Marka> TAsQueryable(bool tracking = true)
        {
            return _MarkaDal.AsQueryable(tracking);
        }

        public int TCount(Expression<Func<Marka, bool>> filter = null, bool tracking = true)
        {
            return _MarkaDal.Count();
        }

        public void TDelete(Marka entity)
        {
            _MarkaDal.Delete(entity);
        }

        public void TDeleteRange(IEnumerable<Marka> entities)
        {
            _MarkaDal.DeleteRange(entities);
        }

        public Marka TGetByID(int id)
        {
            return _MarkaDal.GetByID(id);
        }

        public Marka TGetFirstOrDefault(Expression<Func<Marka, bool>> filter, bool tracking = true)
        {
            return _MarkaDal.GetFirstOrDefault(filter, tracking);
        }

        public List<Marka> TGetListAll(bool tracking = true)
        {
            return _MarkaDal.GetListAll();
        }

        public IQueryable<Marka> TInclude(Expression<Func<Marka, object>> navigationPropertyPath, bool tracking = true)
        {
            return _MarkaDal.Include(navigationPropertyPath, tracking);
        }

        public IQueryable<Marka> TOrderBy(Expression<Func<Marka, object>> keySelector, bool tracking = true)
        {
            return _MarkaDal.OrderBy(keySelector, tracking);
        }

        public IQueryable<Marka> TOrderByDescending(Expression<Func<Marka, object>> keySelector, bool tracking = true)
        {
            return _MarkaDal.OrderByDescending(keySelector, tracking);
        }

        public void TUpdate(Marka entity)
        {
            _MarkaDal.Update(entity);
        }

        public void TUpdateRange(IEnumerable<Marka> entities)
        {
            _MarkaDal.UpdateRange(entities);
        }

        public IQueryable<Marka> TWhere(Expression<Func<Marka, bool>> filter, bool tracking = true)
        {
            return _MarkaDal.Where(filter, tracking);
        }
    }
}
