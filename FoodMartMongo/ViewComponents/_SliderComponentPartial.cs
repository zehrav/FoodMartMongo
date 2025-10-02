﻿using FoodMartMongo.Services.SliderServices;
using Microsoft.AspNetCore.Mvc;

namespace FoodMartMongo.ViewComponents
{
    public class _SliderComponentPartial : ViewComponent
    {
        private readonly ISliderService _sliderService;

        public _SliderComponentPartial(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _sliderService.GetAllSliderListAsync(); // Listeyi çekiyoruz
            return View(values); // Default.cshtml'e model olarak gönderiyoruz
        }
    }
}
