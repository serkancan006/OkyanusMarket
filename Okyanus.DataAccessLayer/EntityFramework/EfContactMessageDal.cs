using Okyanus.DataAccessLayer.Abstract;
using Okyanus.DataAccessLayer.Concrete;
using Okyanus.DataAccessLayer.Repository;
using Okyanus.EntityLayer.Entities;

namespace Okyanus.DataAccessLayer.EntityFramework
{
    public class EfContactMessageDal : GenericRepository<ContactMessage>, IContactMessageDal
    {
        public EfContactMessageDal(Context context) : base(context)
        {
        }

    }
}
