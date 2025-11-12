using Fiap.BlazorCleanArch.Dominio.Entidades.Base;
using Fiap.BlazorCleanArch.Dominio.Excecoes;

namespace Fiap.BlazorCleanArch.Dominio.Entidades;

public class Album : Entity
{
    public string Nome { get; set; } = string.Empty;
    public string CapaUrl { get; set; } = string.Empty;
    public DateTime DataLancamento { get; set; }
    public Artista Artista { get; set; } = default!;

    public Album(){}

    public Album(string nome, string capaUrl, DateTime dataLancamento, Artista artista)
    {
        SetNome(nome);
        SetCapaUrl(capaUrl);
        SetDataLancamento(dataLancamento);
        SetArtista(artista);
    }

    public void SetNome(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new AtributoObrigatorioExcecao(nameof(Nome));

        if (nome.Length > 50)
            throw new TamanhoDeAtributoInvalidoExcecao(nameof(Nome), 0, 50);

        Nome = nome;
    }

    public void SetCapaUrl(string capaUrl)
    {
        if (string.IsNullOrWhiteSpace(capaUrl))
            throw new AtributoObrigatorioExcecao(nameof(CapaUrl));

        CapaUrl = capaUrl;
    }

    public void SetDataLancamento(DateTime dataLancamento)
    {
        DataLancamento = dataLancamento;
    }

    public virtual void SetArtista(Artista artista)
    {
        if (artista is null || artista.Id <= 0)
            throw new AtributoObrigatorioExcecao(nameof(Artista));

        Artista = artista;
    }
}
