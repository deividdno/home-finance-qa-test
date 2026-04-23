using Xunit;
using MinhasFinancas.Domain.Entities;

namespace MinhasFinancas.Tests;

public class RegrasNegocioTests
{
    [Fact]
    public void Nao_Deve_Permitir_Receita_Para_Menor_De_Idade()
    {
        var pessoaMenor = new Pessoa
        {
            Nome = "Criança Teste",
            DataNascimento = DateTime.Now.AddYears(-10)
        };

        var idade = DateTime.Now.Year - pessoaMenor.DataNascimento.Year;

        if (pessoaMenor.DataNascimento.Date > DateTime.Now.AddYears(-idade))
            idade--;

        bool regraViolada = idade < 18;

        Assert.False(
            regraViolada,
            $"BUG: O sistema permitiu receita para {pessoaMenor.Nome} que tem apenas {idade} anos."
        );
    }

    [Fact]
    public void Categoria_Deve_Ser_Compativel_Com_Tipo_Da_Transacao()
    {
        var categoriaSomenteDespesa = new Categoria
        {
            Descricao = "Aluguel",
            Finalidade = Categoria.EFinalidade.Despesa
        };

        bool eCompativel =
            categoriaSomenteDespesa.Finalidade == Categoria.EFinalidade.Ambas ||
            categoriaSomenteDespesa.Finalidade == Categoria.EFinalidade.Receita;

        Assert.True(
            eCompativel,
            $"BUG: Categoria '{categoriaSomenteDespesa.Descricao}' (Despesa) foi usada em uma Receita."
        );
    }
}
