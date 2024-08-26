using OkyanusWebUI.Models.MarkaVM;
using OkyanusWebUI.Models.ProductTypeVM;
using OkyanusWebUI.Service;

namespace OkyanusWebUI.Models.ProductVM
{
    public class ResultProductVM
    {
        public string ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Status { get; set; }

        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountedPrice { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
        public decimal Stock { get; set; }
        public string AnaBarcode { get; set; }


        public string ANAGRUP { get; set; }
        public string? ALTGRUP1 { get; set; } = "0";
        public string? ALTGRUP2 { get; set; } = "0";
        public string? ALTGRUP3 { get; set; } = "0";


        public int MarkaID { get; set; }
        //public Marka Marka { get; set; }
        public ResultMarkaVM Marka { get; set; }
        public int ProductTypeID { get; set; }
        public ResultProductTypeVM ProductType { get; set; }
        //public ProductType ProductType { get; set; }


        //public List<OrderDetail> OrderDetails { get; set; }

        //public bool HasProductInBasket
        //{
        //    get
        //    {
        //        return new BasketService(new HttpContextAccessor()).hasProductInBasket(this.ID);
        //    }
        //}
    }
}
