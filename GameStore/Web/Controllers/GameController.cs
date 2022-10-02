using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.Models;

namespace Web.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameService _gameService;
        private int pageSize = 6;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        public async Task<IActionResult> IndexAsync(GameFilterViewModel viewModel)
        {
            var sort = viewModel.Sort ?? SortType.Unselect;
            var gameList = await _gameService.GetAllGamesByNameAsync(viewModel.Name, sort);

            var pagedList = PagedList<GameModel>.ToPagedList(gameList, viewModel.Page, pageSize);

            var model = new GameFilterViewModel()
            {
                PagedGames = pagedList,
                Sort = sort,
                Name = viewModel.Name
            };
            
            return View(model);
        }

        public async Task<IActionResult> GameDetail(int id)
        {
            var game = await _gameService.GetGameByIdAsync(id);
            return View(game);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}