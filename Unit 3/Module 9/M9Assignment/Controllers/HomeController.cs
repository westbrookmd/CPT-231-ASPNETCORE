using M9Assignment.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace M9Assignment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private AirportContext _airportContext { get; set; }
        public HomeController(ILogger<HomeController> logger, AirportContext airportContext)
        {
            _logger = logger;
            _airportContext = airportContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Airport()
        {
            List<Airport> airports = _airportContext.Airports.OrderBy(
                a => a.AirportID).ToList<Airport>();
            return View(airports);
        }
    }
}
