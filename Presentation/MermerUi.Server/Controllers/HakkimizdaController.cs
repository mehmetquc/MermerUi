using MediatR;
using MermerUi.Persistence.Features.Anasayfa.Commands;
using MermerUi.Persistence.Features.Anasayfa.Queries;
using MermerUi.Persistence.Features.Hakkimizda.Commands;
using MermerUi.Persistence.Features.Hakkimizda.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MermerUi.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class HakkimizdaController : ControllerBase
    {
        IMediator _mediator;
        public HakkimizdaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateHakkimizda")]
        public async Task<IActionResult> CreateHakkimizda(CreateHakkimizdaRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }
        [HttpPost("DeleteHakkimizda")]
        public async Task<IActionResult> DeleteHakkimizda(Guid Id, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new DeleteHakkimizdaRequest { Id = Id }, cancellationToken));
        }
        [HttpPost("UpdateHakkimizda")]
        public async Task<IActionResult> UpdateHakkimizda(UpdateHakkimizdaRequets request, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }
        [HttpGet("GetByIdHakkimizda")]
        public async Task<IActionResult> GetByIdHakkimizda([FromQuery] GetByIdHakkimizdaRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }

        [HttpGet("GetAllHakkimizda")]
        public async Task<IActionResult> GetAllHakkimizda(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllHakkimizdaRequest(), cancellationToken));
        }
    }
}
