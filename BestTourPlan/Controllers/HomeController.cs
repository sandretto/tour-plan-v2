using Microsoft.AspNetCore.Mvc;

namespace BestTourPlan.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Show()
        {
            return View();
        }
    }
}
