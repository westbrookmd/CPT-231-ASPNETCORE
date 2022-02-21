using Microsoft.AspNetCore.Mvc;
using InClass04.Models;

namespace InClass04.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            DiceRoller diceRoller = new DiceRoller();
            diceRoller.Sides = 0;
            diceRoller.DiceCount = 0;
            return View(diceRoller);
        }
        [HttpPost]
        public IActionResult Index(DiceRoller diceRoller)
        {
            if (ModelState.IsValid)
            {
                // proceed as usual
            }
            else
            {
                //reset things
                diceRoller = new DiceRoller();
                diceRoller.Sides = 2;
                diceRoller.DiceCount = 1;
            }
            return View(diceRoller);
        }
    }
}
