using Fiap.BlazorCleanArch.Dominio.Entidades.Base;
using Fiap.BlazorCleanArch.Dominio.Excecoes;

namespace Fiap.BlazorCleanArch.Dominio.Entidades;

public class Musica : Entity
{
    public string Nome { get; protected set; } = string.Empty;
    public TimeSpan Duracao { get; protected set; }
    public Album Album { get; protected set; } = default!;

    public Musica() { }

    public Musica(string nome, TimeSpan duracao, Album album)
    {
        SetNome(nome);
        SetDuracao(duracao);
        SetAlbum(album);
    }

    public void SetNome(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new AtributoObrigatorioExcecao("Nome");

        if (nome.Length > 50)
            throw new TamanhoDeAtributoInvalidoExcecao("Nome", 0, 50);

        Nome = nome;
    }

    public void SetDuracao(TimeSpan duracao)
    {
        if (duracao <= TimeSpan.Zero)
            throw new AtributoInvalidoExcecao(nameof(Duracao));

        if (duracao > TimeSpan.FromHours(2))
            throw new AtributoInvalidoExcecao(nameof(Duracao));

        Duracao = duracao;
    }

    public virtual void SetAlbum(Album album)
    {
        if (album is null || album.Id <= 0)
            throw new AtributoObrigatorioExcecao(nameof(Album));

        Album = album;
    }
}
