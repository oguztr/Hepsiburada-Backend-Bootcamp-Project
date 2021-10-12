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

namespace HB.Application.Features.Firms.Commands.Update
{
     public class UpdateFirmCommand : IRequest<FirmResponseDTO>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? ManagerName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public int FirmType { get; set; }

        public class UpdateFirmCommandHandler : IRequestHandler<UpdateFirmCommand, FirmResponseDTO>
        {
            private readonly IFirmRepository _firmRepository;
            private readonly IMapper _mapper;

            public UpdateFirmCommandHandler( IFirmRepository firmRepository, IMapper mapper)
            {
                _firmRepository = firmRepository;
                _mapper = mapper;
            }
            public async Task<FirmResponseDTO> Handle(UpdateFirmCommand request, CancellationToken cancellationToken)
            {
                var result = await _firmRepository.Update(_mapper.Map<Firm>(request), cancellationToken);
                return _mapper.Map<FirmResponseDTO>(result);
            }
        }
    }
}
