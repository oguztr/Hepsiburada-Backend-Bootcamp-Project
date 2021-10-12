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

namespace HB.Application.Features.Firms.Commands.Delete
{
    public class DeleteFirmCommand : IRequest<FirmResponseDTO>
    {
        public Guid Id { get; set; }

        public class DeleteFirmCommandHandler : IRequestHandler<DeleteFirmCommand, FirmResponseDTO>
        {
            private readonly IFirmRepository _firmRepository;
            private readonly IMapper _mapper;

            public DeleteFirmCommandHandler(IFirmRepository firmRepository , IMapper mapper)
            {
                _firmRepository = firmRepository;
                _mapper = mapper;
            }
            public async Task<FirmResponseDTO> Handle(DeleteFirmCommand request, CancellationToken cancellationToken)
            {
                Firm result = await _firmRepository.Delete(request.Id, cancellationToken);
                return _mapper.Map<FirmResponseDTO>(result);
            }
        }
    }
}
