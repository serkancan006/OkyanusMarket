using Okyanus.DataAccessLayer.Abstract;
using Okyanus.DataAccessLayer.Concrete;
using Okyanus.DataAccessLayer.Repository;
using Okyanus.EntityLayer.Entities;

namespace Okyanus.DataAccessLayer.EntityFramework
{
    public class EfGroupDal : GenericRepository<Group>, IGroupDal
    {
        public EfGroupDal(Context context) : base(context)
        {
        }

    }
}
