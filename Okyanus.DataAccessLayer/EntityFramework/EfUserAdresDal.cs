using Okyanus.DataAccessLayer.Abstract;
using Okyanus.DataAccessLayer.Concrete;
using Okyanus.DataAccessLayer.Repository;
using Okyanus.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
