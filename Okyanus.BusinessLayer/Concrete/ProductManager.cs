using Okyanus.BusinessLayer.Abstract;
using Okyanus.DataAccessLayer.Abstract;
using Okyanus.EntityLayer.Entities;
using System.Linq.Expressions;

namespace Okyanus.BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _ProductDal;
        public ProductManager(IProductDal ProductDal)
        {
            _ProductDal = ProductDal;
        }

        public async Task TAddAsync(Product entity)
        {
            await _ProductDal.AddAsync(entity);
        }

        public async Task TAddRangeAsync(IEnumerable<Product> entities)
        {
            await _ProductDal.AddRangeAsync(entities);
        }

        public async Task<bool> TAnyAsync(Expression<Func<Product, bool>> filter = null)
        {
            return await _ProductDal.AnyAsync(filter);
        }

        public IQueryable<Product> TAsQueryable()
        {
            return _ProductDal.AsQueryable();
        }

        public async Task<int> TCountAsync(Expression<Func<Product, bool>> filter = null)
        {
            return await _ProductDal.CountAsync();
        }

        public async Task TDeleteAsync(Product entity)
        {
            await _ProductDal.DeleteAsync(entity);
        }

        public async Task TDeleteRangeAsync(IEnumerable<Product> entities)
        {
            await _ProductDal.DeleteRangeAsync(entities);
        }

        public async Task<Product> TGetByIDAsync(string id)
        {
            return await _ProductDal.GetByIDAsync(id);
        }

        public async Task<Product> TGetByIDAsync(int id)
        {
            return await _ProductDal.GetByIDAsync(id);
        }

        public async Task<Product> TGetFirstOrDefaultAsync(Expression<Func<Product, bool>> filter)
        {
            return await _ProductDal.GetFirstOrDefaultAsync(filter);
        }

        public async Task<List<Product>> TGetListAllAsync()
        {
            return await _ProductDal.GetListAllAsync();
        }

        public IQueryable<Product> TInclude(Expression<Func<Product, object>> navigationPropertyPath)
        {
            return _ProductDal.Include(navigationPropertyPath);
        }

        public IQueryable<Product> TOrderBy(Expression<Func<Product, object>> keySelector)
        {
            return _ProductDal.OrderBy(keySelector);
        }

        public IQueryable<Product> TOrderByDescending(Expression<Func<Product, object>> keySelector)
        {
            return _ProductDal.OrderByDescending(keySelector);
        }

        public async Task TUpdateAsync(Product entity)
        {
            await _ProductDal.UpdateAsync(entity);
        }

        public async Task TUpdateRangeAsync(IEnumerable<Product> entities)
        {
            await _ProductDal.UpdateRangeAsync(entities);
        }

        public IQueryable<Product> TWhere(Expression<Func<Product, bool>> filter)
        {
            return _ProductDal.Where(filter);
        }
    }
}
