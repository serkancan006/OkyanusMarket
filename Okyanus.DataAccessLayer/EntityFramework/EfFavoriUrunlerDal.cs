using Microsoft.EntityFrameworkCore;
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
                Product = f.Product,
            }).ToListAsync();
        }

    }
}
