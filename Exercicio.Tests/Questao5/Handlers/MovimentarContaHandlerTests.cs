using FluentAssertions;
using Questao5.Application.Handlers;
using Questao5.Infrastructure.Sqlite;
using Microsoft.Data.Sqlite;
using Exercicio.Tests.Questao5.Data;
using Questao5.Infrastructure.Database.CommandStore.Requests;

namespace Exercicio.Tests.Questao5.Handlers;
public class MovimentarContaHandlerTests
{
    private readonly DatabaseConfig _config;
    private readonly SqliteConnection _connection;

    public MovimentarContaHandlerTests()
    {
        (_config, _connection) = TestDatabaseHelper.InitializeDatabaseWithSchemaAndKeepOpen();
    }

    [Fact(DisplayName = "Should throw INVALID_ACCOUNT when account does not exist")]
    public async Task Should_Throw_When_Account_Does_Not_Exist()
    {
        var handler = new MovimentarContaHandler(_config);
        var command = new MovimentarContaCommand
        {
            IdRequisicao = "x-req",
            IdContaCorrente = Guid.NewGuid(),
            TipoMovimento = "C",
            Valor = 100
        };

        Func<Task> act = async () => await handler.Handle(command, CancellationToken.None);
        await act.Should().ThrowAsync<Exception>().WithMessage("INVALID_ACCOUNT");
    }

    [Fact(DisplayName = "Should throw INVALID_TYPE when type is not C or D")]
    public async Task Should_Throw_When_Invalid_Type()
    {
        var accountId = Guid.NewGuid().ToString();
        TestDatabaseHelper.InsertConta(_connection, accountId, 123, "Test", true);

        var handler = new MovimentarContaHandler(_config);
        var command = new MovimentarContaCommand
        {
            IdRequisicao = "x-req-2",
            IdContaCorrente = Guid.Parse(accountId),
            TipoMovimento = "X",
            Valor = 100
        };

        Func<Task> act = async () => await handler.Handle(command, CancellationToken.None);
        await act.Should().ThrowAsync<Exception>().WithMessage("INVALID_TYPE");
    }
}
