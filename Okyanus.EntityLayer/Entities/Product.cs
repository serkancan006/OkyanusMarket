using Okyanus.EntityLayer.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Okyanus.EntityLayer.Entities
{
    public class Product : BaseEntity
    {
        public string ID { get; set; }
        public string ProductName { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? DiscountedPrice { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Stock { get; set; }
        public string AnaBarcode { get; set; }


        public string ANAGRUP { get; set; }
        public string ALTGRUP1 { get; set; }
        public string ALTGRUP2 { get; set; }
        public string ALTGRUP3 { get; set; }
        public Group Group { get; set; }


        public int MarkaID { get; set; }
        public Marka Marka { get; set; }
        public int ProductTypeID { get; set; }
        public ProductType ProductType { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
        public virtual List<FavoriUrunler> FavoriUrunlers { get; set; }
    }
}
