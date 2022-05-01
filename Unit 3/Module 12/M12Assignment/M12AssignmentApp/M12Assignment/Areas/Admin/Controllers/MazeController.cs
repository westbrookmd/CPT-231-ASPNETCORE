using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using M12Assignment.Models;
using Microsoft.AspNetCore.Authorization;

namespace M12Assignment.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Area("Admin")]
    public class MazeController : Controller
    {
        public RoomContext roomContext { get; set; }
        public MazeController(RoomContext roomContext)
        {
            this.roomContext = roomContext;
        }
        public IActionResult Index()
        {
            List<Room> rooms = roomContext.Rooms.ToList<Room>(); 
            return View(rooms);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Room());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            Room room = roomContext.Rooms.Find(id);
            return View(room);
        }

        [HttpPost]
        public IActionResult Edit(Room room)
        {
            if (ModelState.IsValid)
            {
                if (room.RoomId == 0)
                    roomContext.Rooms.Add(room);
                else
                    roomContext.Rooms.Update(room);
                roomContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Action = (room.RoomId == 0) ? "Add" : "Edit";
                return View(room);
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Room room = roomContext.Rooms.Find(id);
            return View(room);
        }

        [HttpPost]
        public IActionResult Delete(Room room)
        {
            roomContext.Rooms.Remove(room);
            roomContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
