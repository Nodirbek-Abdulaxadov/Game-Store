using BLL.Models;
using DataLayer.Entities;

namespace Web.Models
{
    public class GameFilterViewModel
    {
        public string? Name { get; set; }
        public SortType? Sort { get; set; }
        public PagedList<GameModel> PagedGames { get; set; }
        public IEnumerable<GameCategory>? Categories { get; set; }
        public int? Page { get; set; }
    }

    public enum SortType
    { 
        New,
        Popular,
        Free
    }
}
