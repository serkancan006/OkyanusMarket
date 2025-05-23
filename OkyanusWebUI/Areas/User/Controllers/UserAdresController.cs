﻿using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkyanusWebUI.Models.UserAdresVM;
using OkyanusWebUI.Service;

namespace OkyanusWebUI.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class UserAdresController : Controller
    {
        private readonly CustomHttpClient _customHttpClient;
        private readonly INotyfService _notyfService;
        private readonly CityService _cityService;
        public UserAdresController(CustomHttpClient customHttpClient, INotyfService notyfService, CityService cityService)
        {
            _customHttpClient = customHttpClient;
            _notyfService = notyfService;
            _cityService = cityService;
        }

        public async Task<IActionResult> Index()
        {
            var responseMessage = await _customHttpClient.Get(new() { Controller = "UserAdres" });
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultUserAdresVM>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddUserAdres()
        {
            var city = await _cityService.GetCityList();
            if (city.Count > 0)
            {
                ViewBag.UserSehirItems = city;
                ViewBag.UserIlceItems = await _cityService.GetDistrictListByCity(int.Parse(city[0].Value));
            }
            return View();
        }

        public async Task<JsonResult> GetDistricts(int cityId)
        {
            var selectListItems = await _cityService.GetDistrictListByCity(cityId);
            return Json(selectListItems);
        }

        [HttpPost]
        public async Task<IActionResult> AddUserAdres(CreateUserAdresVM model)
        {
            var city = await _cityService.GetCityList();
            if (city.Count > 0)
            {
                ViewBag.UserSehirItems = city;
                ViewBag.UserIlceItems = await _cityService.GetDistrictListByCity(int.Parse(city[0].Value));
            }
            var responseMessage = await _customHttpClient.Post<CreateUserAdresVM>(new() { Controller = "UserAdres" }, model);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteUserAdres(int id)
        {
            var responseMessage = await _customHttpClient.Delete(new() { Controller = "UserAdres" }, id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateUserAdres(int id)
        {
            var city = await _cityService.GetCityList();
            ViewBag.UserSehirItems = city;
            ViewBag.UserIlceItems = await _cityService.GetDistrictListByCity(int.Parse(city[0].Value));

            var responseMessage = await _customHttpClient.Get(new() { Controller = "UserAdres" }, id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateUserAdresVM>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUserAdres(UpdateUserAdresVM model)
        {
            var city = await _cityService.GetCityList();
            ViewBag.UserSehirItems = city;
            ViewBag.UserIlceItems = await _cityService.GetDistrictListByCity(int.Parse(city[0].Value));

            var responseMessage = await _customHttpClient.Put<UpdateUserAdresVM>(new() { Controller = "UserAdres" }, model);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


    }
}
