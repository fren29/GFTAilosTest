using MediatR;
using Questao5.Infrastructure.Database.QueryStore.Responses;

namespace Questao5.Infrastructure.Database.QueryStore.Requests;

public class ConsultarSaldoQuery : IRequest<ConsultarSaldoResult>
{
    public Guid IdContaCorrente { get; set; }
}
