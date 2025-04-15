using MediatR;
using Questao5.Infrastructure.Database.CommandStore.Responses;

namespace Questao5.Infrastructure.Database.CommandStore.Requests;

public class MovimentarContaCommand : IRequest<MovimentarContaResult>
{
    public string IdRequisicao { get; set; } = default!;
    public Guid IdContaCorrente { get; set; }
    public decimal Valor { get; set; }
    public string TipoMovimento { get; set; } = default!; // "C" ou "D"
}
