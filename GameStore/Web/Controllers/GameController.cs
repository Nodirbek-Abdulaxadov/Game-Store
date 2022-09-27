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
            var gameList = await _gameService.GetAllGamesByNameAsync(viewModel.Name);

            var pagedList = PagedList<GameModel>.ToPagedList(gameList, viewModel.Page, pageSize);

            var model = new GameFilterViewModel()
            {
                PagedGames = pagedList,
                Sort = viewModel.Sort ?? SortType.New,
                Name = viewModel.Name
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