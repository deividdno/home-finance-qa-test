### Teste Técnico: Analista de Qualidade de Software

Nome: Deivid Nunes Oliveira

E-mail: deivid.dno18@gmail.com

### Resumo do Projeto

Este repositório contém a solução de testes automatizados para o sistema de controle de gastos residenciais. A estratégia de testes foi estruturada para validar as regras de negócio descritas no escopo, com foco em integridade de dados, fluxos de exceção e qualidade da interface.

### Pirâmide de Testes e Estratégia

A estrutura de testes foi dividida em três níveis para garantir a eficiência da validação:

1. Testes Unitários (xUnit): Implementados no back-end para validar as entidades e as regras de cálculo lógico de saldo.

2. Testes de Integração (xUnit/Vitest): Focados na persistência de dados no banco de dados e na integração de componentes React no front-end.

3. Testes End-to-End (Playwright): Cobertura das jornadas principais do usuário, incluindo o fluxo de cadastro de transações, gerenciamento de categorias e validação visual do dashboard.

Justificativa: A priorização do Playwright no nível E2E foi definida para garantir que as restrições de idade e tipos de transação sejam validadas da perspectiva do usuário final, onde as falhas de integração são mais críticas.

### Tecnologias Utilizadas

- Back-end: C# e .NET com framework xUnit.

- Front-end: React, TypeScript e Vitest.

- Automação E2E: Playwright.

### Procedimentos para Execução dos Testes

### Pré-requisitos

- Aplicação em execução no ambiente Docker (localhost:5173).

- Node.js e .NET SDK instalados no ambiente local.

### Execução de Testes E2E (Playwright)

# Instalação de dependências

npm install

# Execução em modo headless

npx playwright test

# Execução com interface gráfica para depuração

npx playwright test --ui

### Execução de Testes Unitários e Integração (.NET)

dotnet test

### Bugs Identificados e Documentados

As falhas encontradas durante a execução dos testes foram catalogadas na pasta /docs/bugs. Cada relatório detalha o impacto na regra de negócio.

1. ID = 001 | Título = Permissão de Receita para Menor de Idade | Regra Violada = Regra de Negócio: Idade vs Tipo de Transação | Severidade = Crítica

2. ID = 002 | Título = Seleção de Categoria inconsistente com a Finalidade | Regra Violada = Regra de Negócio: Vínculo Categoria/Tipo | Severidade = Alta

3. ID = 003 | Título = Falha na integridade referencial e exclusão em cascata | Regra Violada = Integridade de Dados (DB) | Severidade = Crítica

4. ID = 004 | Título = Falha na persistência de transação via Modal | Regra Violada = Funcionalidade Principal (CRUD) | Severidade = Crítica

5. ID = 005 | Título = Overflow e falta de responsividade no gráfico | Regra Violada = UI/UX / Dashboard | Severidade = Média

### Justificativa das Escolhas de Testes

- Foco em Regras de Negócio: Os scripts foram desenvolvidos para testar prioritariamente as restrições de idade e categorias, garantindo que o sistema impeça ações indevidas.

- Mapeamento de Falhas: O código de teste foi estruturado para capturar e evidenciar erros de sistema, como o travamento no modal de salvamento.

- Manutenibilidade: Utilização de seletores robustos para evitar a fragilidade dos testes diante de alterações menores no CSS ou estrutura HTML.
