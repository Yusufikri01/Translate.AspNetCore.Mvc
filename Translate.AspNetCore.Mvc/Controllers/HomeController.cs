using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Translate.AspNetCore.Mvc.Entities;
using Translate.AspNetCore.Mvc.Models;

namespace Translate.AspNetCore.Mvc.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;


        public HomeController(ILogger<HomeController> logger, AppDbContext context)
		{
			_logger = logger;
            _context = context;
        }
        [HttpPost]
        public IActionResult Translate(string word, string fromLang, string toLang)
        {
            if (string.IsNullOrWhiteSpace(word) || string.IsNullOrWhiteSpace(fromLang) || string.IsNullOrWhiteSpace(toLang))
            {
                ViewBag.Translation = "Lütfen tüm alanları doldurun.";
                return View("Index");
            }

            WordModel translation = null;

            if (fromLang == "tr" && toLang == "en")
            {
                translation = _context.Words.FirstOrDefault(w => w.Turkish == word);
            }
            else if (fromLang == "en" && toLang == "tr")
            {
                translation = _context.Words.FirstOrDefault(w => w.English == word);
            }

            ViewBag.Translation = translation != null
                ? (toLang == "tr" ? translation.Turkish : translation.English)
                : "Çeviri bulunamadı.";

            return View("Index");
        }


        public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}