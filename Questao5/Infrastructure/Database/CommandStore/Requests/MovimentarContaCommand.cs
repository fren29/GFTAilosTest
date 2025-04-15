using MediatR;
using Questao5.Infrastructure.Database.CommandStore.Responses;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace Questao5.Infrastructure.Database.CommandStore.Requests;

public class MovimentarContaCommand : IRequest<MovimentarContaResult>
{
    [Required]
    [SwaggerSchema("Chave única da requisição (para idempotência).", Nullable = false)]
    public string IdRequisicao { get; set; } = default!;

    [Required]
    [SwaggerSchema("Identificador da conta corrente.", Nullable = false)]
    public Guid IdContaCorrente { get; set; }

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero.")]
    [SwaggerSchema("Valor da movimentação (positivo).", Format = "decimal", Nullable = false)]
    public decimal Valor { get; set; }

    [Required]
    [SwaggerSchema("Tipo do movimento: 'C' para crédito ou 'D' para débito.", Nullable = false)]
    [RegularExpression("C|D", ErrorMessage = "TipoMovimento deve ser 'C' ou 'D'.")]
    public string TipoMovimento { get; set; } = default!;
}
