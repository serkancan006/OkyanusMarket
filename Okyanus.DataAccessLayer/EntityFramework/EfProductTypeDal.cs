using Okyanus.DataAccessLayer.Abstract;
using Okyanus.DataAccessLayer.Concrete;
using Okyanus.DataAccessLayer.Repository;
using Okyanus.EntityLayer.Entities;

namespace Okyanus.DataAccessLayer.EntityFramework
{
    public class EfProductTypeDal : GenericRepository<ProductType>, IProductTypeDal
    {
        public EfProductTypeDal(Context context) : base(context)
        {
        }
    }
}
