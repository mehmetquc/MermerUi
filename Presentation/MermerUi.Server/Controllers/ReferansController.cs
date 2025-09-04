using MediatR;
using MermerUi.Persistence.Features.Anasayfa.Commands;
using MermerUi.Persistence.Features.Anasayfa.Queries;
using MermerUi.Persistence.Features.Referans.Commands;
using MermerUi.Persistence.Features.Referans.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MermerUi.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ReferansController : ControllerBase
    {
        IMediator _mediator;
        public ReferansController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("CreateReferans")]
        public async Task<IActionResult> CreateReferans(CreateReferansRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }
        [HttpPost("DeleteReferans")]
        public async Task<IActionResult> DeleteReferans(Guid Id, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new DeleteReferansRequest { Id = Id }, cancellationToken));
        }
        [HttpPost("UpdateReferans")]
        public async Task<IActionResult> UpdateReferans(UpdateReferansRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }
        [HttpGet("GetByIdReferans")]
        public async Task<IActionResult> GetByIdReferans([FromQuery] GetByIdReferansRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }

        [HttpGet("GetAllReferans")]
        public async Task<IActionResult> GetAllReferans(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllReferansRequest(), cancellationToken));
        }
    }
}
