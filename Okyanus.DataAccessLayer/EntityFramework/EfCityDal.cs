using Okyanus.DataAccessLayer.Abstract;
using Okyanus.DataAccessLayer.Concrete;
using Okyanus.DataAccessLayer.Repository;
using Okyanus.EntityLayer.Entities;

namespace Okyanus.DataAccessLayer.EntityFramework
{
    public class EfCityDal : GenericRepository<City>, ICityDal
    {
        public EfCityDal(Context context) : base(context)
        {
        }
    }
}
