using BookWiki.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Diagnostics;
using System.Text.Encodings.Web;

namespace BookWiki.Controllers
{
    public class BookWikiController : Controller
    {
        private readonly IStringLocalizer<BookWikiController> _localizer;

        public BookWikiController(IStringLocalizer<BookWikiController> localizer)
        {
            this._localizer = localizer;
        }
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}