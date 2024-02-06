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
    public class ProductManager : IProductService
    {
        IProductDal _ProductDal;
        public ProductManager(IProductDal ProductDal)
        {
            _ProductDal = ProductDal;
        }

        public void TAdd(Product entity)
        {
            _ProductDal.Add(entity);
        }

        public void TAddRange(IEnumerable<Product> entities)
        {
            _ProductDal.AddRange(entities);
        }

        public bool TAny(Expression<Func<Product, bool>> filter = null, bool tracking = true)
        {
            return _ProductDal.Any(filter, tracking);
        }

        public IQueryable<Product> TAsQueryable(bool tracking = true)
        {
            return _ProductDal.AsQueryable(tracking);
        }

        public int TCount(Expression<Func<Product, bool>> filter = null, bool tracking = true)
        {
            return _ProductDal.Count();
        }

        public void TDelete(Product entity)
        {
            _ProductDal.Delete(entity);
        }

        public void TDeleteRange(IEnumerable<Product> entities)
        {
            _ProductDal.DeleteRange(entities);
        }

        public Product TGetByID(int id)
        {
            return _ProductDal.GetByID(id);
        }

        public Product TGetFirstOrDefault(Expression<Func<Product, bool>> filter, bool tracking = true)
        {
            return _ProductDal.GetFirstOrDefault(filter, tracking);
        }

        public List<Product> TGetListAll(bool tracking = true)
        {
            return _ProductDal.GetListAll();
        }

        public IQueryable<Product> TInclude(Expression<Func<Product, object>> navigationPropertyPath, bool tracking = true)
        {
            return _ProductDal.Include(navigationPropertyPath, tracking);
        }

        public IQueryable<Product> TOrderBy(Expression<Func<Product, object>> keySelector, bool tracking = true)
        {
            return _ProductDal.OrderBy(keySelector, tracking);
        }

        public IQueryable<Product> TOrderByDescending(Expression<Func<Product, object>> keySelector, bool tracking = true)
        {
            return _ProductDal.OrderByDescending(keySelector, tracking);
        }

        public void TUpdate(Product entity)
        {
            _ProductDal.Update(entity);
        }

        public void TUpdateRange(IEnumerable<Product> entities)
        {
            _ProductDal.UpdateRange(entities);
        }

        public IQueryable<Product> TWhere(Expression<Func<Product, bool>> filter, bool tracking = true)
        {
            return _ProductDal.Where(filter, tracking);
        }
    }
}
