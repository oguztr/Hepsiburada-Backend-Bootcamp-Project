using HB.Application.DTOs;
using HB.Application.Features.StockItems.Commands.Create;
using HB.Application.Features.StockItems.Commands.Delete;
using HB.Application.Features.StockItems.Commands.Update;
using HB.Application.Features.StockItems.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HB.Api.Controllers
{
    [Route("api/items")]
    [ApiController]
    public class StockItemController : BaseController
    {
       

        [HttpGet("{id}")]
        public async Task<ActionResult<StockItemResponseDTO>> Get(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetStockItemByIdQuery { Id = id }, cancellationToken));
        }

        [HttpPost]
        public async Task<ActionResult<StockItemResponseDTO>> Post(CreateStockItemCommand command, CancellationToken cancellationToken)
        {
            return CreatedAtAction(nameof(Post), await Mediator.Send(command, cancellationToken));
        }

        [HttpPut]
        public async Task<ActionResult<StockItemResponseDTO>> Put(UpdateStockItemCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<StockItemResponseDTO>> Delete(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new DeleteStockItemCommand { Id = id }, cancellationToken));
        }
    }
}
