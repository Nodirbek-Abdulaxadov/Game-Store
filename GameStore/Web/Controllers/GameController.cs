using BLL.Interfaces;
using BLL.Models;
using DataLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Web.Areas.Identity.Data;
using Web.Data;
using Web.Models;
using Web.Services;

namespace Web.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameService _gameService;
        private readonly IFileService _fileService;
        private readonly IGameCategoryService _categoryService;
        private readonly ICommentService _commentService;
        private readonly WebContext _userManager;
        private int pageSize = 6;

        public GameController(IGameService gameService,
                              IFileService fileService,
                              IGameCategoryService categoryService,
                              ICommentService commentService,
                              WebContext userManager)
        {
            _gameService = gameService;
            _fileService = fileService;
            _categoryService = categoryService;
            _commentService = commentService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(GameFilterViewModel viewModel)
        {
            var sort = viewModel.Sort ?? SortType.Unselect;
            var gameList = await _gameService.GetAllGamesByNameAsync(viewModel.Name, sort);

            var pagedList = PagedList<GameModel>.ToPagedList(gameList, viewModel.Page, pageSize);

            var model = new GameFilterViewModel()
            {
                PagedGames = pagedList,
                Sort = sort,
                Name = viewModel.Name,
                Categories = await _categoryService.GetAllGameCategoriesAsync()
            };
            
            return View(model);
        }

        public async Task<IActionResult> Category(GameFilterViewModel viewModel)
        {
            var gameList = await _gameService.GetGamesByCategoryId(viewModel.categoryId);

            var pagedList = PagedList<GameModel>.ToPagedList(gameList, viewModel.Page, pageSize);

            var model = new GameFilterViewModel()
            {
                PagedGames = pagedList,
                Categories = await _categoryService.GetAllGameCategoriesAsync(),
                categoryId = viewModel.categoryId
            };

            return View(model);
        }

        public async Task<IActionResult> GameDetail(int gameId, string? userId)
        {
            var detailModel = await GetGameDetails(gameId, userId);
            return View(detailModel);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await _categoryService.GetAllGameCategoriesAsync();
            var model = new AddGameViewModel()
            {
                SelectedCategories = categories.Select(c => new CategorySelect() { Name = c.Name }).ToList()
            };
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(AddGameViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _gameService.Exist(viewModel.Name))
                {
                    ModelState.AddModelError(nameof(viewModel.Name), "This name already exist!");
                    return View(viewModel);
                }

                if (!viewModel.SelectedCategories.Any(i => i.IsChecked == true))
                {
                    ModelState.AddModelError(nameof(viewModel.SelectedCategories), "You must select at last one category!");
                    return View(viewModel);
                }

                var result = await _gameService.AddGameAsync(viewModel.Name, viewModel.Description, viewModel.Price,
                                                        _fileService.UploadImage(viewModel.ImageFile), viewModel.SelectedCategories.Where(c => c.IsChecked == true).Select(i => i.Name).ToList());


                var vm = await GetGameDetails(result.Id, "");
                return RedirectToAction("GameDetail", vm);
            }

            var categories = await _categoryService.GetAllGameCategoriesAsync();
            var model = new AddGameViewModel()
            {
                SelectedCategories = categories.Select(c => new CategorySelect() { Name = c.Name }).ToList()
            };
            return View(model);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var game = await _gameService.GetGameByIdAsync(id);
            var categories = await _categoryService.GetAllGameCategoriesAsync();
            List<CategorySelect> categorySelects = new List<CategorySelect>();
            foreach (var c in categories)
            {
                bool exist = false;
                if (game.Categories.Any(i => i.Name == c.Name))
                {
                    exist = true;
                }
                categorySelects.Add(new CategorySelect() { Name = c.Name, IsChecked = exist });
            }

            var editModel = new EditGameViewModel()
            {
                Id = game.Id,
                Name = game.Name,
                Description = game.Description ?? "",
                ImagePath = game.ImagePath ?? "",
                Price = game.Price,
                SelectedCategories = categorySelects
            };
            return View(editModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(EditGameViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (await _gameService.Exist(viewModel.Name) && 
                   (await _gameService.GetAllGamesAsync()).Count(i => i.Name == viewModel.Name) > 1)
                {
                    ModelState.AddModelError(nameof(viewModel.Name), "This name already exist!");
                    return View(viewModel);
                }

                if (!viewModel.SelectedCategories.Any(i => i.IsChecked == true))
                {
                    ModelState.AddModelError(nameof(viewModel.SelectedCategories), "You must select at last one category!");
                    return View(viewModel);
                }

                if (viewModel.ImageFile != null)
                {
                    _fileService.DeleteImage(viewModel.ImagePath);
                    viewModel.ImagePath = _fileService.UploadImage(viewModel.ImageFile);
                }

                var categories = (await _categoryService.GetAllGameCategoriesAsync())
                                                        .Where(i => viewModel.SelectedCategories
                                                        .Any(m => m.Name == i.Name && m.IsChecked == true))
                                                        .ToList();

                var game = new GameModel()
                {
                    Id = viewModel.Id,
                    Name = viewModel.Name,
                    Price = viewModel.Price,
                    Description = viewModel.Description,
                    ImagePath = viewModel.ImagePath,
                    Categories = categories
                };

                game = await _gameService.UpdateGame(game);

                var vm = await GetGameDetails(game.Id, "");
                return RedirectToAction("GameDetail", vm);
            }

            return View(viewModel);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var users = _userManager.Users.Select(u => new UserModel()
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                AvatarPath = u.AvataraPath
            }).AsEnumerable();

            var game = await _gameService.GetGameByIdAsync(id);
            _fileService.DeleteImage(game.ImagePath);
            await _gameService.Delete(game, users);

            return RedirectToAction("index");
        }

        [Authorize]
        public async Task<IActionResult> DeleteComment(int commentId, int gameId, string? userId)
        {
            await _commentService.DeleteCommentAsync(commentId);
            var model = await GetGameDetails(gameId, userId);
            return RedirectToAction("GameDetail", model);
        }

        [Authorize]
        public async Task<IActionResult> AddComment(GameDetailViewModel model)
        {
            var game = await _gameService.GetGameByIdAsync(model.GameId);
            var users = _userManager.Users.AsEnumerable();
            var detailModel = await GetGameDetails(model.GameId, model.UserId);
            if (!(string.IsNullOrEmpty(model.Text)))
            {
                var gameId = await _commentService.AddComment(model.Text, model.GameId, model.UserId);

                var list = await _commentService.GetGameComments(gameId, users.Select(u => new UserModel()
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    AvatarPath = u.AvataraPath
                }));
                return RedirectToAction("GameDetail", detailModel);
            }

            ViewData["Error"] = "Enter at least 3 letters!";
            return RedirectToAction("GameDetail", detailModel);
        }

        private async Task<GameDetailViewModel> GetGameDetails(int gameId, string? userId)
        {
            GameModel game = await _gameService.GetGameByIdAsync(gameId);
            var users = _userManager.Users.AsEnumerable();
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