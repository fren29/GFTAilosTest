# 🏦 API - Gestão de Conta Corrente (Questão 5)

Esta API simula operações bancárias para movimentações e consulta de saldo em contas correntes.

---

## 🚀 Como Executar

### Pré-requisitos
- [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- SQLite (instalado ou via dependência)

### Executando a API

```bash
cd Questao5
dotnet run
```

Acesse: `https://localhost:5001/swagger`

---

## 🧪 Rodando os Testes

```bash
dotnet test Exercicio.Tests
```

---

## 📚 Endpoints

### `POST /contacorrente/movimentacao`

Realiza movimentação (crédito ou débito).

#### Requisição
```json
{
  "idRequisicao": "string",
  "idContaCorrente": "guid",
  "valor": 100.00,
  "tipoMovimento": "C"
}
```

#### Resposta (200)
```json
{
  "idMovimento": "guid"
}
```

#### Resposta (400)
```json
{
  "tipo": "INVALID_ACCOUNT",
  "mensagem": "Conta corrente não encontrada."
}
```

---

### `GET /contacorrente/saldo/{id}`

Consulta o saldo atual da conta.

#### Resposta (200)
```json
{
  "numeroConta": 123,
  "nomeTitular": "Katherine Sanchez",
  "dataConsulta": "2024-04-13T12:00:00Z",
  "saldo": 150.00
}
```

---

## 🧱 Arquitetura e Tecnologias

- **.NET 6**
- **CQRS** (com `MediatR`)
- **Dapper** (acesso leve ao SQLite)
- **Swagger** para documentação
- **xUnit** + **NSubstitute** + **FluentAssertions** para testes
- **Banco em memória nos testes** com `Sqlite` + schema bootstrap

---

## 📓 Histórico de Mudanças

Acompanhe todas as versões no [CHANGELOG.md](./CHANGELOG.md)

---
