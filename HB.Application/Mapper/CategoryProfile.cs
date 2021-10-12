using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HB.Application.DTOs;
using HB.Domain.Entities;
using HB.Application.Categories.Commands;

namespace HB.Application.Mapper
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryResponseDTO, Category>().ReverseMap();
            CreateMap<CreateCategoryCommand, Category>().ReverseMap();
            CreateMap<UpdateCategoryCommand, Category>().ReverseMap();
        }
    }
}
