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