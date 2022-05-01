using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace M12Assignment.Models
{
    public class Room : IComparable<Room>
    {
        public int RoomId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int X { get; set; }
        [Required]
        public int Y { get; set; }

        //Simple sort by ID
        public int CompareTo(Room other)
        {
            Room r1 = this;
            Room r2 = other;
            if (r1.RoomId > r2.RoomId)
                return 1;
            if (r1.RoomId < r2.RoomId)
                return -1;
            else
                return 0;
        }
    }
}
