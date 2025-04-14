# Teste Técnico - GFT / Ailos

Este repositório contém a resolução técnica de 5 questões, organizadas em projetos separados dentro de uma solution C#.  

## 💡 Decisões Iniciais

- O projeto será construído de forma incremental e orientado a entregas atômicas via commits.
- Todo commit importante será documentado no [CHANGELOG.md](./CHANGELOG.md) com o método STAR (Situação, Tarefa, Ação, Resultado).
- A estrutura adotada favorece organização, legibilidade e testabilidade, refletindo boas práticas de arquitetura.
- Para a Questão 5, será aplicada uma arquitetura baseada em **CQRS (Command Query Responsibility Segregation)**, considerando os padrões adotados na empresa cliente.

## 🧱 Estrutura do Projeto

```
/
├── Questao1/
├── Questao2/
├── Questao3/
├── Questao4/
├── Questao5/ (API + Banco de Dados)
├── README.md
├── CHANGELOG.md
└── Exercicio.sln
```

Cada questão está isolada para facilitar testes e foco individual.

## 📦 Tecnologias Utilizadas

- C# / .NET
- xUnit (testes)
- FluentAssertions
- SQLite (Questão 5)
- Minimal API
- CQRS

## 🚀 Como Executar

As questões estão organizadas como projetos separados. Algumas possuem execução independente, outras são focadas apenas na lógica de domínio:

- **Executáveis via `dotnet run`**:
  - Questao1
  - Questao2
  - Questao5 (API)

```bash
cd QuestaoX
dotnet run
```

- **Testes (quando disponíveis)**:

```bash
dotnet test
```

> Para as demais questões (3 e 4), a execução será baseada em testes unitários ou execução via projeto principal.

## 📋 Histórico de Commits

Veja o histórico completo no [CHANGELOG.md](./CHANGELOG.md)
