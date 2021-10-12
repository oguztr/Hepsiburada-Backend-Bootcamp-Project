using AutoMapper;
using HB.Application.DTOs;
using HB.Application.Features.Firms.Commands.Create;
using HB.Application.Features.Firms.Commands.Delete;
using HB.Application.Features.Firms.Commands.Update;
using HB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB.Application.Mapper
{
    public class FirmProfile : Profile
    {
        public FirmProfile()
        {
            CreateMap<FirmResponseDTO, Firm>().ReverseMap();
            CreateMap<CreateFirmCommand, Firm>().ReverseMap();
            CreateMap<UpdateFirmCommand, Firm>().ReverseMap();
            CreateMap<DeleteFirmCommand, Firm>().ReverseMap();
        }
    }
}
