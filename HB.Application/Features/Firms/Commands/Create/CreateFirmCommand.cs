using AutoMapper;
using HB.Application.DTOs;
using HB.Domain.Entities;
using HB.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HB.Application.Features.Firms.Commands.Create
{
    public class CreateFirmCommand : IRequest<FirmResponseDTO>
    {
        [Required]
        public string Name { get; set; }
        public string? ManagerName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public int FirmType { get; set; }
    }

    public class CreateFirmCommandHandler : IRequestHandler<CreateFirmCommand, FirmResponseDTO>
    {
        private readonly IFirmRepository _firmRepository;
        private readonly IMapper _mapper;

        public CreateFirmCommandHandler(IFirmRepository categoryRepository, IMapper mapper)
        {
            _firmRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<FirmResponseDTO> Handle(CreateFirmCommand request, CancellationToken cancellationToken)
        {
            var result = await _firmRepository.Add(_mapper.Map<Firm>(request), cancellationToken);
            return _mapper.Map<FirmResponseDTO>(result);
        }
    }
}
