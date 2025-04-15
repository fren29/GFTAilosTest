using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Infrastructure.Sqlite;

namespace Exercicio.Tests.Questao5.Data;

public static class TestDatabaseHelper
{
    public static SqliteConnection CreateInMemoryDatabase()
    {
        var connection = new SqliteConnection("Data Source=:memory:");
        connection.Open();
        CreateSchema(connection);
        return connection;
    }
    public static void CreateSchema(SqliteConnection connection)
    {
        var checkContaCorrenteTable = @"
        SELECT name 
        FROM sqlite_master 
        WHERE type='table' AND name='contacorrente';
    ";

        var checkMovimentoTable = @"
        SELECT name 
        FROM sqlite_master 
        WHERE type='table' AND name='movimento';
    ";

        var checkIdempotenciaTable = @"
        SELECT name 
        FROM sqlite_master 
        WHERE type='table' AND name='idempotencia';
    ";

        using (var cmd = new SqliteCommand(checkContaCorrenteTable, connection))
        {
            var result = cmd.ExecuteScalar();
            if (result == null)
            {
                var createContaCorrenteTable = @"
                CREATE TABLE contacorrente (
                    idcontacorrente TEXT PRIMARY KEY,
                    numero INTEGER,
                    nome TEXT,
                    ativo INTEGER
                );
            ";
                new SqliteCommand(createContaCorrenteTable, connection).ExecuteNonQuery();
            }
        }

        using (var cmd = new SqliteCommand(checkMovimentoTable, connection))
        {
            var result = cmd.ExecuteScalar();
            if (result == null)
            {
                var createMovimentoTable = @"
                CREATE TABLE movimento (
                    idmovimento TEXT PRIMARY KEY,
                    idcontacorrente TEXT,
                    datamovimento TEXT,
                    tipomovimento TEXT,
                    valor REAL
                );
            ";
                new SqliteCommand(createMovimentoTable, connection).ExecuteNonQuery();
            }
        }

        using (var cmd = new SqliteCommand(checkIdempotenciaTable, connection))
        {
            var result = cmd.ExecuteScalar();
            if (result == null)
            {
                var createIdempotenciaTable = @"
                CREATE TABLE idempotencia (
                    chave_idempotencia TEXT PRIMARY KEY,
                    requisicao TEXT,
                    resultado TEXT
                );
            ";
                new SqliteCommand(createIdempotenciaTable, connection).ExecuteNonQuery();
            }
        }
    }



    public static (DatabaseConfig config, SqliteConnection connection) InitializeDatabaseWithSchemaAndKeepOpen()
    {
        var config = new DatabaseConfig { Name = "Data Source=memdb1;Mode=Memory;Cache=Shared" };
        var connection = new SqliteConnection(config.Name);
        connection.Open();
        CreateSchema(connection);
        return (config, connection);
    }

    public static void InsertConta(SqliteConnection connection, string id, int numero, string nome, bool ativa)
    {
        var sql = "INSERT INTO contacorrente (idcontacorrente, numero, nome, ativo) VALUES (@id, @numero, @nome, @ativo);";
        var cmd = connection.CreateCommand();
        cmd.CommandText = sql;
        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@numero", numero);
        cmd.Parameters.AddWithValue("@nome", nome);
        cmd.Parameters.AddWithValue("@ativo", ativa ? 1 : 0);
        cmd.ExecuteNonQuery();
    }

    public static void InsertMovimento(SqliteConnection connection, string movementId, string accountId, string tipo, decimal valor)
    {
        var sql = "INSERT INTO movimento (idmovimento, idcontacorrente, datamovimento, tipomovimento, valor) VALUES (@idm, @idc, @data, @tipo, @valor);";
        var cmd = connection.CreateCommand();
        cmd.CommandText = sql;
        cmd.Parameters.AddWithValue("@idm", movementId);
        cmd.Parameters.AddWithValue("@idc", accountId);
        cmd.Parameters.AddWithValue("@data", DateTime.Now.ToString("dd/MM/yyyy"));
        cmd.Parameters.AddWithValue("@tipo", tipo);
        cmd.Parameters.AddWithValue("@valor", valor);
        cmd.ExecuteNonQuery();
    }

    public static bool AccountExists(SqliteConnection connection, string accountId)
    {
        var query = "SELECT COUNT(1) FROM contacorrente WHERE idcontacorrente = @id";
        var count = connection.ExecuteScalar<int>(query, new { id = accountId });
        return count > 0;
    }
}
