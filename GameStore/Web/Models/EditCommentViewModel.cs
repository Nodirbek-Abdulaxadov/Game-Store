namespace Web.Models
{
    public class EditCommentViewModel
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        public int GameId { get; set; }
        public string UserId { get; set; }
    }
}
