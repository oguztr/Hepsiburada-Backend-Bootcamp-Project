using HB.Application.DTOs;
using HB.Application.Features.Firms.Commands.Create;
using HB.Application.Features.Firms.Commands.Delete;
using HB.Application.Features.Firms.Commands.Update;
using HB.Application.Features.Firms.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HB.Api.Controllers
{
    [Route("api/firms")]
    [ApiController]
    public class FirmController : BaseController
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<FirmResponseDTO>> Get(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetFirmByIdQuery { Id = id }, cancellationToken));
        }
        [HttpGet()]
        public async Task<ActionResult<List<FirmResponseDTO>>> GetAll(CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetAllFirmsQuery(), cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateFirmCommand command, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid) return BadRequest();
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpPut]
        public async Task Put(UpdateFirmCommand command, CancellationToken cancellationToken)
        {
            await Mediator.Send(command, cancellationToken);
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id, CancellationToken cancellationToken)
        {
            await Mediator.Send(new DeleteFirmCommand { Id = id }, cancellationToken);
        }
    }
}
