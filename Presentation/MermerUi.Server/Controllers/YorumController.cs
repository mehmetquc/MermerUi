using MediatR;
using MermerUi.Persistence.Features.Anasayfa.Commands;
using MermerUi.Persistence.Features.Anasayfa.Queries;
using MermerUi.Persistence.Features.Yorum.Commands;
using MermerUi.Persistence.Features.Yorum.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MermerUi.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class YorumController : ControllerBase
    {

        IMediator _mediator;
        public YorumController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateYorum")]
        public async Task<IActionResult> CreateYorum(CreateYorumRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }
        [HttpPost("DeleteYorum")]
        public async Task<IActionResult> DeleteYorum(Guid Id, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new DeleteYorumRequest { Id = Id }, cancellationToken));
        }
        [HttpPost("UpdateYorum")]
        public async Task<IActionResult>UpdateYorum(UpdateYorumRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }
        [HttpGet("GetByIdYorum")]
        public async Task<IActionResult> GetByIdYorum([FromQuery] GetByIdYorumRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }

        [HttpGet("GetAllYorum")]
        public async Task<IActionResult> GetAllYorum(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllYorumRequest(), cancellationToken));
        }

    }
}
