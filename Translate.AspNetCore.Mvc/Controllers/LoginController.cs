using Microsoft.AspNetCore.Mvc;

namespace Translate.AspNetCore.Mvc.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
