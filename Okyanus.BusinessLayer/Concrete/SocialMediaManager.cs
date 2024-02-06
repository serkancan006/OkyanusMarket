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
    public class SocialMediaManager : ISocialMediaService
    {
        ISocialMediaDal _SocialMediaDal;
        public SocialMediaManager(ISocialMediaDal SocialMediaDal)
        {
            _SocialMediaDal = SocialMediaDal;
        }

        public void TAdd(SocialMedia entity)
        {
            _SocialMediaDal.Add(entity);
        }

        public void TAddRange(IEnumerable<SocialMedia> entities)
        {
            _SocialMediaDal.AddRange(entities);
        }

        public bool TAny(Expression<Func<SocialMedia, bool>> filter = null, bool tracking = true)
        {
            return _SocialMediaDal.Any(filter, tracking);
        }

        public IQueryable<SocialMedia> TAsQueryable(bool tracking = true)
        {
            return _SocialMediaDal.AsQueryable(tracking);
        }

        public int TCount(Expression<Func<SocialMedia, bool>> filter = null, bool tracking = true)
        {
            return _SocialMediaDal.Count();
        }

        public void TDelete(SocialMedia entity)
        {
            _SocialMediaDal.Delete(entity);
        }

        public void TDeleteRange(IEnumerable<SocialMedia> entities)
        {
            _SocialMediaDal.DeleteRange(entities);
        }

        public SocialMedia TGetByID(int id)
        {
            return _SocialMediaDal.GetByID(id);
        }

        public SocialMedia TGetFirstOrDefault(Expression<Func<SocialMedia, bool>> filter, bool tracking = true)
        {
            return _SocialMediaDal.GetFirstOrDefault(filter, tracking);
        }

        public List<SocialMedia> TGetListAll(bool tracking = true)
        {
            return _SocialMediaDal.GetListAll();
        }

        public IQueryable<SocialMedia> TInclude(Expression<Func<SocialMedia, object>> navigationPropertyPath, bool tracking = true)
        {
            return _SocialMediaDal.Include(navigationPropertyPath, tracking);
        }

        public IQueryable<SocialMedia> TOrderBy(Expression<Func<SocialMedia, object>> keySelector, bool tracking = true)
        {
            return _SocialMediaDal.OrderBy(keySelector, tracking);
        }

        public IQueryable<SocialMedia> TOrderByDescending(Expression<Func<SocialMedia, object>> keySelector, bool tracking = true)
        {
            return _SocialMediaDal.OrderByDescending(keySelector, tracking);
        }

        public void TUpdate(SocialMedia entity)
        {
            _SocialMediaDal.Update(entity);
        }

        public void TUpdateRange(IEnumerable<SocialMedia> entities)
        {
            _SocialMediaDal.UpdateRange(entities);
        }

        public IQueryable<SocialMedia> TWhere(Expression<Func<SocialMedia, bool>> filter, bool tracking = true)
        {
            return _SocialMediaDal.Where(filter, tracking);
        }
    }
}
