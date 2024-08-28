using Okyanus.EntityLayer.Entities.identitiy;
using OkyanusWebAPI.Models.ProductVM;

namespace OkyanusWebAPI.Models.FavoriUrunlerVM
{
    public class ResultFavoriUrunlerVM
    {
        public int ID { get; set; }
        public string ProductID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Status { get; set; }
        
        public ResultProductVM Product { get; set; }
    }
}
