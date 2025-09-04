using MediatR;
using MermerUi.Persistence.Features.Anasayfa.Commands;
using MermerUi.Persistence.Features.Anasayfa.Queries;
using MermerUi.Persistence.Features.User.Commands;
using MermerUi.Persistence.Features.User.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MermerUi.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class UserController : ControllerBase
    {
        IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult>CreateUser(CreateUserRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }
        [HttpPost("DeleteUser")]
        public async Task<IActionResult> DeleteUser(Guid Id, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new DeleteUserRequest { Id = Id }, cancellationToken));
        }
        [HttpPost("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }
        [HttpGet("GetByIdUser")]
        public async Task<IActionResult> GetByIdUser([FromQuery] GetByIdUserRequest request, CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(request, cancellationToken));
        }

        [HttpGet("GetAllUser")]
        public async Task<IActionResult> GetAllUser(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetAllUserRequest(), cancellationToken));
        }
    }
}
