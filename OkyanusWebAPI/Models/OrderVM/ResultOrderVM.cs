namespace OkyanusWebAPI.Models.OrderVM
{
    public class ResultOrderVM
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public string Description { get; set; }
        public double TotalPrice { get; set; }
    }
}
