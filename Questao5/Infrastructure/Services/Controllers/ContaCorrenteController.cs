using Microsoft.AspNetCore.Mvc;
using Questao5.Infrastructure.Database.QueryStore.Requests;
using MediatR;
using Questao5.Infrastructure.Database.CommandStore.Requests;
using Questao5.Infrastructure.Database.CommandStore.Responses;
using Swashbuckle.AspNetCore.Annotations;
using Questao5.Infrastructure.Database.QueryStore.Responses;

namespace Questao5.Infrastructure.Services.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class ContaCorrenteController : ControllerBase
{
    private readonly IMediator _mediator;

    public ContaCorrenteController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Realiza movimentação em uma conta corrente (crédito ou débito).
    /// </summary>
    /// <param name="command">Dados da movimentação.</param>
    /// <returns>ID do movimento criado.</returns>
    [HttpPost("movimentacao")]
    [ProducesResponseType(typeof(MovimentarContaResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
    [SwaggerOperation(Summary = "Movimenta uma conta corrente", Description = "Permite movimentar uma conta corrente ativa com crédito ou débito.")]
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

    /// <summary>
    /// Consulta o saldo atual de uma conta corrente.
    /// </summary>
    /// <param name="id">ID da conta corrente.</param>
    /// <returns>Dados do titular e valor do saldo.</returns>
    [HttpGet("saldo/{id}")]
    [ProducesResponseType(typeof(ConsultarSaldoResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
    [SwaggerOperation(Summary = "Consulta o saldo de uma conta corrente", Description = "Retorna o saldo atual calculado a partir de todos os movimentos.")]
    public async Task<ActionResult<ConsultarSaldoResult>> ConsultarSaldo([FromRoute] Guid id)
    {
        try
        {
            var query = new ConsultarSaldoQuery { IdContaCorrente = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { erro = ex.Message });
        }
    }
}
