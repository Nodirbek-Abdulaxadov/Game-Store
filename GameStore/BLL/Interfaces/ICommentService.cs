using BLL.Models;

namespace BLL.Interfaces
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentModel>> GetGameComments(int gameId);
        Task<int> AddComment(string text, int gameId, string userId);
        Task<int> AddReplyComment(string text, int commentId, string userId, int gameId);
        Task<int> EditCommentAsync(CommentModel comment, string userId);
        Task DeleteCommentAsync(int commentId);
    }
}
