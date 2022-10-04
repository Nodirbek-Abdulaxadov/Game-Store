using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.Models;
using Web.Services;

namespace Web.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameService _gameService;
        private readonly IFileService _fileService;
        private readonly IGameCategoryService _categoryService;
        private int pageSize = 6;

        public GameController(IGameService gameService,
                              IFileService fileService,
                              IGameCategoryService categoryService)
        {
            _gameService = gameService;
            _fileService = fileService;
            _categoryService = categoryService;
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

        public async Task<IActionResult> GameDetail(int id)
        {
            var game = await _gameService.GetGameByIdAsync(id);
            return View(game);
        }

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

                var result = await _gameService.AddGameAsync(viewModel.Name, viewModel.Description, viewModel.Price,
                                                        _fileService.UploadImage(viewModel.ImageFile), viewModel.SelectedCategories.Where(c => c.IsChecked == true).Select(i => i.Name).ToList());
                return RedirectToAction("gamedetail", result);
            }

            var categories = await _categoryService.GetAllGameCategoriesAsync();
            var model = new AddGameViewModel()
            {
                SelectedCategories = categories.Select(c => new CategorySelect() { Name = c.Name }).ToList()
            };
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}