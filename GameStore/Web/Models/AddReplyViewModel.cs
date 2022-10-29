namespace Web.Models
{
    public class AddReplyViewModel
    {
        public int CommentId { get; set; }
        public int GameId { get; set; }
        public string UserId { get; set; }
        public string Text { get; set; }
    }
}
