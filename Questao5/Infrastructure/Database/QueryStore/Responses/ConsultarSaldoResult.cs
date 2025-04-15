using Swashbuckle.AspNetCore.Annotations;

namespace Questao5.Infrastructure.Database.QueryStore.Responses;

public class ConsultarSaldoResult
{
    [SwaggerSchema("Número da conta corrente.")]
    public int NumeroConta { get; set; }

    [SwaggerSchema("Nome completo do titular da conta.")]
    public string NomeTitular { get; set; } = string.Empty;

    [SwaggerSchema("Data e hora da consulta do saldo.")]
    public DateTime DataConsulta { get; set; }

    [SwaggerSchema("Valor atual do saldo.")]
    public decimal Saldo { get; set; }
}
