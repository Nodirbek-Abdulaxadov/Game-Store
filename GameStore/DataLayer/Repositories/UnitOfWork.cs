using DataLayer.Data;
using DataLayer.Interfaces;

namespace DataLayer.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GameStoreDBContext _dbcontext;
        private readonly IGameCategoryInterface _gameCategoryInterface;
        private readonly IGameInterface _gameInterface;

        public UnitOfWork(GameStoreDBContext dbcontext,
                           IGameCategoryInterface gameCategoryInterface,
                           IGameInterface gameInterface)
        {
            _dbcontext = dbcontext;
            _gameCategoryInterface = gameCategoryInterface;
            _gameInterface = gameInterface;
        }
        public IGameCategoryInterface GameCategories { get; }

        public IGameInterface Games { get; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task SaveAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }
    }
}
