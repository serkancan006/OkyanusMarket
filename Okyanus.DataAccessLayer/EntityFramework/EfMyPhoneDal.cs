using Okyanus.DataAccessLayer.Abstract;
using Okyanus.DataAccessLayer.Concrete;
using Okyanus.DataAccessLayer.Repository;
using Okyanus.EntityLayer.Entities;

namespace Okyanus.DataAccessLayer.EntityFramework
{
    public class EfMyPhoneDal : GenericRepository<MyPhone>, IMyPhoneDal
    {
        public EfMyPhoneDal(Context context) : base(context)
        {
        }
    }
}
