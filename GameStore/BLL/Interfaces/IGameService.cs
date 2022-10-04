using BLL.Models;

namespace BLL.Interfaces
{
    public interface IGameService
    {
        Task AddMockData();
        Task<IEnumerable<GameModel>> GetAllGamesByNameAsync(string? name, SortType sort);
        Task<GameModel> GetGameByIdAsync(int id);
        Task<GameModel> AddGameAsync(string name, string description, decimal price, string imagePath, List<string> categories);
        Task<bool> Exist(string name);
    }
}
