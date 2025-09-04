using MediatR;
using MermerUi.Persistence.Features.Anasayfa.Commands;
using MermerUi.Persistence.Features.Anasayfa.Queries;
using MermerUi.Persistence.Features.YıldızUrun.Commands;
using MermerUi.Persistence.Features.YıldızUrun.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MermerUi.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class YıldızUrunController : ControllerBase
    {
        IMediator _mediator;
        public YıldızUrunController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateYıldızUrun")]
        public async Task<IActionResult> CreateYıldızUrun(CreateYıldızUrunRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }
        [HttpPost("DeleteYıldızUrun")]
        public async Task<IActionResult> DeleteYıldızUrun(Guid Id, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new DeleteYıldızUrunRequest { Id = Id }, cancellationToken));
        }
        [HttpPost("UpdateYıldızUrun")]
        public async Task<IActionResult> UpdateYıldızUrun(UpdateYıldızUrunRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }
        [HttpGet("GetByIdYıldızUrun")]
        public async Task<IActionResult> GetByIdYıldızUrun([FromQuery] GetByIdYıldızUrunRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }

        [HttpGet("GetAllYıldızUrun")]
        public async Task<IActionResult> GetAllYıldızUrun(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllYıldızUrunRequest(), cancellationToken));
        }

    }
}
