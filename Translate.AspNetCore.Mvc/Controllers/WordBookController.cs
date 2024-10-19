using Microsoft.AspNetCore.Mvc;

namespace Translate.AspNetCore.Mvc.Controllers
{
    public class WordBookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
