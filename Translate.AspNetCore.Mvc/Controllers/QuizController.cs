using Microsoft.AspNetCore.Mvc;

namespace Translate.AspNetCore.Mvc.Controllers
{
    public class QuizController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
