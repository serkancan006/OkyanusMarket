using Microsoft.EntityFrameworkCore;
using Okyanus.DataAccessLayer.Abstract;
using Okyanus.DataAccessLayer.Concrete;
using Okyanus.DataAccessLayer.Repository;
using Okyanus.EntityLayer.Entities;

namespace Okyanus.DataAccessLayer.EntityFramework
{
    public class EfFavoriUrunlerDal : GenericRepository<FavoriUrunler>, IFavoriUrunlerDal
    {
        private readonly Context _context;
        public EfFavoriUrunlerDal(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<List<FavoriUrunler>> GetFavoriUrunlersByUserAsync(int id)
        {
            return await _context.FavoriUrunlers.Where(x => x.AppUserID == id).Select(f => new FavoriUrunler
            {
                ID = f.ID,
                ProductID = f.ProductID,
                Product = f.Product,
            }).ToListAsync();
        }

    }
}
