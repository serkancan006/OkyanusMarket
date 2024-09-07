using Okyanus.DataAccessLayer.Abstract;
using Okyanus.DataAccessLayer.Concrete;
using Okyanus.DataAccessLayer.Repository;
using Okyanus.EntityLayer.Entities;

namespace Okyanus.DataAccessLayer.EntityFramework
{
    public class EfTermsAndConditionDal : GenericRepository<TermsAndCondition>, ITermsAndConditionDal
    {
        public EfTermsAndConditionDal(Context context) : base(context)
        {
        }
    }
}
