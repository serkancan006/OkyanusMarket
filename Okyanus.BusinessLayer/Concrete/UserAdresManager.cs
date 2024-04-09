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
    public class UserAdresManager : IUserAdresService
    {
        IUserAdresDal _UserAdresDal;
        public UserAdresManager(IUserAdresDal UserAdresDal)
        {
            _UserAdresDal = UserAdresDal;
        }

        public void TAdd(UserAdres entity)
        {
            _UserAdresDal.Add(entity);
        }

        public void TAddRange(IEnumerable<UserAdres> entities)
        {
            _UserAdresDal.AddRange(entities);
        }

        public bool TAny(Expression<Func<UserAdres, bool>> filter = null, bool tracking = true)
        {
            return _UserAdresDal.Any(filter, tracking);
        }

        public IQueryable<UserAdres> TAsQueryable(bool tracking = true)
        {
            return _UserAdresDal.AsQueryable(tracking);
        }

        public int TCount(Expression<Func<UserAdres, bool>> filter = null, bool tracking = true)
        {
            return _UserAdresDal.Count();
        }

        public void TDelete(UserAdres entity)
        {
            _UserAdresDal.Delete(entity);
        }

        public void TDeleteRange(IEnumerable<UserAdres> entities)
        {
            _UserAdresDal.DeleteRange(entities);
        }

        public UserAdres TGetByID(int id)
        {
            return _UserAdresDal.GetByID(id);
        }

        public UserAdres TGetFirstOrDefault(Expression<Func<UserAdres, bool>> filter, bool tracking = true)
        {
            return _UserAdresDal.GetFirstOrDefault(filter, tracking);
        }

        public List<UserAdres> TGetListAll(bool tracking = true)
        {
            return _UserAdresDal.GetListAll();
        }

        public IQueryable<UserAdres> TInclude(Expression<Func<UserAdres, object>> navigationPropertyPath, bool tracking = true)
        {
            return _UserAdresDal.Include(navigationPropertyPath, tracking);
        }

        public IQueryable<UserAdres> TOrderBy(Expression<Func<UserAdres, object>> keySelector, bool tracking = true)
        {
            return _UserAdresDal.OrderBy(keySelector, tracking);
        }

        public IQueryable<UserAdres> TOrderByDescending(Expression<Func<UserAdres, object>> keySelector, bool tracking = true)
        {
            return _UserAdresDal.OrderByDescending(keySelector, tracking);
        }

        public void TUpdate(UserAdres entity)
        {
            _UserAdresDal.Update(entity);
        }

        public void TUpdateRange(IEnumerable<UserAdres> entities)
        {
            _UserAdresDal.UpdateRange(entities);
        }

        public IQueryable<UserAdres> TWhere(Expression<Func<UserAdres, bool>> filter, bool tracking = true)
        {
            return _UserAdresDal.Where(filter, tracking);
        }
    }
}
