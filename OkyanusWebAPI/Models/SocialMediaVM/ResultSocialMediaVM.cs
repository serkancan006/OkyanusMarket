﻿namespace OkyanusWebAPI.Models.SocialMediaVM
{
    public class ResultSocialMediaVM
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Status { get; set; }


        public string MediaName { get; set; }
        public string MediaUrl { get; set; }
    }
}
