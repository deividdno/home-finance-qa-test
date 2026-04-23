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
        var novaPessoa = new
        {
            nome = "Joao Pessoa",
            dataNascimento = "1986-01-19"
        };

        var respPessoa = await _client.PostAsJsonAsync("/api/Pessoas", novaPessoa);

        Assert.True(respPessoa.IsSuccessStatusCode);

        var pessoaCriada =
            await respPessoa.Content.ReadFromJsonAsync<PessoaResponse>();

        Assert.NotNull(pessoaCriada);

        var pessoaId = pessoaCriada!.Id;

        var novaTransacao = new
        {
            descricao = "Gasto Mercado",
            valor = 100.50m,
            tipo = 0,
            pessoaId = pessoaId,
            categoriaId = 1
        };

        var respTransacao =
            await _client.PostAsJsonAsync("/api/Transacoes", novaTransacao);

        Assert.True(respTransacao.IsSuccessStatusCode);

        var respDelete =
            await _client.DeleteAsync($"/api/Pessoas/{pessoaId}");

        Assert.Equal(HttpStatusCode.NoContent, respDelete.StatusCode);

        var respTotais =
            await _client.GetAsync($"/api/Pessoas/{pessoaId}/totais");

        Assert.Equal(HttpStatusCode.NotFound, respTotais.StatusCode);
    }

    private class PessoaResponse
    {
        public int Id { get; set; }
    }
}
