
using Microsoft.AspNetCore.Mvc;

namespace M9Assignment.Areas.Help.Controllers
{
    [Area("Help")]
    public class HelpController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
