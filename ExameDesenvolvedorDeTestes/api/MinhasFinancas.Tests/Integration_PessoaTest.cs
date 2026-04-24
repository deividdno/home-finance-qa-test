using Xunit;
using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;

namespace MinhasFinancas.Tests;

public class IntegrationPessoaTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public IntegrationPessoaTest(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Deve_Excluir_Transacoes_Quando_Pessoa_For_Excluida()
    {
        var pessoaId = await CriarPessoaExemplo("Joao Cascata", "1990-01-01");

        var novaTransacao = new {
            descricao = "Gasto Teste", valor = 50.00m, tipo = 0,
            pessoaId = pessoaId, categoriaId = 1
        };
        var respT = await _client.PostAsJsonAsync("/api/Transacoes", novaTransacao);
        var transacaoCriada = await respT.Content.ReadFromJsonAsync<GenericResponse>();

        var respDelete = await _client.DeleteAsync($"/api/Pessoas/{pessoaId}");

        Assert.Equal(HttpStatusCode.NoContent, respDelete.StatusCode);

        var respTotais = await _client.GetAsync($"/api/Pessoas/{pessoaId}/totais");
        Assert.Equal(HttpStatusCode.NotFound, respTotais.StatusCode);

        var respTransacaoOrfa = await _client.GetAsync($"/api/Transacoes/{transacaoCriada!.Id}");
        Assert.Equal(HttpStatusCode.NotFound, respTransacaoOrfa.StatusCode);
    }

    [Fact]
    public async Task Deve_Calcular_Totais_Corretamente_Para_Pessoa()
    {
        var pessoaId = await CriarPessoaExemplo("Calculo Teste", "1995-05-05");

        await _client.PostAsJsonAsync("/api/Transacoes", new {
            descricao = "Salário", valor = 100.00m, tipo = 1,
            pessoaId = pessoaId, categoriaId = 2
        });

        await _client.PostAsJsonAsync("/api/Transacoes", new {
            descricao = "Lanche", valor = 40.00m, tipo = 0,
            pessoaId = pessoaId, categoriaId = 1
        });

        var response = await _client.GetAsync($"/api/Pessoas/{pessoaId}/totais");
        var totais = await response.Content.ReadFromJsonAsync<TotaisResponse>();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(60.00m, totais!.Total);
    }

    [Fact]
    public async Task Nao_Deve_Permitir_Categoria_Incompativel_Com_Tipo_Transacao()
    {
        var pessoaId = await CriarPessoaExemplo("Validacao Categoria", "1990-01-01");

        var transacaoInvalida = new {
            descricao = "Tentativa Errada",
            valor = 10.00m,
            tipo = 1,
            pessoaId = pessoaId,
            categoriaId = 1
        };

        var response = await _client.PostAsJsonAsync("/api/Transacoes", transacaoInvalida);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    private async Task<int> CriarPessoaExemplo(string nome, string data)
    {
        var resp = await _client.PostAsJsonAsync("/api/Pessoas", new { nome, dataNascimento = data });
        var dados = await resp.Content.ReadFromJsonAsync<GenericResponse>();
        return dados!.Id;
    }

    private class GenericResponse { public int Id { get; set; } }
    private class TotaisResponse { public decimal Total { get; set; } }
}
