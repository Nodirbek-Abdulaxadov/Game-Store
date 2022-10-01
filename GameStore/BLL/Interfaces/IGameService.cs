using BLL.Models;

namespace BLL.Interfaces
{
    public interface IGameService
    {
        Task AddMockData();
        Task<IEnumerable<GameModel>> GetAllGamesByNameAsync(string? name, SortType sort);
        Task<GameModel> GetGameByIdAsync(int id);
    }
}
