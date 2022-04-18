
using Microsoft.AspNetCore.Mvc;

namespace M10Assignment.Areas.Help.Controllers
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
