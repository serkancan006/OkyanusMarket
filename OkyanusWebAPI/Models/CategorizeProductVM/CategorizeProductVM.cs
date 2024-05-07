using OkyanusWebAPI.Models.ProductVM;

namespace OkyanusWebAPI.Models.CategorizeProductVM
{
    public class CategorizeProductVM
    {
        public string KategoriAdı { get; set; }
        public List<Altkategoriler> AltKategoriler { get; set; }

        public class Altkategoriler
        {
            public string AltKategoriAdı { get; set; }
            public List<ResultProductVM> Ürünler { get; set; }
        }


    }
}
