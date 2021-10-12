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
    public class GetAllCategoriesQuery : IRequest<List<CategoryResponseDTO>>
    {
    }

    public class GetAllQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryResponseDTO>>
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public GetAllQueryHandler(IRepository<Category> categoryRepository,IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<List<CategoryResponseDTO>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            List<Category> result= await _categoryRepository.GetAll(cancellationToken);
            return _mapper.Map<List<CategoryResponseDTO>>(result);
        }
    }
}
