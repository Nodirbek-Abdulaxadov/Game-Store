using DataLayer.Data;
using DataLayer.Entities;
using DataLayer.Interfaces;

namespace DataLayer.Repositories
{
    public class GameRepository : Repository<Game>, IGameInterface
    {
        public GameRepository(GameStoreDBContext dbContext) : base(dbContext)
        {
        }
    }
}
