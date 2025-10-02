using FoodMartMongo.Dtos.DiscountDtos;
using FoodMartMongo.Services.DiscountServices;
using Microsoft.AspNetCore.Mvc;

namespace FoodMartMongo.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        // Tüm indirimleri listeler
        public async Task<IActionResult> DiscountList()
        {
            var values = await _discountService.GetAllDiscountAsync();
            return View(values);
        }

        // GET: Yeni indirim ekleme sayfası
        [HttpGet]
        public IActionResult CreateDiscount()
        {
            return View();
        }

        // POST: Yeni indirim ekleme
        [HttpPost]
        public async Task<IActionResult> CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            await _discountService.CreateDiscountAsync(createDiscountDto);
            return RedirectToAction("DiscountList");
        }

        // GET: İndirimi güncelleme sayfası
        [HttpGet]
        public async Task<IActionResult> UpdateDiscount(string id)
        {
            var value = await _discountService.GetDiscountByIdAsync(id);
            return View(value);
        }

        // POST: İndirimi güncelle
        [HttpPost]
        public async Task<IActionResult> UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            await _discountService.UpdateDiscountAsync(updateDiscountDto);
            return RedirectToAction("DiscountList");
        }

        // İndirimi sil
        public async Task<IActionResult> DeleteDiscount(string id)
        {
            await _discountService.DeleteDiscountAsync(id);
            return RedirectToAction("DiscountList");
        }
    }
}
