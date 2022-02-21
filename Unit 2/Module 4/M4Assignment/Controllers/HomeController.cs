/* 
* Marshall Westbrook
* CPT-231-S14
* U2-M4 Assignment
* Spring 2022
* A project that demonstrates how to use the basics of ASP.net Core MVC
*/


using M4Assignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace M4Assignment.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            DiceRoller diceRoller = new DiceRoller();
            //default values set in DiceRoller constructor

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
                //default values set in DiceRoller constructor
            }
            return View(diceRoller);
        }
        
    }
}
