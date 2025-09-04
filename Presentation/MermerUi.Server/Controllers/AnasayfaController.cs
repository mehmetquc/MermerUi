using MediatR;
using MermerUi.Persistence.Features.Anasayfa.Commands;
using MermerUi.Persistence.Features.Anasayfa.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MermerUi.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AnasayfaController : ControllerBase
    {

        IMediator _mediator;
        public AnasayfaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateAnasayfa")]
        public async Task<IActionResult> CreateAnasayfa(CreateAnasayfaRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }
        [HttpPost("DeleteAnasayfa")]
        public async Task<IActionResult> DeleteAnasayfa(Guid Id,CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new DeleteAnasayfaRequest { Id = Id}, cancellationToken));
        }
        [HttpPost("UpdateAnasayfa")]
        public async Task<IActionResult> UpdateAnasayfa(UpdateAnasayfaRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }
        [HttpGet("GetByIdAnasayfa")]
        public async Task<IActionResult> GetByIdAnasayfa([FromQuery] GetByIdAnasayfaRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }
      
        [HttpGet("GetAllAnasayfa")]
        public async Task<IActionResult> GetAllAnasayfa(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllAnasayfaRequest(), cancellationToken));
        }
    }
}
