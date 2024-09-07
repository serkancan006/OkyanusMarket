using Okyanus.EntityLayer.Entities;

namespace Okyanus.DataAccessLayer.Abstract
{
    public interface IFavoriUrunlerDal : IGenericDal<FavoriUrunler>
    {
        Task<List<FavoriUrunler>> GetFavoriUrunlersByUserAsync(int id);
    }
}
