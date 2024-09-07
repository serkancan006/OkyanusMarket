using Okyanus.DataAccessLayer.Abstract;
using Okyanus.DataAccessLayer.Concrete;
using Okyanus.DataAccessLayer.Repository;
using Okyanus.EntityLayer.Entities;

namespace Okyanus.DataAccessLayer.EntityFramework
{
    public class EfOrderDetailDal : GenericRepository<OrderDetail>, IOrderDetailDal
    {
        public EfOrderDetailDal(Context context) : base(context)
        {
        }

    }
}
