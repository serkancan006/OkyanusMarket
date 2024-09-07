using Okyanus.DataAccessLayer.Abstract;
using Okyanus.DataAccessLayer.Concrete;
using Okyanus.DataAccessLayer.Repository;
using Okyanus.EntityLayer.Entities;

namespace Okyanus.DataAccessLayer.EntityFramework
{
    public class EfUserAdresDal : GenericRepository<UserAdres>, IUserAdresDal
    {
        private readonly Context _context;
        public EfUserAdresDal(Context context) : base(context)
        {
            _context = context;
        }

    }
}
