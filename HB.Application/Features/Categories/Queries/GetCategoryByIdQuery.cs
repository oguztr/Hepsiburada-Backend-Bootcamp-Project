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

namespace HB.Application.Categories.Queries
{
    public class GetCategoryByIdQuery : IRequest<CategoryResponseDTO>
    {
        public Guid Id { get; set; }
    }
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, CategoryResponseDTO>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryByIdHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<CategoryResponseDTO> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _categoryRepository.GetById(request.Id, cancellationToken);
            return _mapper.Map<Category, CategoryResponseDTO>(result);
        }
    }
}
