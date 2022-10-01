using DataLayer.Entities;
namespace DataLayer.Interfaces
{
    public interface IGameInterface : IRepository<Game>
    {
        Task<IEnumerable<Game>> GetAllGamesWithCategories();
        Task<Game> GetByIdWithCategories(int id);
    }
}
