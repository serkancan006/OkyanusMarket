using Okyanus.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okyanus.BusinessLayer.Abstract
{
    public interface IFavoriUrunlerService : IGenericService<FavoriUrunler>
    {
        Task<List<FavoriUrunler>> TGetFavoriUrunlersByUserAsync(int id);
    }
}
