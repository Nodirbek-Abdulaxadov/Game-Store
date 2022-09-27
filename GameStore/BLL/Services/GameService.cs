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
        public async Task<IEnumerable<GameModel>> GetAllGamesByNameAsync(string? name)
        {
            var Games = (await _unitOfWork.Games.GetAllAsync())
                                       .Select(i => _mapper.Map<GameModel>(i));

            if (!(string.IsNullOrEmpty(name)))
                return Games.Where(i => i.Name.ToLower().Contains(name.ToLower())).ToList();

            if (Games.Count() == 0)
            {
                AddMockData().Wait();
            }

            return Games;
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
    }
}
