using Microsoft.AspNetCore.Mvc;

namespace M12Assignment.Areas.Help.Controllers
{
    [Area("Help")]
    public class HelpController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Navigation()
        {
            return View();
        }
    }
}
