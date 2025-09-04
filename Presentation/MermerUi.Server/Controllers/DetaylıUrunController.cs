using MediatR;
using MermerUi.Persistence.Features.Anasayfa.Commands;
using MermerUi.Persistence.Features.Anasayfa.Queries;
using MermerUi.Persistence.Features.DetaylıUrun.Commands;
using MermerUi.Persistence.Features.DetaylıUrun.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MermerUi.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class DetaylıUrunController : ControllerBase
    {
        IMediator _mediator;
        public DetaylıUrunController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateDetaylıUrun")]
        public async Task<IActionResult>CreateDetaylıUrun(CreateDetaylıUrunRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }
        [HttpPost("DeleteDetaylı")]
        public async Task<IActionResult> DeleteDetaylı(Guid Id, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new DeleteDetaylıUrunRequest { Id = Id }, cancellationToken));
        }
        [HttpPost("UpdateDetaylıUrun")]
        public async Task<IActionResult> UpdateDetaylıUrun(UpdateDetaylıUrunRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }
        [HttpGet("GetByIdDetaylıUrun")]
        public async Task<IActionResult> GetByIdDetaylıUrun([FromQuery] GetByIdDetaylıUrunRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }

        [HttpGet("GetAllDetaylıUrun")]
        public async Task<IActionResult> GetAllDetaylıUrun(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllDetaylıUrunRequest(), cancellationToken));
        }
    }
}
