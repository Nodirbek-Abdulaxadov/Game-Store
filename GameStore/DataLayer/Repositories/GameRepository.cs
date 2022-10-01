using DataLayer.Data;
using DataLayer.Entities;
using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public class GameRepository : Repository<Game>, IGameInterface
    {
        private readonly GameStoreDBContext dbContext;

        public GameRepository(GameStoreDBContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Game>> GetAllGamesWithCategories()
            => await dbContext.Games.Include(i => i.Categories)
                                    .ThenInclude(i => i.Category)
                                    .ToListAsync();

        public async Task<Game> GetByIdWithCategories(int id)
            => (await GetAllGamesWithCategories()).FirstOrDefault(i => i.Id == id);
    }
}
