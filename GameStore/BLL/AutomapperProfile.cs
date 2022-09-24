using AutoMapper;
using BLL.Models;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<GameCategory, GameCategoryModel>().ReverseMap();
        }
    }
}
