using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class GameCategory : BaseEntity
    {
        public GameCategory()
        {
            CategoryGamesIds = new List<int>();
        }

        [Required]
        [StringLength(30)]
        public string? Name { get; set; }
        public ICollection<int> CategoryGamesIds { get; set; }
    }
}
