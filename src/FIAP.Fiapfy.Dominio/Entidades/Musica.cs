using FIAP.Fiapfy.Dominio.Entidades.Base;

namespace FIAP.Fiapfy.Dominio.Entidades;

public class Musica : Entity
{
    public string Nome { get; protected set; } = string.Empty;
    public TimeSpan Duracao { get; protected set; }

    // FK explícita
    public int AlbumId { get; protected set; }
    public Album Album { get; protected set; } = default!;

    public Musica() { }

    public Musica(string nome, TimeSpan duracao, int albumId)
    {
        Nome = nome;
        Duracao = duracao;
        AlbumId = albumId;
    }
}
