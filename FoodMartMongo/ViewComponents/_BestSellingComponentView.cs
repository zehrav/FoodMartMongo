using Microsoft.AspNetCore.Mvc;

namespace FoodMartMongo.ViewComponents
{
    public class _BestSellingComponentView : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
