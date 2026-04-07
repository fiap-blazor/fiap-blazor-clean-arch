using FIAP.Fiapfy.Dominio.Entidades.Base;

namespace FIAP.Fiapfy.Dominio.Entidades;

public class Playlist : Entity
{
    public string Nome { get; protected set; } = string.Empty;
    public string Descricao { get; protected set; } = string.Empty;
    public string UsuarioId { get; protected set; } = string.Empty;

    // Backing field privado — EF Core acessa via UsePropertyAccessMode(Field)
    private readonly HashSet<PlaylistMusica> _playlistMusicas = [];
    public IReadOnlyCollection<PlaylistMusica> PlaylistMusicas => _playlistMusicas;

    // Construtor para o EF Core
    public Playlist() { }

    public Playlist(string nome, string descricao, string usuarioId)
    {
        Nome = nome;
        Descricao = descricao;
        UsuarioId = usuarioId;
    }

    public void AdicionarMusica(int musicaId)
    {
        var jaExiste = _playlistMusicas.Any(pm => pm.MusicaId == musicaId);
        if (jaExiste) return;

        _playlistMusicas.Add(new PlaylistMusica(Id, musicaId));
    }

    public void RemoverMusica(int musicaId)
    {
        var item = _playlistMusicas.FirstOrDefault(pm => pm.MusicaId == musicaId);
        if (item is not null)
            _playlistMusicas.Remove(item);
    }

    public void AtualizarNome(string nome) => Nome = nome;
    public void AtualizarDescricao(string descricao) => Descricao = descricao;
}
