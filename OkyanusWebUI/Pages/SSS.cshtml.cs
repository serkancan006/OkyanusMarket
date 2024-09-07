using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using OkyanusWebUI.Models.SssVM;
using OkyanusWebUI.Service;

namespace OkyanusWebUI.Pages
{
    public class SSSModel : PageModel
    {
        private readonly CustomHttpClient _customHttpClient;
        public SSSModel(CustomHttpClient customHttpClient)
        {
            _customHttpClient = customHttpClient;
        }

        public IList<ResultSssVM> SSS { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var responseMessage = await _customHttpClient.Get(new() { Controller = "SSS" });
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                SSS = JsonConvert.DeserializeObject<List<ResultSssVM>>(jsonData) ?? new List<ResultSssVM>();
                return Page();
            }
            return Page();
        }
    }
}
