using Okyanus.EntityLayer.Entities;
using OkyanusWebAPI.Models.DistrictVM;

namespace OkyanusWebAPI.Models.CityVM
{
    public class ResultCityVM
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Status { get; set; }

        public string CityName { get; set; }
        public List<ResultDistrictVM> Districts { get; set; }
    }
}
