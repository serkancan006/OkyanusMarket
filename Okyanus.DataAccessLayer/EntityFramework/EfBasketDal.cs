using Okyanus.DataAccessLayer.Abstract;
using Okyanus.DataAccessLayer.Concrete;
using Okyanus.DataAccessLayer.Repository;
using Okyanus.EntityLayer.Entities;

namespace Okyanus.DataAccessLayer.EntityFramework
{
    public class EfBasketDal : GenericRepository<Basket>, IBasketDal
    {
        public EfBasketDal(Context context) : base(context)
        {
        }

    }
}
