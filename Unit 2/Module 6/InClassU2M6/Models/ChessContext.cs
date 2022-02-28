using Microsoft.EntityFrameworkCore;

namespace InClassU2M6.Models
{
    public class ChessContext : DbContext
    {
        public ChessContext(DbContextOptions<ChessContext> options) : base(options)
        {

        }
        public DbSet<Chess> Chess { get; set; }
        public DbSet<Player> Players { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Chess>().HasData(
                new Chess{
                    ChessID = 1,
                    Name = "King's Pawn",
                    Moves = "1.e4"
                },
                new Chess
                {
                    ChessID = 2,
                    Name = "Sicilian Defense",
                    Moves = "1.e4 c5"
                },
                new Chess
                {
                    ChessID = 3,
                    Name = "Italian Game",
                    Moves = "1.e4 e5 2.Nf3 Nc6 3.Bc4 "
                }
                );
            modelBuilder.Entity<Player>().HasData(
                new Player
                {
                    PlayerID = 1,
                    Name = "Magnus Carlson"
                },
                new Player
                {
                    PlayerID = 2,
                    Name = "Ian Nepomniachtchi"
                }
                );
        }
    }
}
