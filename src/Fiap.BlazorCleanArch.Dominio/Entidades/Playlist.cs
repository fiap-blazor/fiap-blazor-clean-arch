using Fiap.BlazorCleanArch.Dominio.Entidades.Base;
using Fiap.BlazorCleanArch.Dominio.Excecoes;

namespace Fiap.BlazorCleanArch.Dominio.Entidades;

public class Playlist : Entity
{
    public string Nome { get; protected set; } = string.Empty;
    public string Descricao { get; protected set; } = string.Empty;    
    public string UsuarioId { get; protected set; } = string.Empty;

    public IReadOnlySet<Musica> Musicas { get; protected set; } = new HashSet<Musica>();

    public Playlist() { }

    public Playlist(string nome, string? descricao, string usuarioId)
    {
        SetNome(nome);
        SetDescricao(descricao);
        SetUsuarioId(usuarioId);
    }

    public void SetNome(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new AtributoObrigatorioExcecao(nameof(Nome));

        if (nome.Length > 50)
            throw new TamanhoDeAtributoInvalidoExcecao(nameof(Nome), 0, 50);

        Nome = nome;
    }

    public void SetDescricao(string? descricao)
    {
        Descricao = descricao ?? string.Empty;

        if (Descricao.Length > 255)
            throw new TamanhoDeAtributoInvalidoExcecao(nameof(Descricao), 0, 255);
    }

    public void SetUsuarioId(string usuarioId)
    {
        if (string.IsNullOrWhiteSpace(usuarioId))
            throw new AtributoObrigatorioExcecao(nameof(UsuarioId));

        UsuarioId = usuarioId;
    }
}
