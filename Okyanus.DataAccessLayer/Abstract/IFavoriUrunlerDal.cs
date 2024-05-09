using Okyanus.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okyanus.DataAccessLayer.Abstract
{
    public interface IFavoriUrunlerDal : IGenericDal<FavoriUrunler>
    {
        Task<List<FavoriUrunler>> GetFavoriUrunlersByUserAsync(int id);
    }
}
