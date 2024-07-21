using Microsoft.AspNetCore.Mvc;

namespace Presentation.Views
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
