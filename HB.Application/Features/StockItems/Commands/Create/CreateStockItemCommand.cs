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

namespace HB.Application.Features.StockItems.Commands.Create
{
    public class CreateStockItemCommand : IRequest<StockItemResponseDTO>
    {
        public Guid? CategoryId { get; set; }
        public string Name { get; set; }
        public string SerieNo { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }

        public class CreateStockItemCommandHandler : IRequestHandler<CreateStockItemCommand, StockItemResponseDTO>
        {
            private readonly IStockItemRepository _stokItemRepository;
            private readonly IMapper _mapper;

            public CreateStockItemCommandHandler(IStockItemRepository categoryRepository, IMapper mapper)
            {
                _stokItemRepository = categoryRepository;
                _mapper = mapper;
            }
            public async Task<StockItemResponseDTO> Handle(CreateStockItemCommand request, CancellationToken cancellationToken)
            {
                var result = await _stokItemRepository.Add(_mapper.Map<StockItem>(request), cancellationToken);
                return _mapper.Map<StockItemResponseDTO>(result);
            }
        }
    }
}
