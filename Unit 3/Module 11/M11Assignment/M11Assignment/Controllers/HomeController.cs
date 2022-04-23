using M11Assignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace M11Assignment.Controllers
{
    public class HomeController : Controller
    {
        public RoomContext roomContext { get; set; }
        public HomeController(RoomContext roomContext)
        {
            this.roomContext = roomContext;
        }

        public IActionResult Index(Room room)
        {
            if(room.Description == null)
            {
                room = roomContext.Rooms.Where(r => r.X == 0 && r.Y == 0).FirstOrDefault();
                ViewBag.Room = room;
            }
            Room northRoom = roomContext.Rooms.Where(r => r.X == room.X && r.Y == room.Y + 1).FirstOrDefault();
            ViewBag.North = northRoom != null;
            if(northRoom != null)
            {
                ViewBag.NorthID = northRoom.RoomId;
            }
            
            Room southRoom = roomContext.Rooms.Where(r => r.X == room.X && r.Y == room.Y - 1).FirstOrDefault();
            ViewBag.South = southRoom != null;
            if(southRoom != null)
            {
                ViewBag.SouthID = southRoom.RoomId;
            }
            
            Room westRoom = roomContext.Rooms.Where(r => r.X == room.X - 1 && r.Y == room.Y).FirstOrDefault();
            ViewBag.West = westRoom != null;
            if(westRoom != null)
            {
                ViewBag.WestID = westRoom.RoomId;
            }
            
            Room eastRoom = roomContext.Rooms.Where(r => r.X == room.X + 1 && r.Y == room.Y).FirstOrDefault();
            ViewBag.East = eastRoom != null;
            if(eastRoom != null)
            {
                ViewBag.EastID = eastRoom.RoomId;
            }
            
            return View(room);
        }

        public IActionResult Move(int id)
        {
            Room targetRoom = roomContext.Rooms.Where(r => r.RoomId == id).FirstOrDefault();
            return RedirectToAction("Index", targetRoom);
        }

    }
}
