namespace OkyanusWebAPI.Models.OrderVM
{
    public class UpdateOrderVM
    {
        public int ID { get; set; }

        public string Description { get; set; }
        public double TotalPrice { get; set; }
    }
}
