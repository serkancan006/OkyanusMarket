using OkyanusWebUI.Service;

namespace OkyanusWebUI.Models.OrderVM
{
    public class CreateOrderVM
    {
        public string? Description { get; set; }

        public int UserAdresID { get; set; }
        public string TelefonNo { get; set; }
        public string TeslimatYontemi { get; set; }
        public string TeslimatSaati { get; set; }
        public string AlternatifUrun { get; set; }

        public List<CartItem>? OrderItems { get; set; }
        public decimal? TotalPrice { get; set; }
        public bool HasReadAndUnderstood { get; set; }
    }
}
