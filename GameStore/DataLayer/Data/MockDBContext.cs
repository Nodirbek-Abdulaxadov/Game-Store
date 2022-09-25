using DataLayer.Entities;

namespace DataLayer.Data
{
    public class MockDBContext : IDisposable
    {
        public MockDBContext()
        {
            Categories = new List<GameCategory>()
            {
                new GameCategory() { Name = "Advanture"},
                new GameCategory() { Name = "Race"},
                new GameCategory() { Name = "Strategy"}
            };

            Games = new List<Game>()
            {
                new Game() 
                {
                    Name = "PUBG", 
                    Price = 0, 
                    Description = "Gameplay. PUBG is a player versus player shooter game in which up to one hundred players fight in a battle royale, a type of large-scale last man standing deathmatch where players fight to remain the last alive.",
                    ImagePath = "images/pubg.jpg",
                    IsDeleted = false,
                    Categories = new List<CategoryGame>()
                    {
                        new CategoryGame() {Category = Categories.First()},
                        new CategoryGame() {Category = Categories.Last()}
                    }
                },
                new Game()
                {
                    Name = "World War III",
                    Price = 150.0m,
                    Description = "Gameplay player versus player shooter game in which up to one hundred players fight in a battle royale, a type of large-scale last man standing deathmatch where players fight to remain the last alive.",
                    ImagePath = "images/big.jpg",
                    IsDeleted = false,
                    Categories = new List<CategoryGame>()
                    {
                        new CategoryGame() {Category = Categories.ToList()[1]},
                        new CategoryGame() {Category = Categories.ToList()[2]}
                    }
                },
                new Game()
                {
                    Name = "PUBG",
                    Price = 0,
                    Description = "Gameplay. PUBG is a player versus player shooter game in which up to one hundred players fight in a battle royale, a type of large-scale last man standing deathmatch where players fight to remain the last alive.",
                    ImagePath = "images/pubg.jpg",
                    IsDeleted = false,
                    Categories = new List<CategoryGame>()
                    {
                        new CategoryGame() {Category = Categories.First()},
                        new CategoryGame() {Category = Categories.Last()}
                    }
                },
                new Game()
                {
                    Name = "World War III",
                    Price = 150.0m,
                    Description = "Gameplay player versus player shooter game in which up to one hundred players fight in a battle royale, a type of large-scale last man standing deathmatch where players fight to remain the last alive.",
                    ImagePath = "images/big.jpg",
                    IsDeleted = false,
                    Categories = new List<CategoryGame>()
                    {
                        new CategoryGame() {Category = Categories.ToList()[1]},
                        new CategoryGame() {Category = Categories.ToList()[2]}
                    }
                },
                new Game()
                {
                    Name = "PUBG",
                    Price = 0,
                    Description = "Gameplay. PUBG is a player versus player shooter game in which up to one hundred players fight in a battle royale, a type of large-scale last man standing deathmatch where players fight to remain the last alive.",
                    ImagePath = "images/pubg.jpg",
                    IsDeleted = false,
                    Categories = new List<CategoryGame>()
                    {
                        new CategoryGame() {Category = Categories.First()},
                        new CategoryGame() {Category = Categories.Last()}
                    }
                },
                new Game()
                {
                    Name = "World War III",
                    Price = 150.0m,
                    Description = "Gameplay player versus player shooter game in which up to one hundred players fight in a battle royale, a type of large-scale last man standing deathmatch where players fight to remain the last alive.",
                    ImagePath = "images/big.jpg",
                    IsDeleted = false,
                    Categories = new List<CategoryGame>()
                    {
                        new CategoryGame() {Category = Categories.ToList()[1]},
                        new CategoryGame() {Category = Categories.ToList()[2]}
                    }
                },
                new Game()
                {
                    Name = "PUBG",
                    Price = 0,
                    Description = "Gameplay. PUBG is a player versus player shooter game in which up to one hundred players fight in a battle royale, a type of large-scale last man standing deathmatch where players fight to remain the last alive.",
                    ImagePath = "images/pubg.jpg",
                    IsDeleted = false,
                    Categories = new List<CategoryGame>()
                    {
                        new CategoryGame() {Category = Categories.First()},
                        new CategoryGame() {Category = Categories.Last()}
                    }
                },
                new Game()
                {
                    Name = "World War III",
                    Price = 150.0m,
                    Description = "Gameplay player versus player shooter game in which up to one hundred players fight in a battle royale, a type of large-scale last man standing deathmatch where players fight to remain the last alive.",
                    ImagePath = "images/big.jpg",
                    IsDeleted = false,
                    Categories = new List<CategoryGame>()
                    {
                        new CategoryGame() {Category = Categories.ToList()[1]},
                        new CategoryGame() {Category = Categories.ToList()[2]}
                    }
                },
                new Game()
                {
                    Name = "PUBG",
                    Price = 0,
                    Description = "Gameplay. PUBG is a player versus player shooter game in which up to one hundred players fight in a battle royale, a type of large-scale last man standing deathmatch where players fight to remain the last alive.",
                    ImagePath = "images/pubg.jpg",
                    IsDeleted = false,
                    Categories = new List<CategoryGame>()
                    {
                        new CategoryGame() {Category = Categories.First()},
                        new CategoryGame() {Category = Categories.Last()}
                    }
                },
                new Game()
                {
                    Name = "World War III",
                    Price = 150.0m,
                    Description = "Gameplay player versus player shooter game in which up to one hundred players fight in a battle royale, a type of large-scale last man standing deathmatch where players fight to remain the last alive.",
                    ImagePath = "images/big.jpg",
                    IsDeleted = false,
                    Categories = new List<CategoryGame>()
                    {
                        new CategoryGame() {Category = Categories.ToList()[1]},
                        new CategoryGame() {Category = Categories.ToList()[2]}
                    }
                },
                new Game()
                {
                    Name = "PUBG",
                    Price = 0,
                    Description = "Gameplay. PUBG is a player versus player shooter game in which up to one hundred players fight in a battle royale, a type of large-scale last man standing deathmatch where players fight to remain the last alive.",
                    ImagePath = "images/pubg.jpg",
                    IsDeleted = false,
                    Categories = new List<CategoryGame>()
                    {
                        new CategoryGame() {Category = Categories.First()},
                        new CategoryGame() {Category = Categories.Last()}
                    }
                },
                new Game()
                {
                    Name = "World War III",
                    Price = 150.0m,
                    Description = "Gameplay player versus player shooter game in which up to one hundred players fight in a battle royale, a type of large-scale last man standing deathmatch where players fight to remain the last alive.",
                    ImagePath = "images/big.jpg",
                    IsDeleted = false,
                    Categories = new List<CategoryGame>()
                    {
                        new CategoryGame() {Category = Categories.ToList()[1]},
                        new CategoryGame() {Category = Categories.ToList()[2]}
                    }
                },
                new Game()
                {
                    Name = "PUBG",
                    Price = 0,
                    Description = "Gameplay. PUBG is a player versus player shooter game in which up to one hundred players fight in a battle royale, a type of large-scale last man standing deathmatch where players fight to remain the last alive.",
                    ImagePath = "images/pubg.jpg",
                    IsDeleted = false,
                    Categories = new List<CategoryGame>()
                    {
                        new CategoryGame() {Category = Categories.First()},
                        new CategoryGame() {Category = Categories.Last()}
                    }
                },
                new Game()
                {
                    Name = "World War III",
                    Price = 150.0m,
                    Description = "Gameplay player versus player shooter game in which up to one hundred players fight in a battle royale, a type of large-scale last man standing deathmatch where players fight to remain the last alive.",
                    ImagePath = "images/big.jpg",
                    IsDeleted = false,
                    Categories = new List<CategoryGame>()
                    {
                        new CategoryGame() {Category = Categories.ToList()[1]},
                        new CategoryGame() {Category = Categories.ToList()[2]}
                    }
                },
                new Game()
                {
                    Name = "PUBG",
                    Price = 0,
                    Description = "Gameplay. PUBG is a player versus player shooter game in which up to one hundred players fight in a battle royale, a type of large-scale last man standing deathmatch where players fight to remain the last alive.",
                    ImagePath = "images/pubg.jpg",
                    IsDeleted = false,
                    Categories = new List<CategoryGame>()
                    {
                        new CategoryGame() {Category = Categories.First()},
                        new CategoryGame() {Category = Categories.Last()}
                    }
                },
                new Game()
                {
                    Name = "World War III",
                    Price = 150.0m,
                    Description = "Gameplay player versus player shooter game in which up to one hundred players fight in a battle royale, a type of large-scale last man standing deathmatch where players fight to remain the last alive.",
                    ImagePath = "images/big.jpg",
                    IsDeleted = false,
                    Categories = new List<CategoryGame>()
                    {
                        new CategoryGame() {Category = Categories.ToList()[1]},
                        new CategoryGame() {Category = Categories.ToList()[2]}
                    }
                },
            };
        }

        public IEnumerable<GameCategory> Categories { get; set; }
        public IEnumerable<Game> Games { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
