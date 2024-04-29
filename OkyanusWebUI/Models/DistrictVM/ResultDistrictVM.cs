namespace OkyanusWebUI.Models.DistrictVM
{
    public class ResultDistrictVM
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Status { get; set; }

        public string DistrictName { get; set; }
        public int CityID { get; set; }
    }
}
