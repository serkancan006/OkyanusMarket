using OkyanusWebUI.Models.ProductVM;

namespace OkyanusWebUI.Models.FavoriUrunlerVM
{
    public class ResultFavoriUrunlerVM
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Status { get; set; }

        public ResultProductVM Product { get; set; }
    }
}
