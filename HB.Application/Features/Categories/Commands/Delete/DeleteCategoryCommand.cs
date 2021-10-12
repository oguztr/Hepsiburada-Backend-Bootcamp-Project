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

namespace HB.Application.Features.Categories.Commands.Delete
{
    public class DeleteCategoryCommand : IRequest<CategoryResponseDTO>
    {
        public Guid Id { get; set; }

        public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, CategoryResponseDTO>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;

            public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
            }
            public async Task<CategoryResponseDTO> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
            {
                Category result = await _categoryRepository.Delete(request.Id,cancellationToken);
                return _mapper.Map<CategoryResponseDTO>(result);
            }
        }
    }

    
}
