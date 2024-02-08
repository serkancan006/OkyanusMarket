using Okyanus.BusinessLayer.Concrete.ExternalService;
using Okyanus.EntityLayer.Entities.identitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okyanus.BusinessLayer.Abstract.ExternalService
{
    public interface ICreateTokenService
    {
        TokenDto TokenCreate(AppUser user, int second = 60);
        TokenDto TokenCreateAdmin(AppUser user, int second = 60);
    }
}
