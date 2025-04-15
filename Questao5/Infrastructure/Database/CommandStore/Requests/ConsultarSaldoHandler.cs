using Dapper;
using MediatR;
using Questao5.Application.Queries.Requests;
using Questao5.Application.Queries.Responses;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Application.Handlers;

public class ConsultarSaldoHandler : IRequestHandler<ConsultarSaldoQuery, ConsultarSaldoResult>
{
    private readonly DatabaseConfig _config;

    public ConsultarSaldoHandler(DatabaseConfig config)
    {
        _config = config;
    }

    public async Task<ConsultarSaldoResult> Handle(ConsultarSaldoQuery request, CancellationToken cancellationToken)
    {
        using var connection = new Microsoft.Data.Sqlite.SqliteConnection(_config.Name);

        var conta = await connection.QueryFirstOrDefaultAsync<(int Numero, string Nome, bool Ativa)>(
            "SELECT numero, nome, ativo FROM contacorrente WHERE idcontacorrente = @id",
            new { id = request.IdContaCorrente });

        if (conta.Numero == 0)
            throw new Exception("INVALID_ACCOUNT");

        if (!conta.Ativa)
            throw new Exception("INACTIVE_ACCOUNT");

        var creditos = await connection.ExecuteScalarAsync<decimal?>(
            "SELECT COALESCE(SUM(valor), 0) FROM movimento WHERE idcontacorrente = @id AND tipomovimento = 'C'",
            new { id = request.IdContaCorrente });

        var debitos = await connection.ExecuteScalarAsync<decimal?>(
            "SELECT COALESCE(SUM(valor), 0) FROM movimento WHERE idcontacorrente = @id AND tipomovimento = 'D'",
            new { id = request.IdContaCorrente });

        return new ConsultarSaldoResult
        {
            NumeroConta = conta.Numero,
            NomeTitular = conta.Nome,
            DataConsulta = DateTime.Now,
            Saldo = (creditos ?? 0) - (debitos ?? 0)
        };
    }
}