using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Linq;

namespace OkyanusWebUI.Service
{
    public class BasketService
    {
        // Alışveriş sepeti öğeleri
        public List<CartItem> Items { get; set; }

        // Oturum anahtarı
        private const string SessionKey = "ShoppingCart";

        // HTTP isteği
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BasketService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            Items = new List<CartItem>();
            LoadCart();
        }

        // Sepeti yükle
        private void LoadCart()
        {
            string cartJson = _httpContextAccessor.HttpContext.Session.GetString(SessionKey);
            if (!string.IsNullOrEmpty(cartJson))
            {
                Items = JsonConvert.DeserializeObject<List<CartItem>>(cartJson);
            }
        }

        // Sepeti kaydet
        private void SaveCart()
        {
            string cartJson = JsonConvert.SerializeObject(Items);
            _httpContextAccessor.HttpContext.Session.SetString(SessionKey, cartJson);
        }

        // Sepete ürün ekle
        public void AddItem(CartItem newItem)
        {
            var existingItem = Items.FirstOrDefault(item => item.ProductId == newItem.ProductId);
            if (existingItem != null)
            {
                // Eğer sepette zaten varsa, miktarını 1 arttır
                existingItem.Quantity++;
            }
            else
            {
                // Eğer sepette yoksa, yeni öğe olarak ekle
                Items.Add(newItem);
            }
            SaveCart();
        }

        // Sepetten ürünü kaldır
        public void RemoveItem(int itemId)
        {
            var itemToRemove = Items.FirstOrDefault(item => item.ProductId == itemId);
            if (itemToRemove != null)
            {
                Items.Remove(itemToRemove);
                SaveCart();
            }
        }

        // Sepeti temizle
        public void ClearCart()
        {
            Items.Clear();
            SaveCart();
        }

        // Ürün miktarını güncelle
        public void UpdateQuantity(int itemId, int newQuantity)
        {
            var itemToUpdate = Items.FirstOrDefault(item => item.ProductId == itemId);
            if (itemToUpdate != null)
            {
                itemToUpdate.Quantity = newQuantity;
                SaveCart();
            }
        }

        // Sepetteki ürünlerin toplam fiyatını getir
        public double GetTotalPrice()
        {
            return Items.Sum(item => item.Price * item.Quantity);
        }

        // Sepetteki ürünlerin listesini döndür
        public List<CartItem> GetItems()
        {
            return Items;
        }

        public int GetTotalItems()
        {
            return Items.Count();
        }
    }

    public class CartItem
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice => Price * Quantity;
        //public double TotalPrice
        //{
        //    get
        //    {
        //        return Price * Quantity;
        //    }
        //}
    }

}
