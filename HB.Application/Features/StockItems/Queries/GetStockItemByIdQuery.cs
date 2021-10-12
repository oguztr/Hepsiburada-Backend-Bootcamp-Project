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

namespace HB.Application.Features.StockItems.Queries
{
    public class GetStockItemByIdQuery : IRequest<StockItemResponseDTO>
    {
        public Guid Id { get; set; }
        public class GetStockItemByIdQueryHandler : IRequestHandler<GetStockItemByIdQuery, StockItemResponseDTO>
        {
            private readonly IStockItemRepository _stokItemRepository;
            private readonly IMapper _mapper;

            public GetStockItemByIdQueryHandler(IStockItemRepository categoryRepository, IMapper mapper)
            {
                _stokItemRepository = categoryRepository;
                _mapper = mapper;
            }
            public async Task<StockItemResponseDTO> Handle(GetStockItemByIdQuery request, CancellationToken cancellationToken)
            {
                var result = await _stokItemRepository.GetById(request.Id, cancellationToken);
                return _mapper.Map<StockItem, StockItemResponseDTO>(result);
            }
        }
    }
}
