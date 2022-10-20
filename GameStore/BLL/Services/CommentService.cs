using BLL.Interfaces;
using BLL.Models;
using DataLayer.Entities;
using DataLayer.Interfaces;
using System.ComponentModel;

namespace BLL.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> AddComment(string text, int gameId, string userId)
        {
            Comment comment = new()
            {
                Body = text,
                GameId = gameId,
                UserId = userId,
                IsEdited = false,
                RepliedCommentId = 0,
                CommentedTime = DateTime.Now
            };
            await _unitOfWork.Comments.AddAsync(comment);
            await _unitOfWork.SaveAsync();
            return gameId;
        }

        public async Task<int> AddReplyComment(string text, int commentId, string userId, int gameId)
        {
            Comment comment = new()
            {
                Body = text,
                GameId = gameId,
                UserId = userId,
                IsEdited = false,
                RepliedCommentId = commentId,
                CommentedTime = DateTime.Now
            };

            await _unitOfWork.Comments.AddAsync(comment);
            await _unitOfWork.SaveAsync();
            return gameId;
        }

        public Task DeleteCommentAsync(int commentId)
        {
            throw new NotImplementedException();
        }

        public Task<int> EditCommentAsync(CommentModel comment, string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CommentModel>> GetGameComments(int gameId)
        {
            var list = await _unitOfWork.Comments.GetAllAsync();
            return list.Where(i => i.GameId == gameId)
                       .Select(c => new CommentModel()
                       {
                           Id = c.Id,
                           Body = c.Body,
                           CommentedTime = c.CommentedTime,
                           IsEdited = c.IsEdited,
                           RepliedComments = (IEnumerable<CommentModel>)GetRepliedCommentsByCommentIdAsync(c.Id)
                       });
        }

        private async Task<IEnumerable<CommentModel>> GetRepliedCommentsByCommentIdAsync(int commentId)
        {
            var list = await _unitOfWork.Comments.GetAllAsync();
            return list.Where(i => i.RepliedCommentId == commentId)
                       .Select(c => new CommentModel()
                       {
                           Id = c.Id,
                           Body = c.Body,
                           CommentedTime = c.CommentedTime,
                           IsEdited = c.IsEdited
                       });
        }
    }
}
