using AutoMapper;
using HB.Application.DTOs;
using HB.Domain.Entities;
using HB.Domain.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HB.Application.Categories.Commands
{
    public class UpdateCategoryCommand : IRequest<CategoryResponseDTO>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? ParentId { get; set; }
        public int isActive { get; set; }
    }

    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CategoryResponseDTO>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<CategoryResponseDTO> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = await _categoryRepository.Update(_mapper.Map<Category>(request) ,cancellationToken );
            return _mapper.Map<CategoryResponseDTO>(result);
        }
    }

}
