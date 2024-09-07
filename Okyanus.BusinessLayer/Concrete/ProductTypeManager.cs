using Okyanus.BusinessLayer.Abstract;
using Okyanus.DataAccessLayer.Abstract;
using Okyanus.EntityLayer.Entities;
using System.Linq.Expressions;

namespace Okyanus.BusinessLayer.Concrete
{
    public class ProductTypeManager : IProductTypeService
    {
        IProductTypeDal _ProductTypeDal;
        public ProductTypeManager(IProductTypeDal ProductTypeDal)
        {
            _ProductTypeDal = ProductTypeDal;
        }

        public async Task TAddAsync(ProductType entity)
        {
            await _ProductTypeDal.AddAsync(entity);
        }

        public async Task TAddRangeAsync(IEnumerable<ProductType> entities)
        {
            await _ProductTypeDal.AddRangeAsync(entities);
        }

        public async Task<bool> TAnyAsync(Expression<Func<ProductType, bool>> filter = null)
        {
            return await _ProductTypeDal.AnyAsync(filter);
        }

        public IQueryable<ProductType> TAsQueryable()
        {
            return _ProductTypeDal.AsQueryable();
        }

        public async Task<int> TCountAsync(Expression<Func<ProductType, bool>> filter = null)
        {
            return await _ProductTypeDal.CountAsync();
        }

        public async Task TDeleteAsync(ProductType entity)
        {
            await _ProductTypeDal.DeleteAsync(entity);
        }

        public async Task TDeleteRangeAsync(IEnumerable<ProductType> entities)
        {
            await _ProductTypeDal.DeleteRangeAsync(entities);
        }

        public async Task<ProductType> TGetByIDAsync(int id)
        {
            return await _ProductTypeDal.GetByIDAsync(id);
        }

        public async Task<ProductType> TGetByIDAsync(string id)
        {
            return await _ProductTypeDal.GetByIDAsync(id);
        }

        public async Task<ProductType> TGetFirstOrDefaultAsync(Expression<Func<ProductType, bool>> filter)
        {
            return await _ProductTypeDal.GetFirstOrDefaultAsync(filter);
        }

        public async Task<List<ProductType>> TGetListAllAsync()
        {
            return await _ProductTypeDal.GetListAllAsync();
        }

        public IQueryable<ProductType> TInclude(Expression<Func<ProductType, object>> navigationPropertyPath)
        {
            return _ProductTypeDal.Include(navigationPropertyPath);
        }

        public IQueryable<ProductType> TOrderBy(Expression<Func<ProductType, object>> keySelector)
        {
            return _ProductTypeDal.OrderBy(keySelector);
        }

        public IQueryable<ProductType> TOrderByDescending(Expression<Func<ProductType, object>> keySelector)
        {
            return _ProductTypeDal.OrderByDescending(keySelector);
        }

        public async Task TUpdateAsync(ProductType entity)
        {
            await _ProductTypeDal.UpdateAsync(entity);
        }

        public async Task TUpdateRangeAsync(IEnumerable<ProductType> entities)
        {
            await _ProductTypeDal.UpdateRangeAsync(entities);
        }

        public IQueryable<ProductType> TWhere(Expression<Func<ProductType, bool>> filter)
        {
            return _ProductTypeDal.Where(filter);
        }
    }
}
