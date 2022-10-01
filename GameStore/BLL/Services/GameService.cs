using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DataLayer.Data;
using DataLayer.Entities;
using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class GameService : IGameService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GameService(IUnitOfWork unitOfWork,
                           IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GameModel>> GetAllGamesByNameAsync(string? name, SortType sort)
        {
            var Games = await _unitOfWork.Games.GetAllGamesWithCategories();

            switch (sort)
            {
                case SortType.Unselect:
                case SortType.New: Games = Games.OrderByDescending(i => i.Id); break;
                case SortType.Free: Games = Games.Where(i => i.Price == 0); break;
                case SortType.Popular: Games = Games.OrderByDescending(i => i.Sold); break;
            }
            
            var gameModels = Games.Select(i => _mapper.Map<GameModel>(i));

            if (!(string.IsNullOrEmpty(name)))
                return gameModels.Where(i => i.Name.ToLower().Contains(name.ToLower())).ToList();

            if (Games.Count() == 0)
            {
                AddMockData().Wait();
            }

            return gameModels;
        }

        public async Task AddMockData()
        {
            var dbContext = new MockDBContext();

            foreach (var category in dbContext.Categories)
            {
                await _unitOfWork.GameCategories.AddAsync(category);
                await _unitOfWork.SaveAsync();
            }

            foreach (var game in dbContext.Games)
            {
                await _unitOfWork.Games.AddAsync(game);
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task<GameModel> GetGameByIdAsync(int id)
            => _mapper.Map<GameModel>(await _unitOfWork.Games.GetByIdWithCategories(id));
    }
}
