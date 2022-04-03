using Microsoft.EntityFrameworkCore;
using System;

namespace InClass7.Models
{
    public class SongContext : DbContext
    {
        public SongContext(DbContextOptions<SongContext> options) : base(options)
        { }
        public DbSet<Song> Songs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Song>().HasData(
                new Song
                {
                    SongId = 1,
                    Title = "Stairway to Heaven",
                    Album = "Led Zepplin IV",
                    Artist = "Led Zepplin",
                    ReleaseDate = new DateTime(1971, 8, 11)
                },
                new Song
                {
                    SongId = 2,
                    Title = "Bohemian Rhapsody",
                    Album = "A Night at the Opera",
                    Artist = "Queen",
                    ReleaseDate = new DateTime(1975, 10, 31)
                },
                new Song
                {
                    SongId = 3,
                    Title = "Dream On",
                    Album = "Aerosmith",
                    Artist = "Aerosmith",
                    ReleaseDate = new DateTime(1973, 6, 27)
                });
        }
    }
}
