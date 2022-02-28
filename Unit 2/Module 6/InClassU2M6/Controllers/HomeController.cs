using InClassU2M6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace InClassU2M6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ChessContext chessContext { get; set; }
        public HomeController(ChessContext chessContext)
        {
            this.chessContext = chessContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Chess> chess = chessContext.Chess.OrderBy(
                c => c.ChessID).ToList<Chess>();
            return View(chess);
        }

        public IActionResult Privacy()
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
