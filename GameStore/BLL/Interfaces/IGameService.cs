using BLL.Models;

namespace BLL.Interfaces
{
    public interface IGameService
    {
        Task AddMockData();
        Task<IEnumerable<GameModel>> GetAllGamesAsync();
    }
}
