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
    public class TermsAndConditionManager : ITermsAndConditionService
    {
        ITermsAndConditionDal _TermsAndConditionDal;
        public TermsAndConditionManager(ITermsAndConditionDal TermsAndConditionDal)
        {
            _TermsAndConditionDal = TermsAndConditionDal;
        }

        public void TAdd(TermsAndCondition entity)
        {
            _TermsAndConditionDal.Add(entity);
        }

        public void TAddRange(IEnumerable<TermsAndCondition> entities)
        {
            _TermsAndConditionDal.AddRange(entities);
        }

        public bool TAny(Expression<Func<TermsAndCondition, bool>> filter = null, bool tracking = true)
        {
            return _TermsAndConditionDal.Any(filter, tracking);
        }

        public IQueryable<TermsAndCondition> TAsQueryable(bool tracking = true)
        {
            return _TermsAndConditionDal.AsQueryable(tracking);
        }

        public int TCount(Expression<Func<TermsAndCondition, bool>> filter = null, bool tracking = true)
        {
            return _TermsAndConditionDal.Count();
        }

        public void TDelete(TermsAndCondition entity)
        {
            _TermsAndConditionDal.Delete(entity);
        }

        public void TDeleteRange(IEnumerable<TermsAndCondition> entities)
        {
            _TermsAndConditionDal.DeleteRange(entities);
        }

        public TermsAndCondition TGetByID(int id)
        {
            return _TermsAndConditionDal.GetByID(id);
        }

        public TermsAndCondition TGetFirstOrDefault(Expression<Func<TermsAndCondition, bool>> filter, bool tracking = true)
        {
            return _TermsAndConditionDal.GetFirstOrDefault(filter, tracking);
        }

        public List<TermsAndCondition> TGetListAll(bool tracking = true)
        {
            return _TermsAndConditionDal.GetListAll();
        }

        public IQueryable<TermsAndCondition> TInclude(Expression<Func<TermsAndCondition, object>> navigationPropertyPath, bool tracking = true)
        {
            return _TermsAndConditionDal.Include(navigationPropertyPath, tracking);
        }

        public IQueryable<TermsAndCondition> TOrderBy(Expression<Func<TermsAndCondition, object>> keySelector, bool tracking = true)
        {
            return _TermsAndConditionDal.OrderBy(keySelector, tracking);
        }

        public IQueryable<TermsAndCondition> TOrderByDescending(Expression<Func<TermsAndCondition, object>> keySelector, bool tracking = true)
        {
            return _TermsAndConditionDal.OrderByDescending(keySelector, tracking);
        }

        public void TUpdate(TermsAndCondition entity)
        {
            _TermsAndConditionDal.Update(entity);
        }

        public void TUpdateRange(IEnumerable<TermsAndCondition> entities)
        {
            _TermsAndConditionDal.UpdateRange(entities);
        }

        public IQueryable<TermsAndCondition> TWhere(Expression<Func<TermsAndCondition, bool>> filter, bool tracking = true)
        {
            return _TermsAndConditionDal.Where(filter, tracking);
        }
    }
}
