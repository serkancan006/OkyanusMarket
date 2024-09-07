using Okyanus.DataAccessLayer.Abstract;
using Okyanus.DataAccessLayer.Concrete;
using Okyanus.DataAccessLayer.Repository;
using Okyanus.EntityLayer.Entities;

namespace Okyanus.DataAccessLayer.EntityFramework
{
    public class EfDeliveryTimeDal : GenericRepository<DeliveryTime>, IDeliveryTimeDal
    {
        public EfDeliveryTimeDal(Context context) : base(context)
        {
        }
    }
}
