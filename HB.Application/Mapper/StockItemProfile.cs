using AutoMapper;
using HB.Application.DTOs;
using HB.Application.Features.StockItems.Commands.Create;
using HB.Application.Features.StockItems.Commands.Delete;
using HB.Application.Features.StockItems.Queries;
using HB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB.Application.Mapper
{
    class StockItemProfile : Profile
    {
        public StockItemProfile()
        {
            CreateMap<StockItemResponseDTO, StockItem>().ReverseMap();
            CreateMap<CreateStockItemCommand, StockItem>().ReverseMap();
            CreateMap<GetStockItemByIdQuery, StockItem>().ReverseMap();
            CreateMap<DeleteStockItemCommand, StockItem>().ReverseMap();
        }
    }
}
