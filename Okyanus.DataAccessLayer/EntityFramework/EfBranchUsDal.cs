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
    public class EfBranchUsDal : GenericRepository<BranchUs>, IBranchUsDal
    {
        public EfBranchUsDal(Context context) : base(context)
        {
        }

    }
}
