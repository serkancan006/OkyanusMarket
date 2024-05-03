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
    public class ProductTypeManager : IProductTypeService
    {
        IProductTypeDal _ProductTypeDal;
        public ProductTypeManager(IProductTypeDal ProductTypeDal)
        {
            _ProductTypeDal = ProductTypeDal;
        }

        public void TAdd(ProductType entity)
        {
            _ProductTypeDal.Add(entity);
        }

        public void TAddRange(IEnumerable<ProductType> entities)
        {
            _ProductTypeDal.AddRange(entities);
        }

        public bool TAny(Expression<Func<ProductType, bool>> filter = null, bool tracking = true)
        {
            return _ProductTypeDal.Any(filter, tracking);
        }

        public IQueryable<ProductType> TAsQueryable(bool tracking = true)
        {
            return _ProductTypeDal.AsQueryable(tracking);
        }

        public int TCount(Expression<Func<ProductType, bool>> filter = null, bool tracking = true)
        {
            return _ProductTypeDal.Count();
        }

        public void TDelete(ProductType entity)
        {
            _ProductTypeDal.Delete(entity);
        }

        public void TDeleteRange(IEnumerable<ProductType> entities)
        {
            _ProductTypeDal.DeleteRange(entities);
        }

        public ProductType TGetByID(int id)
        {
            return _ProductTypeDal.GetByID(id);
        }

        public ProductType TGetFirstOrDefault(Expression<Func<ProductType, bool>> filter, bool tracking = true)
        {
            return _ProductTypeDal.GetFirstOrDefault(filter, tracking);
        }

        public List<ProductType> TGetListAll(bool tracking = true)
        {
            return _ProductTypeDal.GetListAll();
        }

        public IQueryable<ProductType> TInclude(Expression<Func<ProductType, object>> navigationPropertyPath, bool tracking = true)
        {
            return _ProductTypeDal.Include(navigationPropertyPath, tracking);
        }

        public IQueryable<ProductType> TOrderBy(Expression<Func<ProductType, object>> keySelector, bool tracking = true)
        {
            return _ProductTypeDal.OrderBy(keySelector, tracking);
        }

        public IQueryable<ProductType> TOrderByDescending(Expression<Func<ProductType, object>> keySelector, bool tracking = true)
        {
            return _ProductTypeDal.OrderByDescending(keySelector, tracking);
        }

        public void TUpdate(ProductType entity)
        {
            _ProductTypeDal.Update(entity);
        }

        public void TUpdateRange(IEnumerable<ProductType> entities)
        {
            _ProductTypeDal.UpdateRange(entities);
        }

        public IQueryable<ProductType> TWhere(Expression<Func<ProductType, bool>> filter, bool tracking = true)
        {
            return _ProductTypeDal.Where(filter, tracking);
        }
    }
}
