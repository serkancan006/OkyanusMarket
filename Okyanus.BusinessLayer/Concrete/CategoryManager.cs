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
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _CategoryDal;
        public CategoryManager(ICategoryDal CategoryDal)
        {
            _CategoryDal = CategoryDal;
        }

        public void TAdd(Category entity)
        {
            _CategoryDal.Add(entity);
        }

        public void TAddRange(IEnumerable<Category> entities)
        {
            _CategoryDal.AddRange(entities);
        }

        public bool TAny(Expression<Func<Category, bool>> filter = null, bool tracking = true)
        {
            return _CategoryDal.Any(filter, tracking);
        }

        public IQueryable<Category> TAsQueryable(bool tracking = true)
        {
            return _CategoryDal.AsQueryable(tracking);
        }

        public int TCount(Expression<Func<Category, bool>> filter = null, bool tracking = true)
        {
            return _CategoryDal.Count();
        }

        public void TDelete(Category entity)
        {
            _CategoryDal.Delete(entity);
        }

        public void TDeleteRange(IEnumerable<Category> entities)
        {
            _CategoryDal.DeleteRange(entities);
        }

        public Category TGetByID(int id)
        {
            return _CategoryDal.GetByID(id);
        }

        public Category TGetFirstOrDefault(Expression<Func<Category, bool>> filter, bool tracking = true)
        {
            return _CategoryDal.GetFirstOrDefault(filter, tracking);
        }

        public List<Category> TGetListAll(bool tracking = true)
        {
            return _CategoryDal.GetListAll();
        }

        public IQueryable<Category> TInclude(Expression<Func<Category, object>> navigationPropertyPath, bool tracking = true)
        {
            return _CategoryDal.Include(navigationPropertyPath, tracking);
        }

        public IQueryable<Category> TOrderBy(Expression<Func<Category, object>> keySelector, bool tracking = true)
        {
            return _CategoryDal.OrderBy(keySelector, tracking);
        }

        public IQueryable<Category> TOrderByDescending(Expression<Func<Category, object>> keySelector, bool tracking = true)
        {
            return _CategoryDal.OrderByDescending(keySelector, tracking);
        }

        public void TUpdate(Category entity)
        {
            _CategoryDal.Update(entity);
        }

        public void TUpdateRange(IEnumerable<Category> entities)
        {
            _CategoryDal.UpdateRange(entities);
        }

        public IQueryable<Category> TWhere(Expression<Func<Category, bool>> filter, bool tracking = true)
        {
            return _CategoryDal.Where(filter, tracking);
        }
    }
}
