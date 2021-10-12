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

namespace HB.Application.Features.StockItems.Commands.Delete
{
    public class DeleteStockItemCommand : IRequest<StockItemResponseDTO>
    {
        public Guid Id { get; set; }

        public class DeleteStockItemCommandHandler : IRequestHandler<DeleteStockItemCommand, StockItemResponseDTO>
        {
              private readonly IStockItemRepository _stokItemRepository;
              private readonly IMapper _mapper;

        public DeleteStockItemCommandHandler(IStockItemRepository categoryRepository, IMapper mapper)
        {
            _stokItemRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<StockItemResponseDTO> Handle(DeleteStockItemCommand request, CancellationToken cancellationToken)
            {
                StockItem result = await _stokItemRepository.Delete(request.Id, cancellationToken);
                return _mapper.Map<StockItemResponseDTO>(result);
            }
        }
    }
}
