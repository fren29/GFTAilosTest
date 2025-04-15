using MediatR;
using Questao5.Infrastructure.Sqlite;
using Dapper;
using System.Globalization;
using Questao5.Infrastructure.Database.CommandStore.Requests;
using Questao5.Infrastructure.Database.CommandStore.Responses;
using Microsoft.Data.Sqlite;
using Questao5.Domain.Exceptions;

namespace Questao5.Application.Handlers;

public class MovimentarContaHandler : IRequestHandler<MovimentarContaCommand, MovimentarContaResult>
{
    private readonly DatabaseConfig _config;

    public MovimentarContaHandler(DatabaseConfig config)
    {
        _config = config;
    }

    public async Task<MovimentarContaResult> Handle(MovimentarContaCommand request, CancellationToken cancellationToken)
    {
        using SqliteConnection connection = new(_config.Name);

        var idempotente = await connection.QueryFirstOrDefaultAsync<string>(
            "SELECT resultado FROM idempotencia WHERE chave_idempotencia = @id",
            new { id = request.IdRequisicao.ToString() });

        if (!string.IsNullOrEmpty(idempotente))
        {
            return new MovimentarContaResult { IdMovimento = Guid.Parse(idempotente) };
        }

        var conta = await connection.QueryFirstOrDefaultAsync<(string Id, bool Ativa)>(
            "SELECT idcontacorrente as Id, ativo as Ativa FROM contacorrente WHERE idcontacorrente = @id",
            new { id = request.IdContaCorrente.ToString() });

        if (conta == default)
            throw new BusinessException("INVALID_ACCOUNT", "Conta Corrente não encontrada.");

        if (!conta.Ativa)
            throw new BusinessException("INACTIVE_ACCOUNT", "Conta Corrente inativa.");

        if (request.Valor <= 0)
            throw new BusinessException("INVALID_VALUE", "Saldo insulficiente");

        if (request.TipoMovimento != "C" && request.TipoMovimento != "D")
            throw new BusinessException("INVALID_TYPE", "Sem suporte para este tipo de operação");

        var idMovimento = Guid.NewGuid();
        var data = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

        await connection.ExecuteAsync(
            "INSERT INTO movimento (idmovimento, idcontacorrente, datamovimento, tipomovimento, valor) VALUES (@id, @conta, @data, @tipo, @valor)",
            new { id = idMovimento, conta = request.IdContaCorrente, data, tipo = request.TipoMovimento, valor = request.Valor });

        await connection.ExecuteAsync(
            "INSERT INTO idempotencia (chave_idempotencia, requisicao, resultado) VALUES (@chave, @req, @res)",
            new { chave = request.IdRequisicao, req = "", res = idMovimento.ToString() });

        return new MovimentarContaResult { IdMovimento = idMovimento };
    }
}

