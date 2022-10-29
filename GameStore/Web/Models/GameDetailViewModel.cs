using BLL.Models;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class GameDetailViewModel
    {
        public GameModel Game { get; set; }
        [MinLength(3)]
        [MaxLength(600)]
        public string Text { get; set; }
        public int CommentId { get; set; }
        public int GameId { get; set; }
        public string UserId { get; set; }
        public IEnumerable<CommentModel> Comments { get; set; }
        public IEnumerable<CommentModel> DeletedComments { get; set; }
    }
}
