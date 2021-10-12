using AutoMapper;
using HB.Application.DTOs;
using HB.Application.Mapper;
using HB.Domain.Entities;
using HB.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HB.Application.Categories.Commands
{
    public class CreateCategoryCommand : IRequest<CategoryResponseDTO>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? ParentId { get; set; }
    }

    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryResponseDTO>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<CategoryResponseDTO> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var result =  await _categoryRepository.Add(_mapper.Map<Category>(request), cancellationToken);
            return _mapper.Map<CategoryResponseDTO>(result);
        }
    }
}
