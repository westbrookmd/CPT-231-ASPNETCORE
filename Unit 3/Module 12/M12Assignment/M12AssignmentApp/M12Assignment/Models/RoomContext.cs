
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M12Assignment.Models
{
    public class RoomContext: DbContext
    {
        public RoomContext(DbContextOptions<RoomContext> options) : base(options)
        { }

        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    RoomId = 1,
                    Description = "You are in a room with exits to the North, East, South, and West.",
                    X = 0,
                    Y = 0
                },
                new Room
                {
                    RoomId = 2,
                    Description = "You are in a room with an exit to the West.",
                    X = 1,
                    Y = 0
                },
                new Room
                {
                    RoomId = 3,
                    Description = "You are in a room with an exit to the South.",
                    X = 0,
                    Y = 1
                },
                new Room
                {
                    RoomId = 4,
                    Description = "You are in a room with an exit to the East.",
                    X = -1,
                    Y = 0
                },
                new Room
                {
                    RoomId = 5,
                    Description = "You are in a room with an exit to the North.",
                    X = 0,
                    Y = -1
                }
                );
        }
    }
}
