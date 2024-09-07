using Okyanus.DataAccessLayer.Abstract;
using Okyanus.DataAccessLayer.Concrete;
using Okyanus.DataAccessLayer.Repository;
using Okyanus.EntityLayer.Entities;

namespace Okyanus.DataAccessLayer.EntityFramework
{
    public class EfDistrictDal : GenericRepository<District>, IDistrictDal
    {
        public EfDistrictDal(Context context) : base(context)
        {
        }
    }
}
