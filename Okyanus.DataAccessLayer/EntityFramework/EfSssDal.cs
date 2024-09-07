using Okyanus.DataAccessLayer.Abstract;
using Okyanus.DataAccessLayer.Concrete;
using Okyanus.DataAccessLayer.Repository;
using Okyanus.EntityLayer.Entities;

namespace Okyanus.DataAccessLayer.EntityFramework
{
    public class EfSssDal : GenericRepository<Sss>, ISssDal
    {
        public EfSssDal(Context context) : base(context)
        {
        }
    }
}
