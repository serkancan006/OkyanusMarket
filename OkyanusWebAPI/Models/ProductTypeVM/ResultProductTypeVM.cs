namespace OkyanusWebAPI.Models.ProductTypeVM
{
    public class ResultProductTypeVM
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Status { get; set; }

        public string Birim { get; set; }
        public decimal IncreaseAmount { get; set; }
    }
}
