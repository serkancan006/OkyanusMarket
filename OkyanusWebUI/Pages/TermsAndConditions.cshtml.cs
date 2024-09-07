using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using OkyanusWebUI.Models.TermsAndConditionVM;
using OkyanusWebUI.Service;

namespace OkyanusWebUI.Pages
{
    public class TermsAndConditionsModel : PageModel
    {
        private readonly CustomHttpClient _customHttpClient;
        public TermsAndConditionsModel(CustomHttpClient customHttpClient)
        {
            _customHttpClient = customHttpClient;
        }

        public IList<ResultTermsAndConditionVM> TermsAndConditions { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var responseMessage = await _customHttpClient.Get(new() { Controller = "TermsAndCondition" });
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                TermsAndConditions = JsonConvert.DeserializeObject<List<ResultTermsAndConditionVM>>(jsonData) ?? new List<ResultTermsAndConditionVM>();
                return Page();
            }
            return Page();
        }
    }
}
