namespace Okyanus.EntityLayer.Entities.Common
{
    public class BaseEntity
    {
        virtual public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Status { get; set; }
    }
}
