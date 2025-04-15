namespace Questao5.Application.Queries.Responses;

public class ConsultarSaldoResult
{
    public int NumeroConta { get; set; }
    public string NomeTitular { get; set; } = string.Empty;
    public DateTime DataConsulta { get; set; }
    public decimal Saldo { get; set; }
}