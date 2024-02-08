using Okyanus.BusinessLayer.Concrete.ExternalService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okyanus.BusinessLayer.Abstract.ExternalService
{
    public interface ICreateTokenService
    {
        TokenDto TokenCreate(int second = 60);
        TokenDto TokenCreateAdmin(int second = 60);
    }
}
