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
    public class BasketManager : IBasketService
    {
        IBasketDal _BasketDal;
        public BasketManager(IBasketDal BasketDal)
        {
            _BasketDal = BasketDal;
        }

        public void TAdd(Basket entity)
        {
            _BasketDal.Add(entity);
        }

        public void TAddRange(IEnumerable<Basket> entities)
        {
            _BasketDal.AddRange(entities);
        }

        public bool TAny(Expression<Func<Basket, bool>> filter = null, bool tracking = true)
        {
            return _BasketDal.Any(filter, tracking);
        }

        public IQueryable<Basket> TAsQueryable(bool tracking = true)
        {
            return _BasketDal.AsQueryable(tracking);
        }

        public int TCount(Expression<Func<Basket, bool>> filter = null, bool tracking = true)
        {
            return _BasketDal.Count();
        }

        public void TDelete(Basket entity)
        {
            _BasketDal.Delete(entity);
        }

        public void TDeleteRange(IEnumerable<Basket> entities)
        {
            _BasketDal.DeleteRange(entities);
        }

        public Basket TGetByID(int id)
        {
            return _BasketDal.GetByID(id);
        }

        public Basket TGetFirstOrDefault(Expression<Func<Basket, bool>> filter, bool tracking = true)
        {
            return _BasketDal.GetFirstOrDefault(filter, tracking);
        }

        public List<Basket> TGetListAll(bool tracking = true)
        {
            return _BasketDal.GetListAll();
        }

        public IQueryable<Basket> TInclude(Expression<Func<Basket, object>> navigationPropertyPath, bool tracking = true)
        {
            return _BasketDal.Include(navigationPropertyPath, tracking);
        }

        public IQueryable<Basket> TOrderBy(Expression<Func<Basket, object>> keySelector, bool tracking = true)
        {
            return _BasketDal.OrderBy(keySelector, tracking);
        }

        public IQueryable<Basket> TOrderByDescending(Expression<Func<Basket, object>> keySelector, bool tracking = true)
        {
            return _BasketDal.OrderByDescending(keySelector, tracking);
        }

        public void TUpdate(Basket entity)
        {
            _BasketDal.Update(entity);
        }

        public void TUpdateRange(IEnumerable<Basket> entities)
        {
            _BasketDal.UpdateRange(entities);
        }

        public IQueryable<Basket> TWhere(Expression<Func<Basket, bool>> filter, bool tracking = true)
        {
            return _BasketDal.Where(filter, tracking);
        }
    }
}
