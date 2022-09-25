namespace BLL.Models
{
    public class GameModel
    {
        public GameModel()
        {
            Categories = new List<string>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
        public IEnumerable<string>? Categories { get; set; }
    }
}
