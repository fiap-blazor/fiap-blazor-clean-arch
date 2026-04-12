using FIAP.Fiapfy.Dominio.Entidades;

namespace FIAP.Fiapfy.Dominio.Interfaces;

public interface IPlaylistsRepositorio : IRepositorioBase<Playlist>
{
    Task<Playlist?> ObterPorIdAsync(int id);
}
