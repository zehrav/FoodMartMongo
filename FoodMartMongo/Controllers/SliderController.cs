﻿using FoodMartMongo.Dtos.SliderDtos;
using FoodMartMongo.Services.SliderServices;
using Microsoft.AspNetCore.Mvc;

namespace FoodMartMongo.Controllers
{
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;

        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }


        [HttpGet]
        public async Task <IActionResult> CreateSlider()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> CreateSlider(CreateSliderDto createSliderDto)
        {

            await _sliderService.CreateSliderAsync(createSliderDto);
            return RedirectToAction("SliderList");
        }

            
        public async Task<IActionResult> SliderList()
        {

            {
                var values = await _sliderService.GetAllSliderListAsync();
                return View(values);
            }
        }
        public async Task<IActionResult> DeleteSlider(string id)
        {
            await _sliderService.DeleteSliderAsync(id);
            return RedirectToAction("SliderList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSlider(string id)
        {
            var value = await _sliderService.GetSliderByIdAsync(id);
            return View(value);

        }

        [HttpPost]

        public async Task<IActionResult> UpdateSlider(UpdateSliderDto updateSliderDto)
        {
            await _sliderService.UpdateSliderAsync(updateSliderDto);
            return RedirectToAction("SliderList");
        }
    }
}
