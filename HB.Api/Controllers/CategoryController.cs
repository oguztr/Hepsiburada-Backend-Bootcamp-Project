using HB.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using HB.Application.Categories.Queries;
using HB.Application.Categories.Commands;
using HB.Application.Features.Categories.Commands.Delete;
using Serilog;

namespace HB.Api.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : BaseController
    {
      
        [HttpGet("")]
        public async Task<ActionResult<List<CategoryResponseDTO>>> GetAll(CancellationToken cancellationToken)
        {
            Log.Information("Get All - Category");
            return Ok(await Mediator.Send(new GetAllCategoriesQuery(),cancellationToken));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryResponseDTO>> Get(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetCategoryByIdQuery { Id = id }, cancellationToken));
        }

        [HttpPost]
        public async Task<ActionResult<CategoryResponseDTO>> Post(CreateCategoryCommand command, CancellationToken cancellationToken)
        {
            return CreatedAtAction(nameof(Post),await Mediator.Send(command, cancellationToken));
        }

        [HttpPut]
        public async Task<ActionResult<CategoryResponseDTO>> Put(UpdateCategoryCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoryResponseDTO>> Delete(Guid id,CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new DeleteCategoryCommand { Id = id }, cancellationToken));
        }

    }
}
