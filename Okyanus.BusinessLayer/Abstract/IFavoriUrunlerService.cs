using Okyanus.EntityLayer.Entities;

namespace Okyanus.BusinessLayer.Abstract
{
    public interface IFavoriUrunlerService : IGenericService<FavoriUrunler>
    {
        Task<List<FavoriUrunler>> TGetFavoriUrunlersByUserAsync(int id);
    }
}
