using Microsoft.AspNetCore.Mvc;

namespace SportsPro.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
