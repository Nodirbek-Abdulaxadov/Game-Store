using BLL.Models;
using DataLayer.Entities;

namespace Web.Models
{
    public class GameFilterViewModel
    {
        public string? Name { get; set; }
        public SortType? Sort { get; set; }
        public PagedList<GameModel> PagedGames { get; set; }
        public int categoryId { get; set; }
        public IEnumerable<GameCategoryModel>? Categories { get; set; }
        public int? Page { get; set; }
    }
}
