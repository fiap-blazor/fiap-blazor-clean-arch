namespace FIAP.Fiapfy.Dominio.Entidades;

public class PlaylistMusica
{
    public int MusicaId { get; protected set; }
    public Musica Musica { get; protected set; } = default!;

    public int PlaylistId { get; protected set; }
    public Playlist Playlist { get; protected set; } = default!;

    public DateTime DataAdicao { get; protected set; }

    // Construtor protegido para o EF Core
    protected PlaylistMusica() { }

    public PlaylistMusica(int playlistId, int musicaId)
    {
        PlaylistId = playlistId;
        MusicaId = musicaId;
        DataAdicao = DateTime.UtcNow;
    }
}
