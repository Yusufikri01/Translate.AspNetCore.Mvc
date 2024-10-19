using Microsoft.AspNetCore.Mvc;

namespace Translate.AspNetCore.Mvc.Controllers
{
    public class DictionaryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
