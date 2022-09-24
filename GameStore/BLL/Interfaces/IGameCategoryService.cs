using BLL.Models;

namespace BLL.Interfaces
{
    public interface IGameCategoryService
    {
        Task<IEnumerable<GameCategoryModel>> GetAllGameCategoriesAsync();
        Task AddGameCategoryAsync(string name);
        Task UpdateCategoryAsync(GameCategoryModel model);
        Task DeleteGameCategoryByIdAsync(int categoryId);
    }
}
