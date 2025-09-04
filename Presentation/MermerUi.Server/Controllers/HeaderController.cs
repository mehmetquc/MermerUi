using MediatR;
using MermerUi.Persistence.Features.Anasayfa.Commands;
using MermerUi.Persistence.Features.Anasayfa.Queries;
using MermerUi.Persistence.Features.Header.Commands;
using MermerUi.Persistence.Features.Header.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MermerUi.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class HeaderController : ControllerBase
    {
        IMediator _mediator;
        public HeaderController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("CreateHeader")]
        public async Task<IActionResult> CreateHeader(CreateHeaderRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }
        [HttpPost("DeleteHeader")]
        public async Task<IActionResult> DeleteHeader(Guid Id, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new DeleteHeaderRequest { Id = Id }, cancellationToken));
        }
        [HttpPost("UpdateHeader")]
        public async Task<IActionResult> UpdateHeader(UpdateHeaderRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }
        [HttpGet("GetByIdHeader")]
        public async Task<IActionResult> GetByIdHeader([FromQuery] GetByIdHeaderRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }

        [HttpGet("GetAllHeader")]
        public async Task<IActionResult> GetAllHeader(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllHeaderRequest(), cancellationToken));
        }
    }
}
