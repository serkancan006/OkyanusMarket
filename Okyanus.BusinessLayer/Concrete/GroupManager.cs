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
    public class GroupManager : IGroupService
    {
        IGroupDal _CategoryDal;
        public GroupManager(IGroupDal CategoryDal)
        {
            _CategoryDal = CategoryDal;
        }

        public void TAdd(Group entity)
        {
            _CategoryDal.Add(entity);
        }

        public void TAddRange(IEnumerable<Group> entities)
        {
            _CategoryDal.AddRange(entities);
        }

        public bool TAny(Expression<Func<Group, bool>> filter = null, bool tracking = true)
        {
            return _CategoryDal.Any(filter, tracking);
        }

        public IQueryable<Group> TAsQueryable(bool tracking = true)
        {
            return _CategoryDal.AsQueryable(tracking);
        }

        public int TCount(Expression<Func<Group, bool>> filter = null, bool tracking = true)
        {
            return _CategoryDal.Count();
        }

        public void TDelete(Group entity)
        {
            _CategoryDal.Delete(entity);
        }

        public void TDeleteRange(IEnumerable<Group> entities)
        {
            _CategoryDal.DeleteRange(entities);
        }

        public Group TGetByID(int id)
        {
            return _CategoryDal.GetByID(id);
        }

        public Group TGetFirstOrDefault(Expression<Func<Group, bool>> filter, bool tracking = true)
        {
            return _CategoryDal.GetFirstOrDefault(filter, tracking);
        }

        public List<Group> TGetListAll(bool tracking = true)
        {
            return _CategoryDal.GetListAll();
        }

        public IQueryable<Group> TInclude(Expression<Func<Group, object>> navigationPropertyPath, bool tracking = true)
        {
            return _CategoryDal.Include(navigationPropertyPath, tracking);
        }

        public IQueryable<Group> TOrderBy(Expression<Func<Group, object>> keySelector, bool tracking = true)
        {
            return _CategoryDal.OrderBy(keySelector, tracking);
        }

        public IQueryable<Group> TOrderByDescending(Expression<Func<Group, object>> keySelector, bool tracking = true)
        {
            return _CategoryDal.OrderByDescending(keySelector, tracking);
        }

        public void TUpdate(Group entity)
        {
            _CategoryDal.Update(entity);
        }

        public void TUpdateRange(IEnumerable<Group> entities)
        {
            _CategoryDal.UpdateRange(entities);
        }

        public IQueryable<Group> TWhere(Expression<Func<Group, bool>> filter, bool tracking = true)
        {
            return _CategoryDal.Where(filter, tracking);
        }
    }
}
