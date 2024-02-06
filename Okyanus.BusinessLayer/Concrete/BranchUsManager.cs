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
    public class BranchUsManager : IBranchUsService
    {
        IBranchUsDal _BranchUsDal;
        public BranchUsManager(IBranchUsDal BranchUsDal)
        {
            _BranchUsDal = BranchUsDal;
        }

        public void TAdd(BranchUs entity)
        {
            _BranchUsDal.Add(entity);
        }

        public void TAddRange(IEnumerable<BranchUs> entities)
        {
            _BranchUsDal.AddRange(entities);
        }

        public bool TAny(Expression<Func<BranchUs, bool>> filter = null, bool tracking = true)
        {
            return _BranchUsDal.Any(filter, tracking);
        }

        public IQueryable<BranchUs> TAsQueryable(bool tracking = true)
        {
            return _BranchUsDal.AsQueryable(tracking);
        }

        public int TCount(Expression<Func<BranchUs, bool>> filter = null, bool tracking = true)
        {
            return _BranchUsDal.Count();
        }

        public void TDelete(BranchUs entity)
        {
            _BranchUsDal.Delete(entity);
        }

        public void TDeleteRange(IEnumerable<BranchUs> entities)
        {
            _BranchUsDal.DeleteRange(entities);
        }

        public BranchUs TGetByID(int id)
        {
            return _BranchUsDal.GetByID(id);
        }

        public BranchUs TGetFirstOrDefault(Expression<Func<BranchUs, bool>> filter, bool tracking = true)
        {
            return _BranchUsDal.GetFirstOrDefault(filter, tracking);
        }

        public List<BranchUs> TGetListAll(bool tracking = true)
        {
            return _BranchUsDal.GetListAll();
        }

        public IQueryable<BranchUs> TInclude(Expression<Func<BranchUs, object>> navigationPropertyPath, bool tracking = true)
        {
            return _BranchUsDal.Include(navigationPropertyPath, tracking);
        }

        public IQueryable<BranchUs> TOrderBy(Expression<Func<BranchUs, object>> keySelector, bool tracking = true)
        {
            return _BranchUsDal.OrderBy(keySelector, tracking);
        }

        public IQueryable<BranchUs> TOrderByDescending(Expression<Func<BranchUs, object>> keySelector, bool tracking = true)
        {
            return _BranchUsDal.OrderByDescending(keySelector, tracking);
        }

        public void TUpdate(BranchUs entity)
        {
            _BranchUsDal.Update(entity);
        }

        public void TUpdateRange(IEnumerable<BranchUs> entities)
        {
            _BranchUsDal.UpdateRange(entities);
        }

        public IQueryable<BranchUs> TWhere(Expression<Func<BranchUs, bool>> filter, bool tracking = true)
        {
            return _BranchUsDal.Where(filter, tracking);
        }
    }
}
