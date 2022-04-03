using InClass7.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace InClass7.Controllers
{
    public class SongController : Controller
    {
        public SongContext _songContext { get; set; }
        public SongController(SongContext songContext)
        {
            _songContext = songContext;
        }
        public IActionResult Index()
        {
            List<Song> songs = _songContext.Songs
                .OrderBy(s => s.Title)
                .OrderBy(s => s.Artist)
                .ToList();

            return View(songs);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Title = "Add";
            return View("AddEdit", new Song());
        }
        [HttpPost]
        public IActionResult AddEdit(Song Song)
        {
            if (ModelState.IsValid)
            {
                if (Song.SongId != 0)
                {
                    _songContext.Songs.Update(Song);
                }
                else
                {
                    _songContext.Songs.Add(Song);
                }
                _songContext.SaveChanges();
                return RedirectToAction("Index", "Song");
            }
            else
            {
                if (Song.SongId != 0)
                {
                    ViewBag.Title = "Edit";
                }
                return View("AddEdit", Song);
            }
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Title = "Edit";
            Song Song = _songContext.Songs.Find(id);
            return View("AddEdit", Song);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewBag.Title = "Delete";
            Song Song = _songContext.Songs.Find(id);
            return View(Song);
        }

        [HttpPost]
        public IActionResult Delete(Song Song)
        {
            _songContext.Songs.Remove(Song);
            _songContext.SaveChanges();
            return RedirectToAction("Index", "Song");
        }
    }
}
