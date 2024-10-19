using Microsoft.AspNetCore.Mvc;

namespace Translate.AspNetCore.Mvc.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
