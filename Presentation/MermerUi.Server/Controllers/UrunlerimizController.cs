using MediatR;
using MermerUi.Persistence.Features.Anasayfa.Commands;
using MermerUi.Persistence.Features.Anasayfa.Queries;
using MermerUi.Persistence.Features.Urunlerimiz.Commands;
using MermerUi.Persistence.Features.Urunlerimiz.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MermerUi.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UrunlerimizController : ControllerBase
    {
        IMediator _mediator;
        public UrunlerimizController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateUrunlerimiz")]
        public async Task<IActionResult> CreateUrunlerimiz(CreateUrunlerimizRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }
        [HttpPost("DeleteUrunlerimiz")]
        public async Task<IActionResult> DeleteUrunlerimiz(Guid Id, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new DeleteUrunlerimizRequest { Id = Id }, cancellationToken));
        }
        [HttpPost("UpdateUrunlerimiz")]
        public async Task<IActionResult> UpdateUrunlerimiz(UpdateUrunlerimizRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }
        [HttpGet("GetByIdUrunlerimiz")]
        public async Task<IActionResult> GetByIdUrunlerimiz([FromQuery] GetByIdUrunlerimizRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }

        [HttpGet("GetAllUrunlerimiz")]
        public async Task<IActionResult> GetAllUrunlerimiz(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllUrunlerimizRequest(), cancellationToken));
        }

    }
}
