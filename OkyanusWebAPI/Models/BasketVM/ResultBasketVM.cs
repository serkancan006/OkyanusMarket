namespace OkyanusWebAPI.Models.BasketVM
{
    public class ResultBasketVM
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public string AboutDesc { get; set; }
        public string Misyon { get; set; }
        public string Vizyon { get; set; }
    }
}
