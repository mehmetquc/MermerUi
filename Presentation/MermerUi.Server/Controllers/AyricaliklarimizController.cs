using MediatR;
using MermerUi.Persistence.Features.Anasayfa.Commands;
using MermerUi.Persistence.Features.Anasayfa.Queries;
using MermerUi.Persistence.Features.Ayricaliklarimiz.Commands;
using MermerUi.Persistence.Features.Ayricaliklarimiz.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MermerUi.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class AyricaliklarimizController : ControllerBase
    {
        IMediator _mediator;
        public AyricaliklarimizController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateAyricaliklarimiz")]
        public async Task<IActionResult> CreateAyricaliklarimiz(CreateAyricaliklarimizRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }
        [HttpPost("DeleteAyricaliklarimiz")]
        public async Task<IActionResult> DeleteAyricaliklarimiz(Guid Id, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new DeleteAyricaliklarimizRequest {Id = Id}, cancellationToken));
        }
        [HttpPost("UpdateAyricaliklarimiz")]
        public async Task<IActionResult> UpdateAyricaliklarimiz(UpdateAyricaliklarimizRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }
        [HttpGet("GetByIdAyricaliklarimiz")]
        public async Task<IActionResult> GetByIdAyricaliklarimiz([FromQuery] GetByIdAyricaliklarimizRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }

        [HttpGet("GetAllAyricaliklarimiz")]
        public async Task<IActionResult> GetAllAyricaliklarimiz(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllAyricaliklarimizRequest(), cancellationToken));
        }
    }
}
