using AutoMapper;
using HB.Application.DTOs;
using HB.Domain.Entities;
using HB.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HB.Application.Features.Firms.Queries
{
    public class GetFirmByIdQuery : IRequest<FirmResponseDTO>
    {
        public Guid Id { get; set; }
    }
    public class GetFirmByIdQueryHandler : IRequestHandler<GetFirmByIdQuery, FirmResponseDTO>
    {
        private readonly IFirmRepository _firmRepository;
        private readonly IMapper _mapper;

        public GetFirmByIdQueryHandler(IFirmRepository firmRepository, IMapper mapper)
        {
            _firmRepository = firmRepository;
            _mapper = mapper;
        }
        public async Task<FirmResponseDTO> Handle(GetFirmByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _firmRepository.GetById(request.Id, cancellationToken);
            return _mapper.Map<Firm, FirmResponseDTO>(result);
        }
    }
}
