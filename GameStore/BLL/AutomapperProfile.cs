using AutoMapper;
using BLL.Models;
using DataLayer.Entities;

namespace BLL
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<GameCategory, GameCategoryModel>()
                .ForMember(rm => rm.CategoryGamesIds, r => r.MapFrom(g => g.Games.Select(i => i.GameId)))
                .ReverseMap();

            CreateMap<Game, GameModel>()
                .ForMember(rm => rm.Categories, r => r.MapFrom(i => i.Categories.Select(c => c.Category.Name)))
                .ReverseMap();
        }
    }
}
