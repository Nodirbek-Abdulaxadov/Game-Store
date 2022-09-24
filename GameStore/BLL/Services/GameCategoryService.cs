using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DataLayer.Entities;
using DataLayer.Interfaces;

namespace BLL.Services
{
    public class GameCategoryService : IGameCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GameCategoryService(IUnitOfWork unitOfWork,
                                   IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddGameCategoryAsync(string name)
        {
            await _unitOfWork.GameCategories.AddAsync(
                _mapper.Map<GameCategory>(new GameCategoryModel() { Name = name }));
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteGameCategoryByIdAsync(int categoryId)
        {
            await _unitOfWork.GameCategories.DeleteByIdAsync(categoryId);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<GameCategoryModel>> GetAllGameCategoriesAsync()
            => (await _unitOfWork.GameCategories.GetAllAsync())
                                                .Select(i => _mapper.Map<GameCategoryModel>(i));

        public async Task UpdateCategoryAsync(GameCategoryModel model)
        {
            _unitOfWork.GameCategories.Update(_mapper.Map<GameCategory>(model));
            await _unitOfWork.SaveAsync();
        }
    }
}
