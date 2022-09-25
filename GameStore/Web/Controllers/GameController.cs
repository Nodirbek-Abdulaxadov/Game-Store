using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PagedList;
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

        public async Task<IActionResult> IndexAsync(int? page)
        {
            var gameList = await _gameService.GetAllGamesAsync();
            gameList = gameList.ToPagedList(page ?? 1, pageSize);
            ViewBag.PageCount = gameList.ToPagedList(page ?? 1, pageSize);
            return View(gameList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}