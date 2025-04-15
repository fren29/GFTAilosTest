using Microsoft.AspNetCore.Mvc;
using MediatR;
using Questao5.Infrastructure.Database.CommandStore.Requests;
using Questao5.Infrastructure.Database.CommandStore.Responses;

namespace Questao5.Infrastructure.Services.Controllers;

[ApiController]
[Route("[controller]")]
public class ContaCorrenteController : ControllerBase
{
    private readonly IMediator _mediator;

    public ContaCorrenteController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("movimentacao")]
    public async Task<ActionResult<MovimentarContaResult>> Movimentar([FromBody] MovimentarContaCommand command)
    {
        try
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { erro = ex.Message });
        }
    }
}
