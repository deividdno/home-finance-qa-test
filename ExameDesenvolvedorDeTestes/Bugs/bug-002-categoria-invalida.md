# Bug 002 - Categoria incompatível aceita tipo de transação inválido

### Resumo

O sistema permite utilizar uma categoria com finalidade Despesa em uma transação do tipo Receita.

### Severidade

Alta

### Prioridade

Alta

### Ambiente

API MinhasFinancas

### Status

Aberto

### Pré-condição

Categoria cadastrada como Despesa.

### Passos para reproduzir

Criar categoria:

Nome: Aluguel

Finalidade: Despesa

Criar transação:

Tipo: Receita

Categoria: Aluguel

### Resultado Atual

Transação criada normalmente.

### Resultado Esperado

Sistema deve impedir associação incompatível entre tipo e categoria.

### Regra de Negócio Violada

Categorias devem respeitar a finalidade cadastrada.

### Evidência

Teste automatizado: Categoria_Deve_Ser_Compativel_Com_Tipo_Da_Transacao
