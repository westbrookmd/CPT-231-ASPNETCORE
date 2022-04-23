using M11Assignment.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M11Assignment.Areas.User
{
    [Area("User")]
    public class HomeController : Controller
    {
        public RoomContext context { get; set; }

        public HomeController(RoomContext roomContext)
        {
            context = roomContext;
        }

        [Route("[area]/[controller]/[action]")]
        public IActionResult Index()
        {
            TempData["Welcome"] = "From User Index";
            return RedirectToAction("Page", 1);
        }

        public IActionResult Page(int id = 1)
        {
            TempData["PageData"] = id;
            //string toReturn = "Page"+id.ToString();
            return View("Page" + id.ToString());
        }
    }
}
