using Okyanus.DataAccessLayer.Abstract;
using Okyanus.DataAccessLayer.Concrete;
using Okyanus.DataAccessLayer.Repository;
using Okyanus.EntityLayer.Entities;

namespace Okyanus.DataAccessLayer.EntityFramework
{
    public class EfMarkaDal : GenericRepository<Marka>, IMarkaDal
    {
        public EfMarkaDal(Context context) : base(context)
        {
        }
    }
}
