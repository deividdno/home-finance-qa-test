## Bug 003 - Falha na integridade referencial e exclusão em cascata

### Resumo

Inconsistência no mapeamento de chaves estrangeiras (Shadow State) impede o funcionamento correto da exclusão em cascata entre Pessoa e Transações.

### Severidade

Crítica

### Prioridade

Urgente

### Ambiente

API MinhasFinancas (Infraestrutura)

### Status

Aberto

### Pré-condição

Existência de uma Pessoa com transações vinculadas.

### Passos para reproduzir

Criar uma Pessoa.

Criar uma Transação vinculada a essa Pessoa.

Excluir a Pessoa via endpoint DELETE /api/Pessoas/{id}.

### Resultado Atual

A operação falha ou não remove as transações dependentes devido a erro de mapeamento no Entity Framework (PessoaId1).

### Resultado Esperado

A exclusão da Pessoa deve remover automaticamente todas as transações vinculadas no banco de dados.

### Regra de Negócio Violada

Integridade referencial e persistência correta de dados.

### Evidência

Teste automatizado e logs de sistema: Deve_Excluir_Transacoes_Quando_Pessoa_For_Excluida
