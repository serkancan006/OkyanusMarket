﻿using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using OkyanusWebUI.Models.UserAdresVM;

namespace OkyanusWebUI.Service
{
    public class UserAdresService
    {
        private readonly CustomHttpClient _customHttpClient;
        public UserAdresService(CustomHttpClient customHttpClient)
        {
            _customHttpClient = customHttpClient;
        }

        public async Task<List<SelectListItem>> GetUserAdres()
        {
            var responseMessage = await _customHttpClient.Get(new() { Controller = "UserAdres" });
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultUserAdresVM>>(jsonData);
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            foreach (var value in values)
            {
                SelectListItem item = new SelectListItem
                {
                    Value = value.ID.ToString(),
                    Text = value.UserAdress
                };
                selectListItems.Add(item);
            }
            return selectListItems;
        }
    }
}
