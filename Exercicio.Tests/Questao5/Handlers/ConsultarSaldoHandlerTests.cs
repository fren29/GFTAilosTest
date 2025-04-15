using FluentAssertions;
using Questao5.Application.Handlers;
using Questao5.Infrastructure.Sqlite;
using Microsoft.Data.Sqlite;
using Exercicio.Tests.Questao5.Data;
using Questao5.Infrastructure.Database.QueryStore.Requests;

namespace Exercicio.Tests.Questao5.Handlers;
public class ConsultarSaldoHandlerTests
{
    private readonly DatabaseConfig _config;
    private readonly SqliteConnection _connection;

    public ConsultarSaldoHandlerTests()
    {
        (_config, _connection) = TestDatabaseHelper.InitializeDatabaseWithSchemaAndKeepOpen();
    }

    [Fact(DisplayName = "Should throw INVALID_ACCOUNT when account not found")]
    public async Task Should_Throw_When_Account_Not_Found()
    {
        var handler = new ConsultarSaldoHandler(_config);
        var query = new ConsultarSaldoQuery { IdContaCorrente = Guid.NewGuid() };

        Func<Task> act = async () => await handler.Handle(query, CancellationToken.None);
        await act.Should().ThrowAsync<Exception>().WithMessage("INVALID_ACCOUNT");
    }

    [Fact(DisplayName = "Should return 0 when account has no movements")]
    public async Task Should_Return_Zero_When_No_Movements()
    {
        var accountId = Guid.NewGuid().ToString();

        // Ensure the account is inserted into the database
        TestDatabaseHelper.InsertConta(_connection, accountId, 100, "Titular", true);

        // Verify the account exists in the database
        var accountExists = TestDatabaseHelper.AccountExists(_connection, accountId);
        accountExists.Should().BeTrue("The account should exist in the database before testing the handler.");

        var handler = new ConsultarSaldoHandler(_config);
        var query = new ConsultarSaldoQuery { IdContaCorrente = Guid.Parse(accountId) };

        var result = await handler.Handle(query, CancellationToken.None);

        result.Saldo.Should().Be(0);
        result.NumeroConta.Should().Be(100);
        result.NomeTitular.Should().Be("Titular");
    }
}
