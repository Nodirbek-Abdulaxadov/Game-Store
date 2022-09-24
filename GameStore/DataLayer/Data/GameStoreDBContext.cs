using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Data
{
    public class GameStoreDBContext : DbContext
    {
        public GameStoreDBContext(DbContextOptions<GameStoreDBContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Game>? Games { get; set; }
        public DbSet<GameCategory>? GameCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameCategory>()
                .HasData(
                    new GameCategory()
                    {
                        Id = 1,
                        Name = "Action"
                    },
                    new GameCategory()
                    {
                        Id = 2,
                        Name = "Advanture"
                    },
                    new GameCategory()
                    {
                        Id = 3,
                        Name = "Strategy"
                    },
                    new GameCategory()
                    {
                        Id = 4,
                        Name = "Race"
                    }
                );

            modelBuilder.Entity<Game>()
                .HasData(
                    new Game()
                    {
                        Id = 1,
                        Name = "Transformers: The Game",
                        Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
                        Price = 150,
                        ImagePath = "assets/big.jpg",
                        IsDeleted = false,
                        CategoryIds = new[] { 1, 2, 3 }
                    },
                    new Game()
                    {
                        Id = 2,
                        Name = "Need for Speed",
                        Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
                        Price = 250,
                        ImagePath = "assets/race.jpg",
                        IsDeleted = false,
                        CategoryIds = new[] { 2, 3 }
                    }
                );
        }
    }
}
