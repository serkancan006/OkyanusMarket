using OkyanusWebUI.Models.MarkaVM;
using OkyanusWebUI.Models.ProductVM;

namespace OkyanusWebUI.Areas.Admin.Models.AdminOrderVM
{
    public class ResultAdminOrderVM
    {
        public int id { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime updatedDate { get; set; }
        public bool status { get; set; }
        public string orderStatus { get; set; }
        public string? description { get; set; }
        public decimal totalPrice { get; set; }
        public string orderFirstName { get; set; }
        public string orderSurname { get; set; }
        public string orderMail { get; set; }
        public string orderPhone { get; set; }
        public string orderAdress { get; set; }
        public string orderApartman { get; set; }
        public string orderDaire { get; set; }
        public string orderKat { get; set; }
        public string orderSehir { get; set; }
        public string orderIlce { get; set; }
        public Orderdetail[] orderDetails { get; set; }
        public string teslimatYontemi { get; set; }
        public string teslimatSaati { get; set; }
        public string alternatifUrun { get; set; }
        //public string orderUserPhone { get; set; }

        public class Orderdetail
        {
            public int id { get; set; }
            public DateTime createdDate { get; set; }
            public DateTime updatedDate { get; set; }
            public bool status { get; set; }
            public decimal count { get; set; }
            public decimal unitPrice { get; set; }
            public decimal totalPrice { get; set; }
            public int productID { get; set; }
            public int orderID { get; set; }
            public Product product { get; set; }
        }

        public class Product
        {
            public int id { get; set; }
            public DateTime createdDate { get; set; }
            public DateTime updatedDate { get; set; }
            public bool status { get; set; }
            public string productName { get; set; }
            public string title { get; set; }
            public double price { get; set; }
            public double? discountedPrice { get; set; }
            public string? imageUrl { get; set; }
            public string? description { get; set; }
            //public Birim productType { get; set; }
            public int productTypeID { get; set; }
            public ResultProductVM productType { get; set; }
            public string anagrup { get; set; }
            public string altgruP1 { get; set; }
            public string altgruP2 { get; set; }
            public string altgruP3 { get; set; }
            public int markaID { get; set; }
            public ResultMarkaVM Marka { get; set; }
            public string anaBarcode { get; set; }
        }



    }
}
