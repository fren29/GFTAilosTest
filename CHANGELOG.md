# 📘 CHANGELOG

Este changelog segue o formato [STAR](https://en.wikipedia.org/wiki/Situation,_Task,_Action,_Result), para documentar de forma clara o progresso e as decisões técnicas do projeto.  
Utiliza versionamento semântico com incremento de **minor version** para cada commit relevante.

---

## [1.0.0]

### chore: add .gitignore for C# and Visual Studio environment

- **Situation**: O repositório original contém arquivos temporários e dependentes da IDE, o que pode poluir o controle de versão.
- **Task**: Criar um `.gitignore` alinhado com boas práticas para projetos C# com Visual Studio.
- **Action**: Adicionado `.gitignore` cobrindo pastas de build (`bin`, `obj`, etc.), configurações de IDE (`.vscode`, `.idea`), e arquivos de cache.
- **Result**: Ambiente de versionamento limpo desde o início do projeto, prevenindo poluição e conflitos.

---

## [1.1.0]

### docs: add initial README with project structure and architectural goals

- **Situation**: Após definir o `.gitignore`, era necessário fornecer uma visão clara do propósito, estrutura e diretrizes do projeto.
- **Task**: Criar um `README.md` com a visão geral do teste técnico, decisões arquiteturais e instruções básicas de execução.
- **Action**: Adicionado `README.md` contendo:
  - Descrição do propósito do projeto.
  - Explicações iniciais sobre organização e arquitetura.
  - Tecnologias utilizadas.
  - Instruções de uso e testes.
  - Link para o `CHANGELOG.md`.
- **Result**: Qualquer pessoa pode compreender rapidamente o objetivo, estrutura e decisões técnicas do projeto, promovendo clareza e rastreabilidade desde o início.

---

## [1.2.0]

### docs: create CHANGELOG with initial entry for setup phase

- **Situation**: Com o projeto iniciando e o README já documentando a estrutura, era necessário criar um mecanismo formal para registrar as mudanças.
- **Task**: Criar o arquivo `CHANGELOG.md` com suporte a versionamento semântico e anotações detalhadas por commit.
- **Action**: Criado `CHANGELOG.md` com estrutura baseada no método STAR (Situation, Task, Action, Result) e primeira versão documentada (`1.0.0`, `1.1.0`).
- **Result**: Base sólida para rastreamento transparente das decisões técnicas e das etapas do desenvolvimento.

---

## [1.3.0]

### meta: acknowledge pre-existing solution structure

- **Situation**: A estrutura da solução (`.sln`) e os projetos das questões já estavam presentes na entrega original.
- **Task**: Verificar e validar que todos os projetos estavam corretamente adicionados e prontos para compilação.
- **Action**: Confirmada presença dos projetos Questao1, Questao2, Questao5; Questao3 e Questao4 possuem apenas enunciados por enquanto.
- **Result**: Solução reconhecida como funcional e pronta para evolução incremental por questão. Nenhuma ação necessária neste commit.

---

## [1.4.0]

### test: add shared test infrastructure with xUnit and FluentAssertions

- **Situation**: Os projetos das questões ainda não tinham testes automatizados, o que comprometeria a validabilidade incremental das soluções.
- **Task**: Criar uma infraestrutura de testes reutilizável, simples e eficaz para as questões que envolvem lógica.
- **Action**: Criado projeto `Tests`, com pacotes `xUnit` e `FluentAssertions`. Incluído teste de exemplo e referência a projetos `Questao1` e `Questao2`.
- **Result**: Ambiente de testes estabelecido, permitindo TDD e verificação contínua das entregas sem esforço adicional.

---

## [1.5.0]

### feat: implement Questão 1 - regras de conta bancária com testes

- **Situation**: A primeira questão do teste técnico solicita a implementação de uma classe `ContaBancaria` com regras básicas de depósito e saque.
- **Task**: Implementar a lógica solicitada e garantir cobertura por testes unitários, respeitando encapsulamento e boas práticas.
- **Action**: Criada a classe `ContaBancaria` com métodos `Depositar`, `Sacar` e propriedade `Saldo`. Implementados testes em `Tests/ContaBancariaTests.cs` cobrindo os principais fluxos.
- **Result**: Questão 1 implementada com sucesso e cobertura de testes garantindo confiabilidade e validabilidade da lógica.

---

## [1.5.1]

### refactor: remove testing dependencies from Questao5 and centralize tests

- **Situation**: O projeto `Questao5` havia sido entregue com dependências de teste (xUnit, Moq, coverlet, etc.) e implementações internas de testes.
- **Task**: Eliminar possíveis conflitos e centralizar todos os testes no projeto `Exercicio.Tests`, seguindo boas práticas e simplificando o ambiente de build e execução.
- **Action**: Removidas do `Questao5.csproj` todas as dependências de teste. Projeto passou a conter apenas código de produção, com testes realizados exclusivamente via `Exercicio.Tests`.
- **Result**: Ambiente mais estável, limpo e compatível com a abordagem centralizada adotada para os testes das demais questões.

---

## [1.5.2]

### chore: organiza estrutura inicial de testes para a Questão 2

- **Situation**: Era necessário iniciar os testes da Questão 2 com uma estrutura de mocks reutilizável e separada.
- **Task**: Criar a base de testes com isolamento e simulação de chamadas HTTP.
- **Action**: Criado o projeto `Exercicio.Tests`, o helper `HttpClientMockFootballHelper`, e testes básicos com dados mockados.
- **Result**: Estrutura de testes pronta para evoluir com mocks reutilizáveis, permitindo foco em lógica de negócios.

---

## [1.6.0]

### feat: implementa o serviço `GolsPorTimeService` e testes principais da Questão 2

- **Situation**: A Questão 2 exige chamadas HTTP para uma API paginada, com o cálculo total de gols por time e ano.
- **Task**: Implementar o serviço responsável por consumir a API e somar corretamente os gols.
- **Action**: Criado o `GolsPorTimeService` com controle de paginação, DTOs (`MatchApiResponse`, `MatchDatum`) e testes com dados mockados.
- **Result**: Serviço funcional com cobertura de testes representando partidas simples e paginadas.

---

## [1.6.1]

### refactor: reorganiza mocks em arquivos parciais para facilitar manutenção

- **Situation**: O arquivo de mocks `GolsPorTimeServiceData` estava crescendo e se tornando difícil de manter.
- **Task**: Dividir a lógica de mocks em arquivos parciais sem perder a centralização.
- **Action**: Separado em `Pagination`, `Sides`, `Errors` e `Main`, com o método `Json(...)` centralizado no arquivo base.
- **Result**: Código de mocks mais modular, limpo e com responsabilidades separadas.

---

## [1.6.2]

### chore: adiciona fallback genérico no mock de HttpClient

- **Situation**: Algumas URLs requisitadas durante os testes não estavam sendo interceptadas corretamente pelos mocks, causando falhas silenciosas.
- **Task**: Garantir que qualquer requisição inesperada seja tratada com uma resposta segura.
- **Action**: Adicionado fallback com `ItExpr.IsAny<HttpRequestMessage>()` no `HttpClientMockHelper.Create(...)`, retornando resposta vazia controlada.
- **Result**: Testes mais estáveis, com comportamento previsível mesmo para cenários não explicitamente mapeados.

---

## [1.6.3]

### refactor: reestrutura testes da Questão 2 para refletir o comportamento real do serviço

- **Situation**: Os testes antigos consideravam apenas um lado das partidas (`team1` ou `team2`), o que não refletia o comportamento completo do `GolsPorTimeService`.
- **Task**: Refatorar os testes para considerar corretamente ambas as chamadas da API (`team1` e `team2`) e o sistema de paginação.
- **Action**: Atualizados todos os testes para usar mocks de ambos os lados, reorganizados para utilizar exclusivamente os métodos de `GolsPorTimeServiceData`.
- **Result**: Cobertura de testes realista, alinhada com a lógica de produção e mais robusta para simular os diferentes cenários da API.

---

## [1.6.4]

### test: corrige matching de URLs nos mocks e estabiliza execução de testes

- **Situation**: Mesmo com a estrutura de testes ajustada, todas as chamadas HTTP estavam caindo no fallback genérico, retornando dados vazios e falhando nos testes.
- **Task**: Investigar e ajustar os critérios de `match` no `HttpClientMockHelper`, garantindo que cada URL requisitada pelo serviço tenha um mock correspondente.
- **Action**: Corrigidos os valores de `match` em `GolsPorTimeServiceData` para incluir múltiplos parâmetros como `team1=...&page=1`. Adicionado log no fallback para facilitar o diagnóstico. Confirmado que todos os testes invocam URLs que agora são corretamente interceptadas.
- **Result**: Todos os testes passaram com sucesso. O ambiente de testes agora reflete com precisão os comportamentos esperados da API, incluindo paginação e múltiplas entradas por lado da partida.

---

## [1.7.0]

### feat: resolve Questão 3 simulando estado final de arquivos após comandos Git

- **Situation**: A Questão 3 propunha uma sequência de comandos Git, incluindo criação e exclusão de arquivos, commits em diferentes branches e alternância entre elas.
- **Task**: Identificar corretamente quais arquivos permanecem no diretório de trabalho da branch `master` ao final da sequência, além do `README.md`.
- **Action**: Analisada a sequência de comandos passo a passo, removendo o `default.html` no commit 2 e mantendo `style.css` em `master`. O arquivo `script.js`, criado na branch `testing`, não aparece ao voltar para `master`. A análise foi testada usando comandos `echo` no terminal para simular os efeitos.
- **Result**: Determinada com precisão que o único arquivo restante (além do `README.md`) é `style.css`. Questão 3 finalizada com confiança e validada via terminal.

---

## [1.8.0]

### feat: implementa consulta SQL da Questão 4 para agrupar e filtrar atendimentos

- **Situation**: A Questão 4 exige uma consulta SQL que agrupe os atendimentos por assunto e ano, contabilize as ocorrências e filtre somente os que têm mais de 3 registros por ano.
- **Task**: Construir um `SELECT` com `GROUP BY`, `HAVING` e `ORDER BY` para trazer apenas as combinações válidas ordenadas por ano e quantidade de forma decrescente.
- **Action**: Criada a query com `COUNT(*)`, agrupamento por `ASSUNTO` e `ANO`, cláusula `HAVING COUNT(*) > 3` e ordenação por `ANO DESC, QUANTIDADE DESC`. A consulta foi validada com os dados fornecidos e retorna exatamente os registros esperados.
- **Result**: Consulta implementada com sucesso, entregando o resultado esperado com performance e clareza sintática.

---

## [1.9.0]

### feat: implementa movimentação de conta com validações e idempotência

- **Situation**: A empresa solicitou a criação de um serviço REST para registrar movimentações (crédito e débito) em contas correntes já existentes, com suporte à idempotência e validações de negócio.
- **Task**: Implementar um endpoint POST capaz de receber um comando de movimentação, validar os dados conforme as regras fornecidas e persistir o movimento no banco SQLite.
- **Action**: Criado `MovimentarContaCommand` e `MovimentarContaHandler` seguindo o padrão CQRS. Foram implementadas as validações: conta existente, ativa, valor positivo e tipo válido. Adicionado controle de idempotência com registro de requisições únicas. Endpoint implementado em `ContaCorrenteController` via Minimal API convertida para `Controller`.
- **Result**: Serviço de movimentação funcional com controle de duplicidade, pronto para integração com o app da empresa. Arquitetura segue o padrão utilizado pela organização (CQRS + Dapper + Controller).

---

## [1.10.0]

### feat: implementa consulta de saldo com validações e agregação por movimentos

- **Situation**: A empresa solicitou a criação de um endpoint para consulta de saldo da conta corrente, baseado nas movimentações de crédito e débito previamente registradas.
- **Task**: Implementar um endpoint GET que recebe a identificação da conta corrente, valida as regras de negócio, calcula o saldo e retorna os dados do titular e o valor atual.
- **Action**: Criados `ConsultarSaldoQuery` e `ConsultarSaldoHandler` seguindo o padrão CQRS. O handler valida se a conta existe e está ativa, busca as somas de créditos e débitos via Dapper e retorna o saldo. Foi adicionado o endpoint `GET /contacorrente/saldo/{id}` no `ContaCorrenteController`.
- **Result**: Serviço funcional que retorna saldo atualizado com base nas movimentações, incluindo nome do titular e data/hora da consulta. Endpoint devidamente validado com mensagens de erro específicas.

---