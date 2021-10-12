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

namespace HB.Application.Features.StockItems.Commands.Update
{

      public class UpdateStockItemCommand : IRequest<StockItemResponseDTO>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? ParentId { get; set; }
        public int isActive { get; set; }
    }

    public class UpdateStockItemCommandHandler : IRequestHandler<UpdateStockItemCommand, StockItemResponseDTO>
    {
        private readonly IStockItemRepository _stockItemRepository;
        private readonly IMapper _mapper;

        public UpdateStockItemCommandHandler(IStockItemRepository stockItemRepository, IMapper mapper)
        {
            _stockItemRepository = stockItemRepository;
            _mapper = mapper;
        }
        public async Task<StockItemResponseDTO> Handle(UpdateStockItemCommand request, CancellationToken cancellationToken)
        {
            var result = await _stockItemRepository.Update(_mapper.Map<StockItem>(request), cancellationToken);
            return _mapper.Map<StockItemResponseDTO>(result);
        }
    }
}
