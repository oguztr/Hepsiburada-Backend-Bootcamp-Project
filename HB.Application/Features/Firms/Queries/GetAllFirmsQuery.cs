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
    public class GetAllFirmsQuery : IRequest<List<FirmResponseDTO>>
    {
        public class GetAllFirmsQueryHandler : IRequestHandler<GetAllFirmsQuery, List<FirmResponseDTO>>
        {
            private readonly IFirmRepository _firmRepository;
            private readonly IMapper _mapper;

            public GetAllFirmsQueryHandler(IFirmRepository firmRepository, IMapper mapper)
            {
                _firmRepository = firmRepository;
                _mapper = mapper;
            }
            public async Task<List<FirmResponseDTO>> Handle(GetAllFirmsQuery request, CancellationToken cancellationToken)
            {
                var result = await _firmRepository.GetAll(cancellationToken);
                return _mapper.Map<List<Firm>, List<FirmResponseDTO>>(result);
            }
        }
    }
}
