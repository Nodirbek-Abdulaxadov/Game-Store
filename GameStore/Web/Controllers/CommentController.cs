using BLL.Interfaces;
using BLL.Models;
using DataLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.Data;
using Web.Models;

namespace Web.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IGameService _gameService;
        private readonly WebContext webContext;

        public CommentController(ICommentService commentService,
                                 IGameService gameService,
                                 WebContext webContext)
        {
            _commentService = commentService;
            _gameService = gameService;
            this.webContext = webContext;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Add(int gameId, string userId, int commentId)
        {
            var model = new AddReplyViewModel()
            {
                GameId = gameId,
                UserId = userId,
                CommentId = commentId
            };

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(AddReplyViewModel viewModel)
        {
            await _commentService.AddReplyComment(viewModel.Text, viewModel.CommentId, viewModel.UserId, viewModel.GameId);
            var detailModel = await GetGameDetails(viewModel.GameId, viewModel.UserId);
            return RedirectToAction("GameDetail", "Game", detailModel);
        }

        [Authorize]
        public async Task<IActionResult> Restore(int commentId,int gameId, string? userId)
        {
            await _commentService.RestoreCommentAsync(commentId);
            var detailModel = await GetGameDetails(gameId, userId);

            return RedirectToAction("GameDetail", "Game", detailModel);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int commentId, int gameId, string? userId)
        {
            await _commentService.DeleteGeneralAsync(commentId);
            var detailModel = await GetGameDetails(gameId, userId);

            return RedirectToAction("GameDetail", "Game", detailModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string text, int commentId, int gameId, string? userId)
        {
            EditCommentViewModel model = new()
            {
                CommentId = commentId,
                GameId = gameId,
                UserId = userId,
                CommentText = text
            };

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(EditCommentViewModel model)
        {
            await _commentService.EditCommentAsync(model.CommentText, model.CommentId);
            var detailModel = await GetGameDetails(model.GameId, model.UserId);

            return RedirectToAction("GameDetail", "Game", detailModel);
        }

        private async Task<GameDetailViewModel> GetGameDetails(int gameId, string? userId)
        {
            GameModel game = await _gameService.GetGameByIdAsync(gameId);
            var users = webContext.Users.AsEnumerable();
            var list = await _commentService.GetGameComments(gameId, users.Select(u => new UserModel()
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                AvatarPath = u.AvataraPath
            }));
            var detailModel = new GameDetailViewModel()
            {
                UserId = userId,
                GameId = gameId,
                Game = game,
                Comments = list.Where(i => i.IsDeleted == false),
                DeletedComments = list.Any(i => i.User.Id == userId) ? list.Where(i => i.IsDeleted == true && i.User.Id == userId) : null
            };

            return detailModel;
        }

    }
}
