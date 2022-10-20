using DataLayer.Data;
using DataLayer.Interfaces;

namespace DataLayer.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GameStoreDBContext _dbcontext;

        public UnitOfWork(GameStoreDBContext dbcontext,
                           IGameCategoryInterface gameCategoryInterface,
                           IGameInterface gameInterface,
                           ICommentInterface comments)
        {
            _dbcontext = dbcontext;
            GameCategories = gameCategoryInterface;
            Games = gameInterface;
            Comments = comments;
        }
        public IGameCategoryInterface GameCategories { get; }

        public IGameInterface Games { get; }

        public ICommentInterface Comments { get; }

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
