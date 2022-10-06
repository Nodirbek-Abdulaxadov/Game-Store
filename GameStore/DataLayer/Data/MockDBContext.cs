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
                new GameCategory() { Name = "Races"},
                new GameCategory() { Name = "Strategy"},
                new GameCategory() { Name = "Rpg"},
                new GameCategory() { Name = "Action"},
                new GameCategory() { Name = "Puzzle & skill"},
                new GameCategory() { Name = "Other"}
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
                    Sold = 123,
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
                    Sold = 13,
                    Categories = new List<CategoryGame>()
                    {
                        new CategoryGame() {Category = Categories.ToList()[1]},
                        new CategoryGame() {Category = Categories.ToList()[2]}
                    }
                },
                new Game()
                {
                    Name = "PUBG",
                    Price = 230,
                    Description = "Gameplay. PUBG is a player versus player shooter game in which up to one hundred players fight in a battle royale, a type of large-scale last man standing deathmatch where players fight to remain the last alive.",
                    ImagePath = "images/pubg.jpg",
                    IsDeleted = false,
                    Sold = 1212,
                    Categories = new List<CategoryGame>()
                    {
                        new CategoryGame() {Category = Categories.First()},
                        new CategoryGame() {Category = Categories.Last()}
                    }
                },
                new Game()
                {
                    Name = "World War III",
                    Price = 10.0m,
                    Description = "Gameplay player versus player shooter game in which up to one hundred players fight in a battle royale, a type of large-scale last man standing deathmatch where players fight to remain the last alive.",
                    ImagePath = "images/big.jpg",
                    IsDeleted = false,
                    Sold = 1,
                    Categories = new List<CategoryGame>()
                    {
                        new CategoryGame() {Category = Categories.ToList()[1]},
                        new CategoryGame() {Category = Categories.ToList()[2]}
                    }
                },
                new Game()
                {
                    Name = "PUBG",
                    Price = 432,
                    Description = "Gameplay. PUBG is a player versus player shooter game in which up to one hundred players fight in a battle royale, a type of large-scale last man standing deathmatch where players fight to remain the last alive.",
                    ImagePath = "images/pubg.jpg",
                    IsDeleted = false,
                    Sold = 3,
                    Categories = new List<CategoryGame>()
                    {
                        new CategoryGame() {Category = Categories.First()},
                        new CategoryGame() {Category = Categories.Last()}
                    }
                },
                new Game()
                {
                    Name = "World War III",
                    Price = 34.0m,
                    Description = "Gameplay player versus player shooter game in which up to one hundred players fight in a battle royale, a type of large-scale last man standing deathmatch where players fight to remain the last alive.",
                    ImagePath = "images/big.jpg",
                    IsDeleted = false,
                    Sold = 33,
                    Categories = new List<CategoryGame>()
                    {
                        new CategoryGame() {Category = Categories.ToList()[1]},
                        new CategoryGame() {Category = Categories.ToList()[2]}
                    }
                },
                new Game()
                {
                    Name = "PUBG",
                    Price = 99,
                    Description = "Gameplay. PUBG is a player versus player shooter game in which up to one hundred players fight in a battle royale, a type of large-scale last man standing deathmatch where players fight to remain the last alive.",
                    ImagePath = "images/pubg.jpg",
                    IsDeleted = false,
                    Sold = 1,
                    Categories = new List<CategoryGame>()
                    {
                        new CategoryGame() {Category = Categories.First()},
                        new CategoryGame() {Category = Categories.Last()}
                    }
                },
                new Game()
                {
                    Name = "World War III",
                    Price = 130.0m,
                    Description = "Gameplay player versus player shooter game in which up to one hundred players fight in a battle royale, a type of large-scale last man standing deathmatch where players fight to remain the last alive.",
                    ImagePath = "images/big.jpg",
                    IsDeleted = false,
                    Sold = 1273,
                    Categories = new List<CategoryGame>()
                    {
                        new CategoryGame() {Category = Categories.ToList()[1]},
                        new CategoryGame() {Category = Categories.ToList()[2]}
                    }
                },
                new Game()
                {
                    Name = "PUBG",
                    Price = 23,
                    Description = "Gameplay. PUBG is a player versus player shooter game in which up to one hundred players fight in a battle royale, a type of large-scale last man standing deathmatch where players fight to remain the last alive.",
                    ImagePath = "images/pubg.jpg",
                    IsDeleted = false,
                    Sold = 93,
                    Categories = new List<CategoryGame>()
                    {
                        new CategoryGame() {Category = Categories.First()},
                        new CategoryGame() {Category = Categories.Last()}
                    }
                },
                new Game()
                {
                    Name = "World War III",
                    Price = 340.0m,
                    Description = "Gameplay player versus player shooter game in which up to one hundred players fight in a battle royale, a type of large-scale last man standing deathmatch where players fight to remain the last alive.",
                    ImagePath = "images/big.jpg",
                    IsDeleted = false,
                    Sold = 12653,
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
                    Sold = 54123,
                    Categories = new List<CategoryGame>()
                    {
                        new CategoryGame() {Category = Categories.First()},
                        new CategoryGame() {Category = Categories.Last()}
                    }
                },
                new Game()
                {
                    Name = "World War III",
                    Price = 0m,
                    Description = "Gameplay player versus player shooter game in which up to one hundred players fight in a battle royale, a type of large-scale last man standing deathmatch where players fight to remain the last alive.",
                    ImagePath = "images/big.jpg",
                    IsDeleted = false,
                    Sold = 15323,
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
                    Sold = 12463,
                    Categories = new List<CategoryGame>()
                    {
                        new CategoryGame() {Category = Categories.First()},
                        new CategoryGame() {Category = Categories.Last()}
                    }
                },
                new Game()
                {
                    Name = "World War III",
                    Price = 110.0m,
                    Description = "Gameplay player versus player shooter game in which up to one hundred players fight in a battle royale, a type of large-scale last man standing deathmatch where players fight to remain the last alive.",
                    ImagePath = "images/big.jpg",
                    IsDeleted = false,
                    Sold = 0,
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
                    Sold = 123,
                    Categories = new List<CategoryGame>()
                    {
                        new CategoryGame() {Category = Categories.First()},
                        new CategoryGame() {Category = Categories.Last()}
                    }
                },
                new Game()
                {
                    Name = "World War III",
                    Price = 50.0m,
                    Description = "Gameplay player versus player shooter game in which up to one hundred players fight in a battle royale, a type of large-scale last man standing deathmatch where players fight to remain the last alive.",
                    ImagePath = "images/big.jpg",
                    IsDeleted = false,
                    Sold = 123,
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
