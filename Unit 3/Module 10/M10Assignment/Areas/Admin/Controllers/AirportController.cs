
using M10Assignment.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace M10Assignment.Admin.Controllers
{
    [Area("Admin")]
    public class AirportController : Controller
    {
        private AirportContext _airportContext { get; set; }
        public AirportController(AirportContext airportContext)
        {
            _airportContext = airportContext;
        }
        public IActionResult Index()
        {
            List<Airport> airports = _airportContext.Airports.OrderBy(
                 a => a.AirportID).ToList<Airport>();
            return View(airports);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Title = "Add";
            return View("AddEdit", new Airport());
        }
        [HttpPost]
        public IActionResult AddEdit(Airport airport)
        {
            if (ModelState.IsValid)
            {
                if (airport.AirportID != 0)
                {
                    _airportContext.Airports.Update(airport);
                }
                else
                {
                    _airportContext.Airports.Add(airport);
                }
                _airportContext.SaveChanges();
                return RedirectToAction("Index", "Airport");
            }
            else
            {
                if (airport.AirportID != 0)
                {
                    ViewBag.Title = "Edit";
                }
                return View("AddEdit", airport);
            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Title = "Edit";
            Airport airport = _airportContext.Airports.Find(id);
            return View("AddEdit", airport);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewBag.Title = "Delete";
            Airport airport = _airportContext.Airports.Find(id);
            return View(airport);
        }
        [HttpPost]
        public IActionResult Delete(Airport airport)
        {
            _airportContext.Airports.Remove(airport);
            _airportContext.SaveChanges();
            return RedirectToAction("Index", "Airport");
        }
    }
}
