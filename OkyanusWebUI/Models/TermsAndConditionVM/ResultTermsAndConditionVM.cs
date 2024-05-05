namespace OkyanusWebUI.Models.TermsAndConditionVM
{
    public class ResultTermsAndConditionVM
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Status { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
    }
}
