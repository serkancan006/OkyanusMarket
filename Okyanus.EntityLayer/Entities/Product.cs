using Okyanus.EntityLayer.Entities.Common;
using Okyanus.EntityLayer.Entities.identitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okyanus.EntityLayer.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public double Price { get; set; }
        public double? DiscountedPrice { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
        public int Stock { get; set; }
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
