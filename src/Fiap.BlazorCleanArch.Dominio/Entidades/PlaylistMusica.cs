using Fiap.BlazorCleanArch.Dominio.Entidades.Base;

namespace Fiap.BlazorCleanArch.Dominio.Entidades;

public class PlaylistMusica : Entity
{
    public int MusicaId { get; protected set; }
    public Musica Musica { get; protected set; } = default!;

    public int PlaylistId { get; protected set; }
    public Playlist Playlist { get; protected set; } = default!;

    public DateTime DataAdicao { get; protected set; }


    public PlaylistMusica() { }


    public PlaylistMusica(int musicaId, int playlistId)
    {
        MusicaId = musicaId;
        PlaylistId = playlistId;
        DataAdicao = DateTime.UtcNow;
    }
}