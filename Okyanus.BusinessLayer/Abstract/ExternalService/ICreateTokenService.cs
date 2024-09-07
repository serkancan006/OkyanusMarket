using Okyanus.BusinessLayer.Concrete.ExternalService;
using Okyanus.EntityLayer.Entities.identitiy;

namespace Okyanus.BusinessLayer.Abstract.ExternalService
{
    public interface ICreateTokenService
    {
        TokenDto TokenCreate(AppUser user, int second = 60);
        TokenDto TokenCreateAdmin(AppUser user, int second = 60);
    }
}
