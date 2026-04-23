## Bug 001 - Cadastro de receita permitido para menor de idade

### Resumo

O sistema permite registrar transações do tipo Receita para pessoas com idade inferior a 18 anos.

### Severidade

Média

### Prioridade

Alta

### Ambiente

API MinhasFinancas (Domínio)

### Status

Aberto

### Pré-condição

Pessoa cadastrada com data de nascimento que resulte em menoridade (ex: 10 anos).

### Passos para reproduzir

Selecionar uma pessoa menor de idade.

Criar transação:

Tipo: Receita

Valor: 100.00

### Resultado Atual

Transação é registrada com sucesso, sem validação de idade.

### Resultado Esperado

O sistema deve impedir o registro de receitas para menores de idade, conforme regra de domínio.

### Regra de Negócio Violada

Menores de idade não podem possuir receitas.

### Evidência

Teste automatizado: Nao_Deve_Permitir_Receita_Para_Menor_De_Idade
