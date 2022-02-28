using InClassU2M6.Models;
using Microsoft.AspNetCore.Mvc;

namespace InClassU2M6.Controllers
{
    public class ChessController : Controller
    {
        private ChessContext chessContext { get; set; }
        public ChessController(ChessContext chessContext)
        {
            this.chessContext = chessContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Title = "Add";
            return View("AddEdit", new Chess());
        }
        [HttpPost]
        public IActionResult AddEdit(Chess chess)
        {
            if (ModelState.IsValid)
            {
                if(chess.ChessID != 0)
                {
                    chessContext.Chess.Update(chess);
                }
                else
                {
                    chessContext.Chess.Add(chess);
                }
                chessContext.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (chess.ChessID != 0)
                {
                    ViewBag.Title = "Edit";
                }
                else
                {

                }
                return View("AddEdit", chess);

            }
            
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Title = "Edit";
            Chess chess = chessContext.Chess.Find(id);
            return View("AddEdit", chess);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewBag.Title = "Delete";
            Chess chess = chessContext.Chess.Find(id);
            return View(chess);
        }

        [HttpPost]
        public IActionResult Delete(Chess chess)
        {
            chessContext.Chess.Remove(chess);
            chessContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
