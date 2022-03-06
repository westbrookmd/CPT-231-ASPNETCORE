using M6Assignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace M6Assignment.Controllers
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
            List<Airport> airports = _airportContext.Airports.OrderBy(
                a => a.AirportID).ToList<Airport>();
            return View(airports);
        }
    }
}
